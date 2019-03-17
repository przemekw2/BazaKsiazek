namespace Repozytorium.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Repozytorium.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.BazaKsiazekContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repozytorium.Models.BazaKsiazekContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            SeedRoles(context);
            SeedUsers(context);
            SeedKsiazki(context);
            SeedGatunki(context);
            SeedAutorzy(context);
        }

        private void SeedRoles(Repozytorium.Models.BazaKsiazekContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Uzytkownik"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Uzytkownik";
                roleManager.Create(role);
            }

        }

        private void SeedUsers(Repozytorium.Models.BazaKsiazekContext context)
        {
            var store = new UserStore<Uzytkownik>(context);
            var manager = new UserManager<Uzytkownik>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new Uzytkownik { UserName = "Admin", Imie = "Przemyslaw", Nazwisko = "Wlodarczyk" };
                var adminresult = manager.Create(user, "123456789");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Przemek"))
            {
                var user = new Uzytkownik { UserName = "Przemek", Imie = "Przemyslaw", Nazwisko = "Wlodarczyk" };
                var adminresult = manager.Create(user, "123456789");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Uzytkownik");
            }

        }

        private void SeedAutorzy(Repozytorium.Models.BazaKsiazekContext context)
        {
            var autor = new Autor()
            {
                Id = 1,
                Imie = "Ernest",
                Nazwisko = "Hemingway"
            };
            context.Set<Autor>().AddOrUpdate(autor);
            context.SaveChanges();
        }

        private void SeedGatunki(Repozytorium.Models.BazaKsiazekContext context)
        {
            List<string> gatunkiList = new List<string>() { "Powieœæ", "Fantastyka", "Fantasy", "Science Fiction", "Horror", "Sensacja", "Krymina³", "Thriller" };

            for (int i = 0; i < gatunkiList.Count; i++)
            {
                var gatunek = new Gatunek()
                {
                    Id = i + 1,
                    Nazwa = gatunkiList[i]
                };
                context.Set<Gatunek>().AddOrUpdate(gatunek);
            }
            context.SaveChanges();   
        }

        private void SeedKsiazki(Repozytorium.Models.BazaKsiazekContext context)
        {
            //Po¿egnanie z broni¹
            //9788528618327
            var idUzytkownika = context.Set<Uzytkownik>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            var idAutora = context.Set<Autor>().Where(a => a.Imie == "Ernest" && a.Nazwisko == "Hemingway").FirstOrDefault().Id;
            var idGatunku = context.Set<Gatunek>().Where(g => g.Nazwa == "Powieœæ").FirstOrDefault().Id;
            var ksiazka = new Ksiazka()
            {
                Id = 1,
                ISBN = "9788528618327",
                Tytul = "Po¿egnanie z broni¹",
                DataDodania = DateTime.Now,
                DataWydania = new DateTime(1929, 1, 1),
                UzytkownikId = idUzytkownika,
                Autor = context.Set<Autor>().Where(a => a.Imie == "Ernest" && a.Nazwisko == "Hemingway").FirstOrDefault(),
                Gatunek = context.Set<Gatunek>().Where(g => g.Nazwa == "Powieœæ").FirstOrDefault()
            };

            context.Set<Ksiazka>().AddOrUpdate(ksiazka);
            context.SaveChanges();

        }





    }
}
