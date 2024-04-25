using AplikacijaZaUcenje.Model;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.DATA
{
    public class AplikacijaContext : DbContext
    {
        public AplikacijaContext(DbContextOptions<AplikacijaContext> options) : base(options) 
        { 
        
        }

        public DbSet<Gradivo> Gradiva;
        public DbSet<Odgovor> Odgovori;
        public DbSet<Pitanje> Pitanja;
        public DbSet<Predmet> Predmeti;
        public DbSet<Razred> Razredi;
        public DbSet<Ucenik> Ucenici;
        public DbSet<Ucitelj> Ucitelji;
    }
}
