using Enities;
using System.Data.Entity;

namespace Data
{
    public partial class FunkoPopContext : DbContext
    {
        public FunkoPopContext()
            : base("name=FunkoPopDbConnection")
        { 
            // Deshabilitar Lazy Loading para evitar redundancias
            this.Configuration.LazyLoadingEnabled = false;
        }

    public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Sale_Detail> Sale_Detail { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Postal_code)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Collection>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Collection>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Collection>()
                .Property(e => e.Url_image)
                .IsUnicode(false);

            modelBuilder.Entity<Collection>()
                .Property(e => e.Ref_image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Url_image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Ref_image)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.CITY)
                .WithRequired(e => e.PROVINCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Payment_total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.IdTransaction)
                .IsUnicode(false);

            modelBuilder.Entity<Sale_Detail>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
