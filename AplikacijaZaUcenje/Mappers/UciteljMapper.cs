using AutoMapper;
using AplikacijaZaUcenje.Model;

namespace AplikacijaZaUcenje.Mappers
{
    public class UciteljMapper : Mapping<Ucitelj, UciteljDTORead, UciteljDTOInsertUpdate>
    {
        public UciteljMapper() 
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c => {

                    c.CreateMap<Ucitelj, UciteljDTORead>()
                    .ConvertUsing(entity =>
                    new UciteljDTORead(
                        entity.ID,
                        entity.Ime,
                        entity.Prezime,
                        entity.Email,
                        entity.BrojMobitela == null ? "" : entity.BrojMobitela,
                        entity.KorisnickoIme,
                        entity.Zaporka
                        ));
                
                }));
        }
    }
}
