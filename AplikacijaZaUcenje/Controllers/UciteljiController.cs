using AplikacijaZaUcenje.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;

using AplikacijaZaUcenje.DATA;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UciteljiController : ControllerBase
    {
        private readonly AplikacijaContext _context;

        public UciteljiController(AplikacijaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var uciteljDB = _context.Ucitelji.ToList();

                if(uciteljDB == null || uciteljDB.Count ==0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(uciteljDB);
            } catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }
    }
}
