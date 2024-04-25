namespace AplikacijaZaUcenje.Model
{
    public class Odgovor : Entitet
    {
        public string Opis { get; set; }
        public bool JeTocno { get; set; }
        public int Bodovi { get; set; }
        public int pitanjeID { get; set; }
    }
}
