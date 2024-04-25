namespace AplikacijaZaUcenje.Model
{
    public abstract class Osoba : Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }

        public string? KorisnickoIme { get; set; }

        public string? Zaporka { get; set; }
    }
}
