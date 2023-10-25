namespace AracKirala.Data.Entities
{
    public class Arac
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Modeli { get; set; }
        public string Plaka { get; set; }
        public string Km { get; set; }
        public decimal SaatlikUcret { get; set; }
        public decimal GunlukUcret { get; set; }
        public int? sirketId { get; set; }

        public AracPolice Police { get; set; }
        public Sirket? AracSirket { get; set; }

        public List<AracKiralama> KiralananAraclar { get; set; } = new List<AracKiralama>();
    }
}
