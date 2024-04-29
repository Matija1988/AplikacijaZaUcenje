using AplikacijaZaUcenje.Model;
using Microsoft.EntityFrameworkCore;

namespace AplikacijaZaUcenje.DATA
{
    public class AplikacijaContext : DbContext
    {
        public AplikacijaContext(DbContextOptions<AplikacijaContext> options) : base(options) 
        { 
        
        }

        public DbSet<Ucitelj> Ucitelji { get; set; }
        public DbSet<Gradivo> Gradiva { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Razred> Razredi { get; set; }
        public DbSet<Ucenik> Ucenici { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Razred>().HasOne(razred => razred.Ucitelj);

            modelBuilder.Entity<Ucenik>()
                .HasMany(o => o.Odgovori)
                .WithMany(u => u.IUcenici)
                .UsingEntity<Dictionary<string, object>>("rezultati", 
                r => r.HasOne<Odgovor>().WithMany().HasForeignKey("odgovorID"),
                r => r.HasOne<Ucenik>().WithMany().HasForeignKey("ucenikID"),
                r => r.ToTable("rezultati")
            );

        }

    }
}
