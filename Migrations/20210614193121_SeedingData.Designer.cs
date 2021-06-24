﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210614193121_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "South Africa",
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 887, DateTimeKind.Local).AddTicks(2438),
                            Name = "Johannesburg"
                        },
                        new
                        {
                            Id = 2,
                            Country = "South Africa",
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 921, DateTimeKind.Local).AddTicks(2691),
                            Name = "Cape Town"
                        },
                        new
                        {
                            Id = 3,
                            Country = "South Africa",
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 921, DateTimeKind.Local).AddTicks(2722),
                            Name = "Nelspruit"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.FurnishingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FurnishingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2115),
                            Name = "Fully"
                        },
                        new
                        {
                            Id = 2,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2855),
                            Name = "Semi"
                        },
                        new
                        {
                            Id = 3,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2861),
                            Name = "Unfurnished"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BHK")
                        .HasColumnType("int");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<int>("BuiltArea")
                        .HasColumnType("int");

                    b.Property<int>("CarpetArea")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstPossesionOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorNo")
                        .HasColumnType("int");

                    b.Property<int>("FurnishingTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Gated")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainEntrance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maintanance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("ReadyToMove")
                        .HasColumnType("bit");

                    b.Property<int>("Security")
                        .HasColumnType("int");

                    b.Property<int>("SellRent")
                        .HasColumnType("int");

                    b.Property<int>("TotalFloor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("FurnishingTypeId");

                    b.HasIndex("PostedBy");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1 Street",
                            Age = 2,
                            BHK = 1,
                            Bathrooms = 2,
                            BuiltArea = 1200,
                            CarpetArea = 900,
                            CityId = 1,
                            Description = "2 BHK, 2 Bathroom, 1 Car Parking",
                            EstPossesionOn = new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(6200),
                            FloorNo = 3,
                            FurnishingTypeId = 1,
                            Gated = true,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(6648),
                            MainEntrance = "East",
                            Maintanance = 300,
                            Name = "White House",
                            PostedBy = "abcde",
                            Price = 5000.0,
                            PropertyTypeId = 1,
                            ReadyToMove = false,
                            Security = 4,
                            SellRent = 1,
                            TotalFloor = 8
                        },
                        new
                        {
                            Id = 2,
                            Address = "1 Street",
                            Age = 2,
                            BHK = 1,
                            Bathrooms = 2,
                            BuiltArea = 1200,
                            CarpetArea = 900,
                            CityId = 2,
                            Description = "2 BHK, 2 Bathroom, 1 Car Parking",
                            EstPossesionOn = new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(7368),
                            FloorNo = 3,
                            FurnishingTypeId = 2,
                            Gated = true,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(7371),
                            MainEntrance = "East",
                            Maintanance = 300,
                            Name = "Pandora",
                            PostedBy = "abcde",
                            Price = 5000.0,
                            PropertyTypeId = 2,
                            ReadyToMove = false,
                            Security = 4,
                            SellRent = 2,
                            TotalFloor = 8
                        });
                });

            modelBuilder.Entity("WebAPI.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(9214),
                            Name = "Duplex"
                        },
                        new
                        {
                            Id = 2,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(321),
                            Name = "House"
                        },
                        new
                        {
                            Id = 3,
                            LastUpdatedBy = "abcde",
                            LastUpdatedOn = new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(334),
                            Name = "Apartment"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Photo", b =>
                {
                    b.HasOne("WebAPI.Models.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.HasOne("WebAPI.Models.City", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.FurnishingType", "FurnishingType")
                        .WithMany()
                        .HasForeignKey("FurnishingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("PostedBy");

                    b.HasOne("WebAPI.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("FurnishingType");

                    b.Navigation("PropertyType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.City", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}