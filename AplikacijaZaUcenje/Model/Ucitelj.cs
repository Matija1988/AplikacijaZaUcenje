namespace AplikacijaZaUcenje.Model
{
    public class Ucitelj : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        
        public string Email { get; set; }
        public string? BrojMobitela { get; set; }

        public string  KorisnickoIme { get; set; }
        public string Zaporka { get; set; }

    }
}
