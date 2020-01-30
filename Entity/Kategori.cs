using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrunKatalog.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:20,ErrorMessage ="En Fazla 20 Karakter Girebilirsiniz")]
        public string KategoriAdi { get; set; }
        [DisplayName("Kategori Açıklaması")]
        public string KategoriAciklama { get; set; }

        //İlişkiler
        public List<Urun> Urunler { get; set; }
    }
}