using ListProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace Model.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }

    }
}
