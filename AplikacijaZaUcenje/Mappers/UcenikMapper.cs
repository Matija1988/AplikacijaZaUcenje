using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class UcenikMapper : Mapping<Ucenik, UcenikDTORead, UcenikDTOInsertUpdate>
    {
        public UcenikMapper()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c => {

                    c.CreateMap<Ucenik, UcenikDTORead>()
                    .ConvertUsing(entity =>
                    new UcenikDTORead(
                        entity.ID,
                        entity.Ime == null ? "" : entity.Ime,
                        entity.Prezime == null ? "" : entity.Prezime,
                        entity.KorisnickoIme,
                        entity.Zaporka,
                        entity.Razred == null ? null : entity.Razred.Naziv
                        ));

                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Ucenik, UcenikDTOInsertUpdate>()
                    .ConvertUsing(entity =>
                    new UcenikDTOInsertUpdate(
                        entity.Ime,
                        entity.Prezime,
                        entity.KorisnickoIme,
                        entity.Zaporka,
                        entity.Razred.ID
                        ));
                }));

            MapperMapInsertUpdatedFromDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<UcenikDTOInsertUpdate, Ucenik>();
                }));
        }
    }
}
