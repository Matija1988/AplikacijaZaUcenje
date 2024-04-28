
namespace AplikacijaZaUcenje.Model
{
    public record UciteljDTORead(int ID, string Ime, string Prezime,
        string Email, string BrojMobitela, string KorisnickoIme, string Zaporka);

    public record UciteljDTOInsertUpdate(string Ime, string Prezime, string Email, string? BrojMobitela,
        string KorisnickoIme, string Zaporka);

    
    
    
    
    public record RazredDTORead(int ID, string Naziv, int? MaksimalnoUcenika, string? Ucitelj);

    public record RazredDTOInsertUpdate(string Naziv, int? MaksimalnoUcenika, int? UciteljID);



    public record UcenikDTORead(int ID, string? Ime, string? Prezime, string KorisnickoIme, string Zaporka, string Razred);

    public record UcenikDTOInsertUpdate(string Ime, string Prezime, string KorisnickoIme, string Zaporka, int RazredID);

    
    
    
    public record PredmetDTORead(int Id, string Naziv, string Ucitelj);

    public record PredmetDTOInsertUpdate(string Naziv, int UciteljID);

    
    
    
    public record GradivoDTORead (int id, string naziv, string Predmet);

    public record GradivoDTOInsertUpdate(string naziv, int PredmetID);


}
