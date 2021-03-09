using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

           // builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Johannesburg",
                    Country = "South Africa",
                    LastUpdatedBy = 1,
                    LastUpdatedOn = DateTime.Now
                },
                 new City
                 {
                     Id = 2,
                     Name = "Cape Town",
                     Country = "South Africa",
                     LastUpdatedBy = 2,
                     LastUpdatedOn = DateTime.Now
                 },
                  new City
                  {
                      Id = 3,
                      Name = "Nelspruit",
                      Country = "South Africa",
                      LastUpdatedBy = 3,
                      LastUpdatedOn = DateTime.Now
                  }
                );
        }
        
    }
}
