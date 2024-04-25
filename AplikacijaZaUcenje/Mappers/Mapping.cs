using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class Mapping<T,DTR,DTI>
    {
        protected Mapper MapperReadToDTO;

        public Mapping()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.AllowNullDestinationValues = true;
                    c.CreateMap<T, DTR>();
                }));
        }
    }
}
