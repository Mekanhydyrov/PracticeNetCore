using Microsoft.EntityFrameworkCore;
using PracticeNetCore.Entities;

namespace PracticeNetCore.Contexts
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-CTHI0CB; database=PracticNetCoreDB; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>().HasMany(I => I.urunKategoris).WithOne(I => I.Urun).HasForeignKey(I => I.UrunId);
            modelBuilder.Entity<Kategori>().HasMany(I=>I.urunKategoris).WithOne(I=>I.Kategori).HasForeignKey(I => I.KategoriId);

            modelBuilder.Entity<UrunKategori>().HasIndex(I => new
            {
                I.KategoriId,
                I.UrunId
            }).IsUnique();
        }

        public DbSet<UrunKategori> UrunKategoris { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
    }
}
