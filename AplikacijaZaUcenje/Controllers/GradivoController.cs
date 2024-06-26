﻿using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

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
        protected override Gradivo UpdateEntity(GradivoDTOInsertUpdate entityTDI, Gradivo entityFromDB)
        {
            var predmet = _context.Predmeti.Find(entityTDI.PredmetID) 
                ?? throw new Exception("Ne postoji unos sa ključem " + entityTDI.PredmetID + " u bazi podataka!");

            entityFromDB.Naziv = entityTDI.Naziv;
            entityFromDB.Predmet = predmet;

            return entityFromDB;
        }
        protected override async Task<Gradivo> FindEntity(int id)
        {
            return _context.Gradiva.Include(g => g.Predmet).FirstOrDefault(x => x.ID == id)
                ?? throw new Exception("Ne postoji unos sa ključem " + id + " u bazi podataka!");

        }

        protected override Gradivo CreateEntity(GradivoDTOInsertUpdate entityDTO)
        {
            var predmet = _context.Predmeti.Find(entityDTO.PredmetID)
                ?? throw new Exception("U bazi podataka ne postoji predmet sa sifrom: " + entityDTO.PredmetID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Predmet = predmet;

            return entity;

        }

        protected override async Task<List<GradivoDTORead>> ReadAll()
        {
            var entityList = await _context.Gradiva.Include(g => g.Predmet).ToListAsync();

            if (entityList == null || entityList.Count == 0) 
            { 
                throw new Exception("Nema informacija u bazi podataka!"); 
            }

            return _mapper.MapReadList(entityList);
        }

        protected override async void ControlDelete(Gradivo entity)
        {
            var entityList =  await _context.Pitanja.Where(p => p.Gradivo.ID == entity.ID).ToListAsync();

            if(entity != null && entity.Pitanja != null) 
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Gradivo se ne može obrisati pošto je povezano sa pitanjima:");

                foreach (var pitanje in entityList)
                {
                    sb.Append(pitanje.ID).Append(", ");
                }
                throw new Exception(sb.ToString().Substring(0, sb.ToString().Length - 2));

            }
        }
    }
}
