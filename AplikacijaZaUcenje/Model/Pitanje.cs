using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Pitanje : Entitet
    {
        public string Opis { get; set; }

        [ForeignKey("gradivoID")]
        public Gradivo Gradivo { get; set; }
    }
}
