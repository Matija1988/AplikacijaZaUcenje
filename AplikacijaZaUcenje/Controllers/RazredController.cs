using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RazredController : MainController <Razred, RazredDTORead, RazredDTOInsertUpdate>
    {
        
        public RazredController(AplikacijaContext context) : base(context) 
        {
            DbSet = _context.Razredi; 
        }

        protected override List<RazredDTORead> ReadAll()
        {
            var entityList = _context.Razredi.Include(r => r.Ucitelj).ToList();

            if(entityList == null || entityList.Count() < 0) 
            { 
                throw new Exception("No data in database!"); 
            }

            return _mapper.MapReadList(entityList);
        }

        protected override void ControlDelete(Razred entity)
        {
            throw new NotImplementedException();
        }
    }
}
