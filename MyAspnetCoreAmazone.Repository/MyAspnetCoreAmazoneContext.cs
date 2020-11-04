using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyAspnetCoreAmazone.Model;

namespace MyAspnetCoreAmazone.Repository
{
    public partial class MyAspnetCoreAmazoneContext : DbContext
    {
        public MyAspnetCoreAmazoneContext()
        {
        }

        public MyAspnetCoreAmazoneContext(DbContextOptions<MyAspnetCoreAmazoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MyAspnetCoreAmazone;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("smallmoney");

                entity.Property(e => e.Rrp)
                    .HasColumnName("RRP")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.SellingPrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CDBDDB754F");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ToPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
