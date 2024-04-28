using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacijaZaUcenje.Model
{
    public class Razred : Entitet
    {
        public string Naziv { get; set; }
        public int? MaksimalnoUcenika { get; set; }

        [ForeignKey("UciteljID")]
        public Ucitelj? Ucitelj { get; set; }

    }
}
