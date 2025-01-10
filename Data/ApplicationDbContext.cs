using Microsoft.EntityFrameworkCore;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
   
}
