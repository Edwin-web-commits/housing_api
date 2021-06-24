using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "South Africa", "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 887, DateTimeKind.Local).AddTicks(2438), "Johannesburg" },
                    { 2, "South Africa", "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 921, DateTimeKind.Local).AddTicks(2691), "Cape Town" },
                    { 3, "South Africa", "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 921, DateTimeKind.Local).AddTicks(2722), "Nelspruit" }
                });

            migrationBuilder.InsertData(
                table: "FurnishingTypes",
                columns: new[] { "Id", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2115), "Fully" },
                    { 2, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2855), "Semi" },
                    { 3, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(2861), "Unfurnished" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(9214), "Duplex" },
                    { 2, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(321), "House" },
                    { 3, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 924, DateTimeKind.Local).AddTicks(334), "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Address2", "Age", "BHK", "Bathrooms", "BuiltArea", "CarpetArea", "CityId", "Description", "EstPossesionOn", "FloorNo", "FurnishingTypeId", "Gated", "LastUpdatedBy", "LastUpdatedOn", "MainEntrance", "Maintanance", "Name", "PostedBy", "Price", "PropertyTypeId", "ReadyToMove", "Security", "SellRent", "TotalFloor" },
                values: new object[] { 1, "1 Street", null, 2, 1, 2, 1200, 900, 1, "2 BHK, 2 Bathroom, 1 Car Parking", new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(6200), 3, 1, true, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(6648), "East", 300, "White House", "abcde", 5000.0, 1, false, 4, 1, 8 });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Address2", "Age", "BHK", "Bathrooms", "BuiltArea", "CarpetArea", "CityId", "Description", "EstPossesionOn", "FloorNo", "FurnishingTypeId", "Gated", "LastUpdatedBy", "LastUpdatedOn", "MainEntrance", "Maintanance", "Name", "PostedBy", "Price", "PropertyTypeId", "ReadyToMove", "Security", "SellRent", "TotalFloor" },
                values: new object[] { 2, "1 Street", null, 2, 1, 2, 1200, 900, 2, "2 BHK, 2 Bathroom, 1 Car Parking", new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(7368), 3, 2, true, "abcde", new DateTime(2021, 6, 14, 22, 31, 19, 923, DateTimeKind.Local).AddTicks(7371), "East", 300, "Pandora", "abcde", 5000.0, 2, false, 4, 2, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
