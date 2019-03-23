using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class KsiazkiRepo : IKsiazkiRepo
    {
        private readonly IBazaKsiazekContext _db;

        public KsiazkiRepo(IBazaKsiazekContext db)
        {
            _db = db;
        }

        public IQueryable<Ksiazka> PobierzKsiazki()
        {
            //logowanie sql
            _db.Database.Log = message => Trace.WriteLine(message);
            var ksiazki = _db.Ksiazki.Include(k => k.Uzytkownik).AsNoTracking();
            return ksiazki;
            //return _db.Ksiazki.AsNoTracking();
        }

    }
}