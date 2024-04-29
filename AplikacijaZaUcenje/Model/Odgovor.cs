using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Odgovor : Entitet
    {
        public string Opis { get; set; }
        public bool JeTocno { get; set; }
        public int Bodovi { get; set; }

        [ForeignKey("pitanjeID")]
        public Pitanje Pitanje { get; set; }
    }
}
