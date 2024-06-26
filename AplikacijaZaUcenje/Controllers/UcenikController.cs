﻿using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UcenikController : MainController<Ucenik, UcenikDTORead, UcenikDTOInsertUpdate>
    {
        public UcenikController(AplikacijaContext context) : base(context)
        {
            DbSet = _context.Ucenici;
            _mapper = new UcenikMapper();
        }

        protected override async void ControlDelete(Ucenik entity)
        {
            var entityFromDB = await _context.Ucenici.FindAsync(entity.ID) 
                ?? throw new Exception("Entitet sa " + entity.ID + " nije pronaden u bazi podataka!");
        }

        protected override  Ucenik CreateEntity(UcenikDTOInsertUpdate entityDTO)
        {
            var razred = _context.Razredi.Find(entityDTO.RazredID) 
                    ?? throw new Exception("U bazi podataka ne postoji razred sa sifrom: " + entityDTO.RazredID);

            var entity = _mapper.MapInsertUpdatedFromDTO(entityDTO);

            entity.Razred = razred;

            return entity;
        }

        protected override async Task<List<UcenikDTORead>> ReadAll()
        {
            var list = await _context.Ucenici.Include(u => u.Razred).ToListAsync();

            if (list == null || list.Count == 0) 
            { 
                throw new Exception("No data in database!"); 
            }

            return _mapper.MapReadList(list);
        }
    }


}
