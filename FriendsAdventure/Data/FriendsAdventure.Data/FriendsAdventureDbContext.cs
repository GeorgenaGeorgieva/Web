namespace FriendsAdventure.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class FriendsAdventureDbContext : IdentityDbContext<User>
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
        public DbSet<Image> Images { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasMany(o => o.ProductQuantities)
                .WithOne(pq => pq.Order)
                .HasForeignKey(pq => pq.OrderId);

            builder.Entity<Product>()
                .HasMany(p => p.ProductQuantities)
                .WithOne(pq => pq.Product)
                .HasForeignKey(pq => pq.ProductId);

            builder.Entity<Event>()
                .HasMany(e => e.Images)
                .WithOne(i => i.Event)
                .HasForeignKey(i => i.EventId);

            builder.Entity<Theme>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Theme)
                .HasForeignKey(c => c.ThemeId);

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}
