using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repozytorium.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    public class Uzytkownik : IdentityUser
    {
        public Uzytkownik()
        {
            this.Ksiazki = new HashSet<Ksiazka>();
        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        [NotMapped]
        [Display(Name = "Nazwa gatunku:")]
        public string PelneNazwisko
        {
            get { return Imie + " " + Nazwisko; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Ksiazka> Ksiazki { get; set; }

    }
}