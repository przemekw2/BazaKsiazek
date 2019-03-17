using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Ksiazka
    {

        public Ksiazka()
        {
        }

        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Display(Name = "Nr ISBN:")]
        [MaxLength(50)]
        public string ISBN { get; set; }

        [Display(Name = "Tytuł książki:")]
        [MaxLength(100)]
        public string Tytul { get; set; }

        [Display(Name = "Data wydania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataWydania { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataDodania { get; set; }

        public string UzytkownikId { get; set; }
        //public string AutorId { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual Gatunek Gatunek { get; set; }
        public virtual Autor Autor { get; set; }

    }
}