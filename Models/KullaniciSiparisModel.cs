using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunKatalog.Entity;

namespace UrunKatalog.Models
{
    public class KullaniciSiparisModel
    {
        public int Id { get; set; }
        public string SiparisNumarasi { get; set; }
        public double OdemeMiktari { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumSiparisDurum SiparisDurumu { get; set; }
    }
}