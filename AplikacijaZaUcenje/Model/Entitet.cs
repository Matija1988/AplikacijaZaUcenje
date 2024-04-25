using System.ComponentModel.DataAnnotations;

namespace AplikacijaZaUcenje.Model
{
    public abstract class Entitet
    {
        [Key]
        public int ID { get; set; }
    }
}
