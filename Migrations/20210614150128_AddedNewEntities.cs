using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddedNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FType",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PostedOn",
                table: "Properties",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "Possesion",
                table: "Properties",
                newName: "LastUpdatedBy");

            migrationBuilder.RenameColumn(
                name: "PType",
                table: "Properties",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "AOP",
                table: "Properties",
                newName: "PropertyTypeId");

            migrationBuilder.AlterColumn<bool>(
                name: "Gated",
                table: "Properties",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstPossesionOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FurnishingTypeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReadyToMove",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedBy",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "FurnishingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnishingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FurnishingTypeId",
                table: "Properties",
                column: "FurnishingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PostedBy",
                table: "Properties",
                column: "PostedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PropertyId",
                table: "Photos",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_PostedBy",
                table: "Properties",
                column: "PostedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_FurnishingTypes_FurnishingTypeId",
                table: "Properties",
                column: "FurnishingTypeId",
                principalTable: "FurnishingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_PostedBy",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_FurnishingTypes_FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "FurnishingTypes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Properties_FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PostedBy",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "EstPossesionOn",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FurnishingTypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ReadyToMove",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PropertyTypeId",
                table: "Properties",
                newName: "AOP");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                table: "Properties",
                newName: "PostedOn");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedBy",
                table: "Properties",
                newName: "Possesion");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "Properties",
                newName: "PType");

            migrationBuilder.AlterColumn<int>(
                name: "Gated",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "FType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[] { 1, "South Africa", 1, new DateTime(2021, 3, 9, 21, 52, 58, 390, DateTimeKind.Local).AddTicks(8492), "Johannesburg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[] { 2, "South Africa", 2, new DateTime(2021, 3, 9, 21, 52, 58, 393, DateTimeKind.Local).AddTicks(9743), "Cape Town" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[] { 3, "South Africa", 3, new DateTime(2021, 3, 9, 21, 52, 58, 393, DateTimeKind.Local).AddTicks(9784), "Nelspruit" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AOP", "Address", "BHK", "Bathrooms", "BuiltArea", "CarpetArea", "CityId", "Description", "FType", "FloorNo", "Gated", "Image", "MainEntrance", "Maintanance", "Name", "PType", "Possesion", "PostedOn", "Price", "Security", "SellRent", "TotalFloor" },
                values: new object[] { 1, 10, "1 Street", 1, 2, 1200, 900, 1, "2 BHK, 2 Bathroom, 1 Car Parking", "Fully", 3, 1, "", "East", 300, "White House", "Duplex", "Ready to move", new DateTime(2021, 3, 9, 21, 52, 58, 398, DateTimeKind.Local).AddTicks(8158), 5000.0, 4, 1, 8 });
        }
    }
}
