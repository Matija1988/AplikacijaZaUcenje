using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.Controllers
{
    public abstract class MainController<T, TDR, TDI> : ControllerBase where T : Entitet
    {
        protected DbSet<T> DbSet;

        protected Mapping<T, TDR, TDI> _mapper;

        protected readonly AplikacijaContext _context;

        public MainController(AplikacijaContext context) {

            _context = context;
            _mapper = new Mapping<T, TDR, TDI>();

        }

        [HttpGet]

        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return new JsonResult(ReadAll());
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        protected virtual List<TDR> ReadAll()
        {
            var list = DbSet.ToList();

            if (list == null || list.Count == 0)
            {
                throw new Exception("Database empty");
            }
            return _mapper.MapReadList(list);
        }
    }
}
