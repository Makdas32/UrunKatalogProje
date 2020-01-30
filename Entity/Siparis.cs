using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.Entity
{
    public class Siparis
    {
        public int Id { get; set; }
        public string SiparisNumarasi { get; set; }
        public double OdemeMiktari { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumSiparisDurum SiparisDurumu { get; set; }

        public virtual List<SiparisDetay> SiparisDetaylari { get; set; }


        public string KullaniciAdi { get; set; }  
        public string AdresBaslik { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string İlce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }

    public class SiparisDetay
    {
        public int Id { get; set; }
        public int SiparisMiktar { get; set; }
        public double UrunFiyat { get; set; }
        //Sipariş ile ilişkiler
        public int SiparisId { get; set; }
        public virtual Siparis Siparis { get; set; }
        //Urun ile ilişkiler
        public int UrunId { get; set; }
        public Urun Urun { get; set; }


    }
}