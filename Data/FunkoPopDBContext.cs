using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Enities
{
    public partial class FunkoPopDBContext : DbContext
    {
        public FunkoPopDBContext()
            : base("name=FunkoPopDBConnection")
        {
        }

        public virtual DbSet<CART> CART { get; set; }
        public virtual DbSet<CITY> CITY { get; set; }
        public virtual DbSet<CLIENT> CLIENT { get; set; }
        public virtual DbSet<COLLECTION> COLLECTION { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PROVINCE> PROVINCE { get; set; }
        public virtual DbSet<SALE> SALE { get; set; }
        public virtual DbSet<SALE_DETAIL> SALE_DETAIL { get; set; }
        public virtual DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CITY>()
                .Property(e => e.postal_code)
                .IsUnicode(false);

            modelBuilder.Entity<CITY>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECTION>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECTION>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECTION>()
                .Property(e => e.url_image)
                .IsUnicode(false);

            modelBuilder.Entity<COLLECTION>()
                .Property(e => e.ref_image)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.url_image)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.ref_image)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCE>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCE>()
                .HasMany(e => e.CITY)
                .WithRequired(e => e.PROVINCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.payment_total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SALE>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.idTransaction)
                .IsUnicode(false);

            modelBuilder.Entity<SALE_DETAIL>()
                .Property(e => e.total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<USER>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
