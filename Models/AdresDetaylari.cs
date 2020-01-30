using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.Models
{
    public class AdresDetaylari
    {
        public string KullaniciAdi { get; set; }
        [Required]
        public string AdresBaslik { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string İlce { get; set; }
        [Required]
        public string Mahalle { get; set; }
        [Required]
        public string PostaKodu { get; set; }
    }
}