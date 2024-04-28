using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class GradivoMapper : Mapping<Gradivo, GradivoDTORead, GradivoDTOInsertUpdate>
    {
        public GradivoMapper()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Gradivo, GradivoDTORead>()
                    .ConvertUsing(entity =>
                    new GradivoDTORead(
                        entity.ID,
                        entity.Naziv,
                        entity.Predmet.Naziv 
                        ));
                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Gradivo, GradivoDTOInsertUpdate>()
                    .ConstructUsing(entity =>
                    new GradivoDTOInsertUpdate(
                        entity.Naziv,
                        entity.Predmet.ID
                        ));
                }));
        }

    }
}
