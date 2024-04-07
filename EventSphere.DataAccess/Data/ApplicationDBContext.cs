using EventSphere.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {

        }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<ContectUS> ContectUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventCategory>().HasData(
                new EventCategory { Id = 1, Title = "Basic Birthday", Description = "Package for family get together.", Type = "Birthday", MinGuest = 10, MaxGuest = 30, Offer = "No available offer." },
                new EventCategory { Id = 2, Title = "Formal Conference", Description = "Package for official Conference.", Type = "Conference", MinGuest = 20, MaxGuest = 100, Offer = "No available offer." }


            );

            modelBuilder.Entity<ContectUS>().HasData(
                new ContectUS { Id = 1, Name = "Jon Doe", Email = "Jon@gmail.com", Phone = "01789545215", Comment = "I Love your Program very much." }
            );
        }
    }

}
