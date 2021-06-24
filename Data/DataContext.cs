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
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<FurnishingType> FurnishingTypes { get; set; }

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
                    LastUpdatedBy = "abcde",
                    LastUpdatedOn = DateTime.Now
                },
                 new City
                 {
                     Id = 2,
                     Name = "Cape Town",
                     Country = "South Africa",
                     LastUpdatedBy = "abcde",
                     LastUpdatedOn = DateTime.Now
                 },
                  new City
                  {
                      Id = 3,
                      Name = "Nelspruit",
                      Country = "South Africa",
                      LastUpdatedBy = "abcde",
                      LastUpdatedOn = DateTime.Now
                  }
                );

            builder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    SellRent = 1,
                    Name = "White House",
                    PropertyTypeId = 1,
                    BHK = 1,
                    FurnishingTypeId = 1,
                    Price = 5000,
                    BuiltArea = 1200,
                    CarpetArea = 900,
                    Address = "1 Street",
                    CityId = 1,
                    Description = "2 BHK, 2 Bathroom, 1 Car Parking",
                    FloorNo = 3,
                    TotalFloor = 8,
                    Age = 2,
                    Bathrooms = 2,
                    MainEntrance = "East",
                    Gated = true,
                    Security = 4,
                    Maintanance = 300,
                    PostedBy = "abcde",
                    EstPossesionOn = DateTime.Now,
                    PostedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now,
                    LastUpdatedBy = "abcde"
                },
                new Property
                {
                    Id = 2,
                    SellRent = 2,
                    Name = "Pandora",
                    PropertyTypeId = 2,
                    BHK = 1,
                    FurnishingTypeId = 2,
                    Price = 5000,
                    BuiltArea = 1200,
                    CarpetArea = 900,
                    Address = "1 Street",
                    CityId = 2,
                    Description = "2 BHK, 2 Bathroom, 1 Car Parking",
                    FloorNo = 3,
                    TotalFloor = 8,
                    Age = 2,
                    Bathrooms = 2,
                    MainEntrance = "East",
                    Gated = true,
                    Security = 4,
                    Maintanance = 300,
                    PostedBy = "abcde",
                    EstPossesionOn = DateTime.Now,
                    PostedOn = DateTime.Now,
                    LastUpdatedOn = DateTime.Now,
                    LastUpdatedBy = "abcde"
                }
                );
            builder.Entity<PropertyType>().HasData(
               new PropertyType
               {
                     Id=1,
                     Name ="Duplex",
                     LastUpdatedOn=DateTime.Now,
                     LastUpdatedBy="abcde",
               }, new PropertyType
               {
                   Id = 2,
                   Name = "House",
                   LastUpdatedOn = DateTime.Now,
                   LastUpdatedBy = "abcde",
               }, new PropertyType
               {
                   Id = 3,
                   Name = "Apartment",
                   LastUpdatedOn = DateTime.Now,
                   LastUpdatedBy = "abcde",
               });
            builder.Entity<FurnishingType>().HasData(
               new FurnishingType
               {
                   Id = 1,
                   Name = "Fully",
                   LastUpdatedOn = DateTime.Now,
                   LastUpdatedBy = "abcde",

               }, new FurnishingType
               {
                   Id = 2,
                   Name = "Semi",
                   LastUpdatedOn = DateTime.Now,
                   LastUpdatedBy = "abcde",

               }, new FurnishingType
               {
                   Id = 3,
                   Name = "Unfurnished",
                   LastUpdatedOn = DateTime.Now,
                   LastUpdatedBy = "abcde",

               });

        }
    }
}
