
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

    
    
    
    public record PredmetDTORead(int ID, string Naziv, string Ucitelj);

    public record PredmetDTOInsertUpdate(string Naziv, int UciteljID);

    
    
    
    public record GradivoDTORead (int ID, string Naziv, string Predmet);

    public record GradivoDTOInsertUpdate(string Naziv, int PredmetID);



    public record PitanjaDTORead(int ID, string Opis, string Gradivo);

    public record PitanjeDTOInsertUpdate(string Opis, int GradivoID);



    public record OdgovorDTORead(int ID, string Opis, bool jeTocno, int Bodovi, int PitanjeID);

    public record OdgovorDTOInsertUpdate (string Opis, bool jeTocno, int Bodovi, int PitanjeID);


}
