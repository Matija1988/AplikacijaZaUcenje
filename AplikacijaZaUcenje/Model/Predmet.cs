using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Predmet : Entitet
    {
        public string Naziv { get; set; }

        [ForeignKey("uciteljID")]
        public Ucitelj Ucitelj { get; set; }

    }
}
