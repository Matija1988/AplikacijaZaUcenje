using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UcenikController : MainController<Ucenik, UcenikDTORead, UcenikDTOInsertUpdate>
    {
        public UcenikController(AplikacijaContext context) : base(context)
        {
            DbSet = _context.Ucenici;
        }
    }
}
