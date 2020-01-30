using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.Models
{
    public class Giris
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }

        [Required]
        [DisplayName("Beni Hatırla")]
        public bool Hatirla { get; set; }
    }
}