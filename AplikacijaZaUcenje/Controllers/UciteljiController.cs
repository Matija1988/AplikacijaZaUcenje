using AplikacijaZaUcenje.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using System.Runtime.CompilerServices;

using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Model;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UciteljiController : MainController<Ucitelj, UciteljDTORead, UciteljDTOInsertUpdate>
    {

        public UciteljiController(AplikacijaContext context) : base(context)
        {
            DbSet = _context.Ucitelji;
        }

    }
}
