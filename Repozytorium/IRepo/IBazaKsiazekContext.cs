using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repozytorium.IRepo
{
    public interface IBazaKsiazekContext
    {
        DbSet<Ksiazka> Ksiazki { get; set; }
        DbSet<Autor> Autorzy { get; set; }
        DbSet<Gatunek> Gatunki { get; set; }
        DbSet<Uzytkownik> Uzytkownik { get; set; }

        int SaveChanges();
        Database Database { get; }

    }
}
