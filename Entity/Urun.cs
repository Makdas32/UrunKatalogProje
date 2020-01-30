using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UrunKatalog.Entity
{
    public class Urun
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string UrunAciklama { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double UrunFiyat { get; set; }
        [DisplayName("Ürün Stok")]
        public int UrunStok { get; set; }
        [DisplayName("Ürün Resim")]
        public string UrunResim { get; set; }
        [DisplayName("Ürün Satıştamı?")]
        public bool UrunSatistami { get; set; }
        [DisplayName("Anasayfada Çıksınmı?")]
        public bool UrunAnasayfa { get; set; }

        //İlişkiler
        public int KategoriId { get; set; }
        [DisplayName("Ürün Kategorisi")]
        public Kategori Kategori { get; set; }
    }
}