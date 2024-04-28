using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class RazredMapper : Mapping<Razred, RazredDTORead, RazredDTOInsertUpdate>
    {
        public RazredMapper() {

            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Razred, RazredDTORead>()
                    .ConstructUsing(entity =>
                    new RazredDTORead(
                        entity.ID,
                        entity.Naziv,
                        entity.MaksimalnoUcenika,
                        entity.Ucitelj == null ? null : entity.Ucitelj.Ime + " " + entity.Ucitelj.Prezime
                        )) ;
                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Razred, RazredDTOInsertUpdate>()
                    .ConstructUsing(entity =>
                    new RazredDTOInsertUpdate(
                        entity.Naziv,
                        entity.MaksimalnoUcenika,
                        entity.Ucitelj.ID == null ? null : entity.Ucitelj.ID
                        ));
                }));


        }
    }
}
