using System;

namespace TcIdentityChecker.Models
{
    public class PersonData
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime OlumTarihi { get; set; }
        public string MedeniDurumu { get; set; }
        public string NufusIl { get; set; }
        public string NufusIlce { get; set; }
        public string MahalleKoy { get; set; }
        public int? AileSiraNo { get; set; }
        public int? BireySiraNo { get; set; }
        public int? Cilt { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
    }
}