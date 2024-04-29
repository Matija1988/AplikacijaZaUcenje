using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;

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

        protected override void ControlDelete(Odgovor entity)
        {
            throw new NotImplementedException();
        }
    }
}
