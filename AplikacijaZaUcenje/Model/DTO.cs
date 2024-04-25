
namespace AplikacijaZaUcenje.Model
{
        public record UciteljDTORead(int ID, string Ime, string Prezime, 
            string Email, string BrojMobitela, string KorisnickoIme, string Zaporka);

        public record UciteljDTOInsertUpdate(string Ime, string Prezime, string Email, string BrojMobitela, 
            string KorisnickoIme, string Zaporka);

        public record UcenikDTORead(int ID, string Ime, string Prezime, string KorisnickoIme, string Zaporka, string Razred);

        


    
}   
