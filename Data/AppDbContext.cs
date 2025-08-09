using Microsoft.EntityFrameworkCore;
using OrganicForm.Models;

namespace OrganicForm.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //validation for decimals
            modelBuilder.Entity<OrderDetails>()
                .Property(d => d.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetails>()
                .Property(d => d.Quantity).HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}
