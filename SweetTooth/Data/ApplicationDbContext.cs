using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Models;

namespace SweetTooth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //global reference for all models so they can be globally accessible
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems{ get; set; }

        public DbSet<Order> Orders{ get; set; }

        public DbSet<OrderItem> OrderItems{ get; set; }

        public DbSet<Product> Products{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}