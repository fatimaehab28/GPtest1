using Microsoft.EntityFrameworkCore;
using tbackendgp.Models;

namespace tbackendgp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<IdentityCard> IdentityCard { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyOffer> PropertyOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserTypeId)
                .HasDefaultValue(2);

            modelBuilder.Entity<Property>()
                .HasIndex(p => p.PropertyName)
                .IsUnique();

            // ✅ Mark `Address` as an owned type for `Property`
            modelBuilder.Entity<Property>()
                .OwnsOne(p => p.PropertyAddress);

            // ✅ Mark `Address` as an owned type for `PropertyOffer`
            modelBuilder.Entity<PropertyOffer>()
                .OwnsOne(o => o.PropertyAddress);

            base.OnModelCreating(modelBuilder);
        }
    }
}
