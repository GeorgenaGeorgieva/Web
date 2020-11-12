namespace FriendsAdventure.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class FriendsAdventureDbContext : DbContext
    {
        public FriendsAdventureDbContext()
        {
        }

        public FriendsAdventureDbContext(DbContextOptions<FriendsAdventureDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
