namespace AplikacijaZaUcenje.Model
{
    public class Razred : Entitet
    {
        public string Naziv { get; set; }
        public int MaksimalnoUcenika { get; set; }
        public int UciteljRazrednikID { get; set; }

    }
}
