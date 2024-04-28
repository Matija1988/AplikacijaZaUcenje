using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GradivoController : MainController<Gradivo, GradivoDTORead, GradivoDTOInsertUpdate>
    {
        
        public GradivoController(AplikacijaContext context) : base(context)
        {
            DbSet = _context.Gradiva;
            _mapper = new GradivoMapper(); 
        }

        protected override List<GradivoDTORead> ReadAll()
        {
            var entityList = _context.Gradiva.Include(g => g.Predmet).ToList();

            return _mapper.MapReadList(entityList);
        }

        protected override void ControlDelete(Gradivo entity)
        {
            throw new NotImplementedException();
        }
    }
}
