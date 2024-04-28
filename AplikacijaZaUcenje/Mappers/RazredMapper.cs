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
                    .ConvertUsing(entity =>
                    new RazredDTORead(
                        entity.ID,
                        entity.Naziv,
                        entity.MaksimalnoUcenika,
                        entity.Ucitelj.Ime + " " + entity.Ucitelj.Prezime
                        ));

                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Razred, RazredDTOInsertUpdate>().ConvertUsing(entity =>
                    new RazredDTOInsertUpdate(
                        entity.Naziv,
                        entity.MaksimalnoUcenika,
                        entity.Ucitelj.ID
                        ));
                }));


        }
    }
}
