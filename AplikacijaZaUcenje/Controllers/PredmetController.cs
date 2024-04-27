﻿using AplikacijaZaUcenje.DATA;
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

        protected override Predmet CreateEntity(PredmetDTOInsertUpdate entityDTO)
        {
            var ucitelj = _context.Ucitelji.Find(entityDTO.UciteljID)
                    ?? throw new Exception("U bazi podataka ne postoji ucitelj sa sifrom: " + entityDTO.UciteljID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Ucitelj = ucitelj;

            return entity;
        }

        protected override List<PredmetDTORead> ReadAll()
        {
            var list = _context.Predmeti.Include(g => g.Ucitelj).ToList();

            if (list == null || list.Count == 0) { throw new Exception("No data in database!"); }

            return _mapper.MapReadList(list);
        }

        protected override void ControlDelete(Predmet entity)
        {
            var entityList = _context.Gradiva.Include(g => g.Predmet).Where(g => g.Predmet.ID == entity.ID).ToList();

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