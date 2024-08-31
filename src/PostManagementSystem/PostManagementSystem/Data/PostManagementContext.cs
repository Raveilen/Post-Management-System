using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Models;

namespace PostManagementSystem.Data
{
    public class PostManagementContext : IdentityDbContext
    {
        public PostManagementContext(DbContextOptions<PostManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Delivery>()
                .HasOne(d => d.SenderPostOffice)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Delivery>()
                .HasOne(d => d.ReceiverPostOffice)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Delivery>()
                .HasOne(d => d.Status)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<Package>()
                .HasOne(p => p.Sender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Package>()
                .HasOne(p => p.Receiver)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Package>()
                .HasOne(p => p.Type)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }


        //tabela z userami będzie też potrzebna
    }
}
