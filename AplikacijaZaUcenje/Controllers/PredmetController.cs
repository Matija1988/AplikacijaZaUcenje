using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PredmetController : MainController<Predmet, PredmetDTORead, PredmetDTOInsertUpdate>
    {
        public PredmetController(AplikacijaContext context) : base (context) 
        { 
            DbSet = _context.Predmeti;
            _mapper = new PredmetMapper();
        }

        protected override Predmet UpdateEntity(PredmetDTOInsertUpdate entityTDI, Predmet entityFromDB)
        {
            var ucitelj = _context.Ucitelji.Find(entityTDI.UciteljID)
                ?? throw new Exception("Ne postoji unos sa ključem " + entityFromDB.Ucitelj.ID + " u bazi podataka!");

            entityFromDB.Naziv = entityTDI.Naziv;
            entityFromDB.Ucitelj = ucitelj; 

            return entityFromDB;
        }

        protected override async Task<Predmet> FindEntity(int id)
        {
            return await _context.Predmeti.Include(u => u.Ucitelj).FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new Exception("Ne postoji unos sa ključem " + id + " u bazi podataka!");
        }

        protected override Predmet CreateEntity(PredmetDTOInsertUpdate entityDTO)
        {
            var ucitelj = _context.Ucitelji.Find(entityDTO.UciteljID)
                    ?? throw new Exception("U bazi podataka ne postoji ucitelj sa sifrom: " + entityDTO.UciteljID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Ucitelj = ucitelj;

            return entity;
        }

        protected override async Task<List<PredmetDTORead>> ReadAll()
        {
            var list = await _context.Predmeti.Include(g => g.Ucitelj).ToListAsync();

            if (list == null || list.Count == 0) 
            { 
                throw new Exception("Nema informacija u bazi podataka!"); 
            }

            return _mapper.MapReadList(list);
        }

        protected override async void ControlDelete(Predmet entity)
        {
            var entityList = await _context.Gradiva.Include(g => g.Predmet).Where(g => g.Predmet.ID == entity.ID).ToListAsync();

            if(entityList != null && entityList.Count > 0) 
            { 
                StringBuilder sb = new StringBuilder();

                sb.Append("Predmet se ne moze obrisati jer je povezan sa gradivima: ");

                foreach(var gradivo in entityList)
                {
                    sb.Append(gradivo.Naziv).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length -2));
                
            }

        }
    }
}
