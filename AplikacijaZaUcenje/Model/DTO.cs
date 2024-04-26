
namespace AplikacijaZaUcenje.Model
{
    public record UciteljDTORead(int ID, string Ime, string Prezime,
        string Email, string BrojMobitela, string KorisnickoIme, string Zaporka);

    public record UciteljDTOInsertUpdate(string Ime, string Prezime, string Email, string? BrojMobitela,
        string KorisnickoIme, string Zaporka);

    public record RazredDTORead(int ID, string Naziv, int MaksimalnoUcenika, string Razrednik);

    public record RazredDTOInsertUpdate(string Naziv, int MaksimalnoPolaznika, int UciteljRazrednikID);

    public record UcenikDTORead(int ID, string? Ime, string? Prezime, string KorisnickoIme, string Zaporka, string Razred);

    public record UcenikDTOInsertUpdate(string Ime, string Prezime, string KorisnickoIme, string Zaporka, int RazredID);



}
