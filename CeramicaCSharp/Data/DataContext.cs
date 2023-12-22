using CeramicaCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CeramicaCSharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DiaryProduct> DiaryProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryProduct>()
                .HasKey(dp => new {dp.DiaryId, dp.ProductId});
            modelBuilder.Entity<DiaryProduct>()
                .HasOne(d => d.Product)
                .WithMany(dp => dp.DiaryProducts)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<DiaryProduct>()
                .HasOne(d => d.Diary)
                .WithMany(dp => dp.DiaryProducts)
                .HasForeignKey(p => p.DiaryId);
        }
    }
}
