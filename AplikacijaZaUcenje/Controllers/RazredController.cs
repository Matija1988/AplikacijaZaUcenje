using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Text;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RazredController : MainController <Razred, RazredDTORead, RazredDTOInsertUpdate>
    {
        
        public RazredController(AplikacijaContext context) : base(context) 
        {
            DbSet = _context.Razredi;
            _mapper = new RazredMapper();
        }

        protected override Razred UpdateEntity(RazredDTOInsertUpdate entityTDI, Razred entityFromDB)
        {
            var ucitelj = _context.Ucitelji.Find(entityTDI.UciteljID)
                ?? throw new Exception("Entitet sa ključem: " + entityTDI.UciteljID + "-> nije pronaden u bazi podataka!");

            entityFromDB.Naziv = entityTDI.Naziv;
            entityFromDB.MaksimalnoUcenika = entityTDI.MaksimalnoUcenika;
            entityFromDB.Ucitelj = ucitelj;

            return entityFromDB;

        }

        protected override Razred FindEntity(int id)
        {
            return _context.Razredi.Include(r => r.Ucitelj).FirstOrDefault(x => x.ID == id)
                ?? throw new Exception("Entitet sa ključem: " + id + "-> nije pronaden u bazi podataka!");
        }

        protected override Razred CreateEntity(RazredDTOInsertUpdate entityDTO)
        {
            var ucitelj = _context.Ucitelji.Find(entityDTO.UciteljID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Ucitelj = ucitelj;   
            entity.MaksimalnoUcenika = entityDTO.MaksimalnoUcenika;

            return entity;
        }

        protected override List<RazredDTORead> ReadAll()
        {
            var entityList = _context.Razredi.Include(r => r.Ucitelj).ToList();

            if(entityList == null || entityList.Count == 0) 
            { 
                throw new Exception("Nema informacija u bazi podataka!"); 
            }

            return _mapper.MapReadList(entityList);
        }

        protected override void ControlDelete(Razred entity)
        {
            var entityList = _context.Ucenici.Include(u=>u.Razred).Where(x=> x.Razred.ID == entity.ID).ToList();

            if(entityList.Count > 0 && entity.Ucenici != null) 
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Razred se ne može obrisati pošto je povezan sa učenicima:");
               
                foreach(var ucenik in entityList)
                {
                    sb.Append(ucenik.Ime + " " + ucenik.Prezime).Append(", ");
                }
                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length  -2));
            }

        }
    }
}
