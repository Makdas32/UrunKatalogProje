using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UrunKatalog.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Kategori> Kategoriler = new List<Kategori>()
            {
                new Kategori(){ KategoriAdi="Kamera",KategoriAciklama="Kamera Ürünleri"},
                 new Kategori(){ KategoriAdi="Bilgisayar",KategoriAciklama="Bilgisayar Ürünleri"},
                  new Kategori(){ KategoriAdi="Elektronik",KategoriAciklama="Elektronik Ürünleri"},
                   new Kategori(){ KategoriAdi="Telefon",KategoriAciklama="Telefon Ürünleri"},
                    new Kategori(){ KategoriAdi="Beyaz Eşya",KategoriAciklama="Beyaz Eşya Ürünleri"},
            };

            foreach (var item in Kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            List<Urun> Urunler = new List<Urun>()
            {
                new Urun(){ UrunAdi = "Canon Eos 1200D 18-55 mm DC Profesyonel Dijital Fotoğraf Makinesi",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  1,UrunAnasayfa = true,UrunResim="1.jpg" },
                new Urun(){ UrunAdi = "Canon Eos 100D 18-55 mm DC Profesyonel Fotoğraf Makines",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  1 ,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "Canon Eos 700D 18-55 DC DSLR Fotoğraf Makinesi",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =false , KategoriId =  1,UrunAnasayfa = true,UrunResim="3.jpg"},
                new Urun(){ UrunAdi = "Canon Eos 100D 18-55 mm IS STM Kit DSLR Fotoğraf Makinesi",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  1,UrunResim="4.jpg"},
                new Urun(){ UrunAdi = "Canon Eos 700D + 18-55 Is Stm + Çanta + 16 Gb Hafıza Kartı",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =false , KategoriId =  1,UrunAnasayfa = true,UrunResim="5.jpg"},

                new Urun(){ UrunAdi = "Dell Inspiron 5567 Intel Core i5 7200U 8GB 1TB R7 M445 Windows 10 Home 15.6 FHD Taşınabilir Bilgisayar FHDG20W81C", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  2,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "Lenovo Ideapad 310 Intel Core i7 7500U 12GB 1TB GT920M Windows 10 Home 15.6 Taşınabilir Bilgisayar 80TV028XTX",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 4500 , UrunStok =1200 , UrunSatistami =true , KategoriId =  2,UrunResim="1.jpg"},
                new Urun(){ UrunAdi = "Asus UX310UQ-FB418T Intel Core i7 7500U 8GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 3400 , UrunStok =0 , UrunSatistami =false , KategoriId =  2,UrunAnasayfa = true,UrunResim="3.jpg"},
                new Urun(){ UrunAdi = "Asus UX310UQ-FB418T Intel Core i7 7500U 16GB 512GB SSD GT940MX Windows 10 Home 13.3 QHD Taşınabilir Bilgisayar",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 2500 , UrunStok =600 , UrunSatistami =true , KategoriId =  2,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "Asus N580VD-DM160T Intel Core i7 7700HQ 16GB 1TB + 128GB SSD GTX1050 Windows 10 Home",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 5200 , UrunStok =500 , UrunSatistami =true , KategoriId =  2,UrunAnasayfa = true,UrunResim="4.jpg"},

                new Urun(){ UrunAdi = "LG 49UH610V 49 124 Ekran 4K Uydu Alıcılı Smart LED TV", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  3,UrunResim="1.jpg"},
                new Urun(){ UrunAdi = "Vestel 49UB8300 49 124 Ekran 4K Smart Led Tv",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 5600 , UrunStok =1200 , UrunSatistami =true , KategoriId =  3,UrunResim="1.jpg"},
                new Urun(){ UrunAdi = "Samsung 55KU7500 55 140 Ekran [4K] Uydu Alıcılı Smart[Tizen] LED TV",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 3400 , UrunStok =0 , UrunSatistami =false , KategoriId = 3,UrunAnasayfa = true,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "LG 55UH615V 55 140 Ekran 4K Uydu Alıcılı Smart Wi-Fi [webOS 3.0] LED TV",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 2500 , UrunStok =600 , UrunSatistami =true , KategoriId =  3,UrunResim="3.jpg"},
                new Urun(){ UrunAdi = "Sony Kd-55Xd7005B 55 140 Ekran [4K] Uydu Alıcılı Smart LED TV",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 5200 , UrunStok =500 , UrunSatistami =true , KategoriId =  3,UrunAnasayfa = true,UrunResim="4.jpg"},

                new Urun(){ UrunAdi = "Apple iPhone 6 32 GB (Apple Türkiye Garantili)", UrunFiyat = 1200 , UrunStok =500 , UrunSatistami =true , KategoriId =  4,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "Apple iPhone 7 32 GB (Apple Türkiye Garantili)",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 5600 , UrunStok =1200 , UrunSatistami =true , KategoriId =  4,UrunResim="1.jpg"},
                new Urun(){ UrunAdi = "Apple iPhone 6S 32 GB (Apple Türkiye Garantili)",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 3400 , UrunStok =0 , UrunSatistami =false , KategoriId = 4,UrunAnasayfa = true,UrunResim="2.jpg"},
                new Urun(){ UrunAdi = "Case 4U Manyetik Mıknatıslı Araç İçi Telefon Tutucu",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 2500 , UrunStok =600 , UrunSatistami =true , KategoriId =  4,UrunResim="3.jpg"},
                new Urun(){ UrunAdi = "Xiaomi Mi 5S 64GB (İthalatçı Garantili)",UrunAciklama = "Kullanmayı çok seveceğiniz ergonomik tasarım Optik vizör, çekiminizi oluşturmanıza ve tahmin etmenize olanak tanıyarak her zaman anın arkasındaki duyguyu yakalamak için hazır olmanızı sağlar. Sezgisel kullanımlı kullanıcı dostu kontrolleri ve görüntüyü incelemek için 7,5 cm'lik (3 inç) geniş LCD ekranıyla EOS 1200D'yi kullanması çok keyiflidir.", UrunFiyat = 5200 , UrunStok =500 , UrunSatistami =true , KategoriId =  4,UrunAnasayfa = true,UrunResim="5.jpg"},

            };

            foreach (var item in Urunler)
            {
                context.Urunler.Add(item);
            }
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}