using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Autor
    {

        public Autor()
        {
            this.Ksiazka = new HashSet<Ksiazka>();
        }

        [Key]
        [Display(Name = "ID kategorii:")]
        public int Id { get; set; }

        [Display(Name = "Imię autora:")]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko autora:")]
        [MaxLength(50)]
        public string Nazwisko { get; set; }

        public virtual ICollection<Ksiazka> Ksiazka { get; set; }

    }
}