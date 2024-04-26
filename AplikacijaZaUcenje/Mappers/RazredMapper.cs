using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class RazredMapper : Mapping<Razred, RazredDTORead, RazredDTOInsertUpdate>
    {
        public RazredMapper() {

            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c => {

                    c.CreateMap<Razred, RazredDTORead>()
                    .ConvertUsing(entity =>
                    new RazredDTORead(
                        entity.ID,
                        entity.Naziv,
                        entity.MaksimalnoUcenika,
                        entity.Ucitelj == null ? null : entity.Ucitelj.Ime + " " + entity.Ucitelj.Prezime
                        )) ;

                }));


        }
    }
}
