using Microsoft.EntityFrameworkCore;
using CustomerOnboardingApi.Models;

namespace CustomerOnboardingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
