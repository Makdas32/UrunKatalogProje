using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunKatalog.Identity
{
    public class ApplicationRole :IdentityRole
    {
        public string RolAciklama { get; set; }
        public ApplicationRole()
        {

        }
        public ApplicationRole(string rolename, string rolaciklama)
        {
            this.RolAciklama = rolaciklama;
        }
        
    }
}