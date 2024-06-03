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
    public class PitanjaController : MainController<Pitanje, PitanjaDTORead, PitanjeDTOInsertUpdate>
    {
        public PitanjaController(AplikacijaContext context) : base(context) 
        {
            DbSet = _context.Pitanja;
            _mapper = new PitanjaMapper();
        }

        protected override Pitanje UpdateEntity(PitanjeDTOInsertUpdate entityTDI, Pitanje entityFromDB)
        {
            var gradivo = _context.Gradiva.Find(entityTDI.GradivoID) 
                ?? throw new Exception("Ne postoji unos sa ključem " + entityTDI.GradivoID  + " u bazi podataka!");

            entityFromDB.Opis = entityTDI.Opis;
            entityFromDB.Gradivo = gradivo;

            return entityFromDB;
        }

        protected override async Task<Pitanje> FindEntity(int id)
        {
            return await _context.Pitanja.Include(p => p.Gradivo).FirstOrDefaultAsync(x => x.ID == id) 
                ?? throw new Exception("Ne postoji unos sa ključem " + id + " u bazi podataka!");
        }

        protected override Pitanje CreateEntity(PitanjeDTOInsertUpdate entityDTO)
        {
            var gradivo = _context.Gradiva.Find(entityDTO.GradivoID)
                ?? throw new Exception("U bazi podataka ne postoji gradivo sa sifrom: " + entityDTO.GradivoID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Gradivo = gradivo;

            return entity;

        }

        protected override async Task<List<PitanjaDTORead>> ReadAll()
        {
            var entityList =  await _context.Pitanja.Include(p => p.Gradivo).ToListAsync();

            if(entityList == null || entityList.Count == 0) 
            { 
                throw new Exception("Nema informacija u bazi podataka!"); 
            }

            return _mapper.MapReadList(entityList);
        }

        protected override async void ControlDelete(Pitanje entity)
        {
            var entityList = await _context.Odgovori.Include(g => g.Pitanje).Where(g => g.Pitanje.ID == entity.ID).ToListAsync();

            if (entityList != null && entityList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Pitanje se ne može obrisati jer je povezano sa odgovorima: ");

                foreach (var odgovor in entityList)
                {
                    sb.Append(odgovor.ID).Append(", ");
                }

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));

            }
        }
    }
}
