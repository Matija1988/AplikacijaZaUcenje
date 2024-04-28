using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Gradivo : Entitet
    {
        public string Naziv { get; set; }

        [ForeignKey("predmetID")]
        public Predmet Predmet { get; set; }

        public List<Pitanje> Pitanja { get; set; }
    }
}
