using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellRent = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BHK = table.Column<int>(type: "int", nullable: false),
                    FType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BuiltArea = table.Column<int>(type: "int", nullable: false),
                    CarpetArea = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNo = table.Column<int>(type: "int", nullable: false),
                    TotalFloor = table.Column<int>(type: "int", nullable: false),
                    AOP = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    MainEntrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gated = table.Column<int>(type: "int", nullable: false),
                    Security = table.Column<int>(type: "int", nullable: false),
                    Maintanance = table.Column<int>(type: "int", nullable: false),
                    Possesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 9, 21, 52, 58, 390, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 9, 21, 52, 58, 393, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 9, 21, 52, 58, 393, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AOP", "Address", "BHK", "Bathrooms", "BuiltArea", "CarpetArea", "CityId", "Description", "FType", "FloorNo", "Gated", "Image", "MainEntrance", "Maintanance", "Name", "PType", "Possesion", "PostedOn", "Price", "Security", "SellRent", "TotalFloor" },
                values: new object[] { 1, 10, "1 Street", 1, 2, 1200, 900, 1, "2 BHK, 2 Bathroom, 1 Car Parking", "Fully", 3, 1, "", "East", 300, "White House", "Duplex", "Ready to move", new DateTime(2021, 3, 9, 21, 52, 58, 398, DateTimeKind.Local).AddTicks(8158), 5000.0, 4, 1, 8 });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 4, 22, 41, 29, 464, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 4, 22, 41, 29, 494, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2021, 3, 4, 22, 41, 29, 494, DateTimeKind.Local).AddTicks(3728));
        }
    }
}
