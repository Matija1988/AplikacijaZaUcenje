using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class PredmetMapper : Mapping<Predmet, PredmetDTORead, PredmetDTOInsertUpdate>
    {
        public PredmetMapper ()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Predmet, PredmetDTORead>()
                    .ConvertUsing(entity =>
                    new PredmetDTORead(
                        entity.ID,
                        entity.Naziv,
                        entity.Ucitelj.Ime + " " + entity.Ucitelj.Prezime
                        ));
                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Predmet, PredmetDTOInsertUpdate>()
                    .ConstructUsing(entity =>
                    new PredmetDTOInsertUpdate(
                        entity.Naziv,
                        entity.Ucitelj.ID
                    ));
                }));
        }

    }
}
