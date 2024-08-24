using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PostManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Package> Package { get; set; }
        public DbSet<Models.PostOffice> PostOffice { get; set; }
        public DbSet<Models.Address> Address { get; set; }
        public DbSet<Models.City> City { get; set; }
        public DbSet<Models.Customer> Customer { get; set; }
        public DbSet<Models.Status> Status { get; set; }
    }
}
