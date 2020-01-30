using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UrunKatalog.Identity
{
    public class IdentityInitializer :CreateDatabaseIfNotExists<IdentityDataContext> //Sadece yoksa oluşturur.Değişiklik yapınca baştan oluşturmaz
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name == "Admin")) //Admin rolü yoksa
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var rol = new ApplicationRole() { Name = "Admin", RolAciklama = "Yönetici Rolü" };
                manager.Create(rol);
            }
            if (!context.Roles.Any(i => i.Name == "User")) //User rolü yoksa
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var rol = new ApplicationRole() { Name = "User",RolAciklama="Kullanıcı Rolü"};
                manager.Create(rol);
            }

            if (!context.Users.Any(i => i.UserName == "makdas")) //makdas isimli kullanıcı yoksa
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var kullanici = new ApplicationUser() { UserName = "makdas", Name = "Murat", Surname = "Akdaş", Email = "muratakdas32@hotmail.com" };           
                manager.Create(kullanici,"123456");
                manager.AddToRole(kullanici.Id,"Admin");
                manager.AddToRole(kullanici.Id, "User"); //Hem Admin Hem User yapabiliyoruz
            }

            if (!context.Users.Any(i => i.UserName == "deneme")) 
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var kullanici = new ApplicationUser() { UserName = "deneme", Name = "deneme", Surname = "deneme", Email = "deneme3432111@hotmail.com" };
                manager.Create(kullanici, "123456");
                manager.AddToRole(kullanici.Id, "User");
            }



            base.Seed(context);
        }
    }
}