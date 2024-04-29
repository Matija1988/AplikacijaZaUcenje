using AplikacijaZaUcenje.Model;
using AutoMapper;

namespace AplikacijaZaUcenje.Mappers
{
    public class OdgovorMapper : Mapping<Odgovor, OdgovorDTORead, OdgovorDTOInsertUpdate>
    {
        public OdgovorMapper()
        {
            MapperReadToDTO = new Mapper(
                new MapperConfiguration(c => 
                {
                    c.CreateMap<Odgovor, OdgovorDTORead>()
                    .ConvertUsing(entity =>
                    new OdgovorDTORead(
                        entity.ID,
                        entity.Opis,
                        entity.JeTocno,
                        entity.Bodovi,
                        entity.Pitanje.ID
                        ));
                }));

            MapperMapInsertUpdateToDTO = new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Odgovor, OdgovorDTOInsertUpdate>()
                    .ConstructUsing(entity =>
                    new OdgovorDTOInsertUpdate(
                        entity.Opis,
                        entity.JeTocno,
                        entity.Bodovi,
                        entity.Pitanje.ID
                        ));
                }));
        }
    }
}
