namespace AracKirala.Data.Entities
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string? Adres { get; set; }
        public string Telefon { get; set; }
        public string EhliyetNo { get; set; }

        //public List<Arac> Araclar { get; set; }

        // bir mğşteri birden fazla kez araç kiralayabilir
        //müşterti ile araç arasındaki çok a çok ilişkiyi araç kiralama tablosu sağlar.
        public List<AracKiralama> KiralananAraclar { get; set; } = new List<AracKiralama>();

    }
}
