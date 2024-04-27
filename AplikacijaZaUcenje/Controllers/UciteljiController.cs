using AplikacijaZaUcenje.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using System.Runtime.CompilerServices;

using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Model;
using System.Text;

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

        protected override void ControlDelete(Ucitelj entity)
        {
            var entityList = _context.Razredi.Include(r => r.Ucitelj).Where(r => r.Ucitelj.ID == entity.ID).ToList();
            
         //   var entityList2 = _context.Predmeti.Include(p => p.Ucitelj).Where(p => p.Ucitelj.ID == entity.ID).ToList();

            if(entityList != null && entityList.Count() > 0) 
            { 
                StringBuilder sb = new StringBuilder();

                sb.Append("Ucitelj se ne moze izbrisati iz baze podataka jer je povezan sa razredima: ");

                foreach(var razred in entityList)
                {
                    sb.Append(razred.Naziv).Append(", ");
                }

                sb.Append("\nI sa predmetima: ");

                //foreach(var predmet in entityList2 )
                //{
                //    sb.Append(predmet.Naziv).Append(", ");
                //}

                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length -2));
            
            }
        }
    }
}
