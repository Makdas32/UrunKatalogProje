using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UrunKatalog.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataConnection")
        {
           // Database.SetInitializer(new DataInitializer());
           //Yukarıda yazdığımız normalde burada yazılıydı.Onu alıp globalasax dosyasına ekledik
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylari { get; set; }

    }
}