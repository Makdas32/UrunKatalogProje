using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.Models
{
    public class Kullanici
    {
        [Required]
        [DisplayName("Ad")]
        public string İsim { get; set; }
        [Required]
        [DisplayName("Soyad")]
        public string Soyad { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta Adresini Kontrol Ediniz")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Sifre",ErrorMessage = "Şifreleriniz Uyuşmuyor")]
        public string SifreTekrar { get; set; }
    }
}