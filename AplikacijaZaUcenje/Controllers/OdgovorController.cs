using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OdgovorController : MainController<Odgovor, OdgovorDTORead, OdgovorDTOInsertUpdate>
    {
        public OdgovorController(AplikacijaContext context) : base(context)
        {
            DbSet = _context.Odgovori;
            _mapper = new OdgovorMapper();

        }

        protected override  Odgovor UpdateEntity(OdgovorDTOInsertUpdate entityTDI, Odgovor entityFromDB)
        {
            var pitanje =  _context.Pitanja.Find(entityTDI.PitanjeID)
                ?? throw new Exception("Ne postoji unos sa ključem " + entityTDI.PitanjeID + " u bazi podataka!");

            entityFromDB.Pitanje = pitanje;
            entityFromDB.Opis = entityTDI.Opis;
            entityFromDB.JeTocno = entityTDI.jeTocno;
            entityFromDB.Bodovi = entityTDI.Bodovi;

            return entityFromDB;
        }

        protected override async  Task<Odgovor> FindEntity(int id)
        {
            return _context.Odgovori.Include(o => o.Pitanje).FirstOrDefault(x => x.ID == id)
                ?? throw new Exception("Ne postoji unos sa ključem " + id + " u bazi podataka!");
        }

        protected override Odgovor CreateEntity(OdgovorDTOInsertUpdate entityDTO)
        {
            var pitanje = _context.Pitanja.Find(entityDTO.PitanjeID)
                ?? throw new Exception("U bazi podataka ne postoji pitanje sa sifrom: " + entityDTO.PitanjeID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Pitanje = pitanje;

            return entity;

        }

        protected override async Task<List<OdgovorDTORead>> ReadAll()
        {
            var entityList = await _context.Odgovori.Include(o => o.Pitanje).ToListAsync();

            if (entityList == null || entityList.Count == 0)
            {
                throw new Exception("Nema informacija u bazi podataka!");
            }

            return _mapper.MapReadList(entityList);
        }

        protected override void ControlDelete(Odgovor entity)
        {
            var entityFromDB =  _context.Odgovori.Include(x => x.IUcenici).FirstOrDefault(x => x.ID == entity.ID) 
                ?? throw new Exception("Odgovor sa šifrom " + entity.ID + " nije pronađen u bazi podataka!");
            
            if (entity != null && entity.IUcenici.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Pitanje se ne može obrisati jer je povezano sa odgovorima: ");

                foreach (var ucenici in entityFromDB.IUcenici)
                {
                    sb.Append(ucenici.Ime + " " + ucenici.Prezime).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));
            }
        }
    }
}
