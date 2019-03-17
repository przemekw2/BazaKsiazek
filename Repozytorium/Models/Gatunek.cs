using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Gatunek
    {
        public Gatunek()
        {
            this.Ksiazka = new HashSet<Ksiazka>();
        }

        [Key]
        [Display(Name = "ID kategorii:")]
        public int Id { get; set; }

        [Display(Name = "Nazwa gatunku:")]
        [Required]
        public string Nazwa { get; set; }

        public virtual ICollection<Ksiazka> Ksiazka { get; set; }

    }
}