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
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Property> Properties {get; set;}
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

            builder.Entity<Property>().HasData(
                new Property
                {
                    Id=1,
                    SellRent=1,
                    Name="White House",
                    PType="Duplex",
                    BHK=1,
                    FType="Fully",
                    Price=5000,
                    BuiltArea=1200,
                    CarpetArea=900,
                    Image="",
                    Address="1 Street",
                    CityId=1,
                    Description="2 BHK, 2 Bathroom, 1 Car Parking",
                    FloorNo=3,
                    TotalFloor=8,
                    AOP=10,
                    Bathrooms=2,
                    MainEntrance="East",
                    Gated=1,
                    Security=4,
                    Maintanance=300,
                    Possesion= "Ready to move",
                    PostedOn=DateTime.Now
                });

        }
        
    }
}
