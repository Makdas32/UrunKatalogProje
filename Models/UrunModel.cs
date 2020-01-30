using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunKatalog.Models
{
    public class UrunModel
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public double UrunFiyat { get; set; }
        public int UrunStok { get; set; }
        public string UrunResim { get; set; }

        public int KategoriId { get; set; }
    }
}