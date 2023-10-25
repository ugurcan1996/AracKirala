using AracKirala.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AracKirala.Data
{
    public class AracKiralaDBContext:DbContext
    {
        public DbSet<Arac> Araclar { get; set; }// arac kiralamak için tanımladığımız nesne
        public DbSet<AracPolice> AracPoliceler { get; set; } // araca ait trafik poliçeleri için tanımladığımız nesne
        public DbSet<Musteri> Musteriler { get; set; } // müşteri araç kiralaması yapmak için tanımladığımız nesne
        public DbSet<AracKiralama> KiralananAraclar { get; set; }// Müşteri tarafından belirli tarihlerde kiralanan araçların listesi

        public DbSet<Sirket> Sirketler { get; set; }// aracın hangi şirkete ait olduğunu tutuğumuz tablo

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FR8E4M9\\SQLEXPRESS;Database=AracKiralaDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AracPolice>().HasKey(x=> x.PoliceId);
            modelBuilder
                .Entity<Arac>()
                .HasOne(x => x.Police)
                .WithOne(x => x.Arac)
                .HasForeignKey<AracPolice>(x => x.AracId);

            modelBuilder
                .Entity<Arac>()
                .HasOne(x => x.AracSirket)
                .WithMany(x => x.Araclar)
                .HasForeignKey(x => x.sirketId);


            // çok a çok ilişki nasıl yazılır
            // çoka çok tablolarda her iki tabloya 1 e çok ilişki tanımlanarak çoka çok ilişki yapılır
            modelBuilder
                .Entity<AracKiralama>()
                .HasOne(x => x.Arac) // 1 araç
                .WithMany(x => x.KiralananAraclar) // 1 den fazla kez kiralanabilir
                .HasForeignKey(x => x.AracId);// araç ile liralama arasında aracıd ilişkisi vardır

            modelBuilder
                .Entity<AracKiralama>()
                .HasOne(x => x.Musteri) // 1 müşteri
                .WithMany(x => x.KiralananAraclar) // 1 den fazla kez araç kiralayabilir
                .HasForeignKey(x => x.MusteriId);// müşteri ile kiralama arasında müşteriId ilişkisi vardır

            base.OnModelCreating(modelBuilder);
        }
    }
}
