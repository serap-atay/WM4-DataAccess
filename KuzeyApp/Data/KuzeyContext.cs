using KuzeyApp.Models;
using KuzeyApp.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyApp.Data
{
    public class KuzeyContext : DbContext
    {
        public KuzeyContext()
            : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-2FFKP26U;Initial Catalog=KuzeyDb;User ID=sa;Password=miraggio;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Calisan> Calisanlar{get;set;}

        public override int SaveChanges()
        {
            //veri kaydolmadan önce müdahale edip veriyi kontrol ediyoruz.
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && x.State == EntityState.Added);
            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).CreatedDate = DateTime.Now;
            }
            entries = ChangeTracker.Entries()
                 .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified);
            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).UpdatedDate = DateTime.Now;
            }
            entries = ChangeTracker.Entries()
               .Where(x => x.Entity is BaseEntity && x.State == EntityState.Deleted);
            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).DeletedDate = DateTime.Now;
                ((BaseEntity)item.Entity).IsDeleted=true;
               item.State = EntityState.Modified;
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Urun>()
                 .Property(x => x.Fiyat)
                 .HasPrecision(10, 2);//fluent api

            //modelBuilder.Entity<SiparisDetay>()
            //    .ToTable("SiparisDetayları");

            modelBuilder.Entity<SiparisDetay>()
                .HasKey(x => new { x.SiparisId, x.UrunId });//composite key
            modelBuilder.Entity<SiparisDetay>()
                .Property(x => x.Fiyat)
                .HasPrecision(10, 2);

            //modelBuilder.Entity<SiparisDetay>()
            //    .HasOne<Siparis>(sd => sd.Siparis)
            //    .WithMany(s => s.SiparisDetaylari)
            //    .HasForeignKey(x => x.SiparisId);

            //modelBuilder.Entity<SiparisDetay>()
            //    .HasOne<Urun>(u => u.Urun)
            //    .WithMany(u => u.SiparisDetaylari)
            //    .HasForeignKey(sd => sd.SiparisId);
        }
    }
}
