using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Ucenik : Entitet
    {
        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Zaporka { get; set; }

        [ForeignKey("RazredID")]
        public Razred Razred { get; set; }
    }
}
