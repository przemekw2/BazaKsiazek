using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Repozytorium.Repo
{
    public class KsiazkaRepo
    {

        private BazaKsiazekContext db = new BazaKsiazekContext();

        public IQueryable<Ksiazka> PobierzKsiazki()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            return db.Ksiazki.AsNoTracking();
        }

    }
}