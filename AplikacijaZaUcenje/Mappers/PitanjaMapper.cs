using AplikacijaZaUcenje.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace AplikacijaZaUcenje.Mappers
{
    public class PitanjaMapper : Mapping<Pitanje, PitanjaDTORead, PitanjeDTOInsertUpdate>
    {
        public PitanjaMapper()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c => {
                    c.CreateMap<Pitanje, PitanjaDTORead>()
                    .ConvertUsing(entity =>
                    new PitanjaDTORead(
                        entity.ID,
                        entity.Opis,
                        entity.Gradivo.Naziv
                        ));
                    }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Pitanje, PitanjeDTOInsertUpdate>()
                    .ConstructUsing(entity =>
                    new PitanjeDTOInsertUpdate(
                        entity.Opis,
                        entity.Gradivo.ID
                        ));
                }));

            MapperMapInsertUpdatedFromDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PitanjeDTOInsertUpdate, Pitanje>();
                }));

        }
    }
}
