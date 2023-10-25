namespace AracKirala.Data.Entities
{
    public class AracKiralama
    {
        public int Id { get; set; } // kira ıd, alanı olacak çünkü müşteri ve araç farklı zamanlarda aynı müşteri tarafından kiralanabilir
        public int MusteriId { get; set; } // hangi müşteri 
        public int AracId { get; set; } // hangi aracı kiralar

        public DateTime KiralamaTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public decimal Tutar { get; set; }

        public Arac Arac { get; set; }
        public Musteri Musteri { get; set; }
    }

}
