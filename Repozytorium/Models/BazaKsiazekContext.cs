using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repozytorium.Models
{

    public class BazaKsiazekContext : IdentityDbContext
    {
        public BazaKsiazekContext()
            : base("DefaultConnection")
        {
        }

        public static BazaKsiazekContext Create()
        {
            return new BazaKsiazekContext();
        }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Uzytkownik> Uzytkownik { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Ksiazka>().HasRequired(x => x.Uzytkownik)
                .WithMany(x => x.Ksiazki)
                .HasForeignKey(x => x.UzytkownikId)
                .WillCascadeOnDelete(true);

        }

    }
}