using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farm_ASPCore_Webapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmId = table.Column<int>(nullable: false),
                    HoursPerDay = table.Column<int>(nullable: false),
                    DaysOfWork = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stables_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StartOfContract = table.Column<DateTime>(nullable: false),
                    EndOfContract = table.Column<DateTime>(nullable: false),
                    UsdPerHour = table.Column<double>(nullable: false),
                    HoursPerDay = table.Column<int>(nullable: false),
                    DaysOfWork = table.Column<int>(nullable: false),
                    BaseSalary = table.Column<double>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultivations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrainId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FarmId1 = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultivations_Farms_FarmId1",
                        column: x => x.FarmId1,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cultivations_Grain_GrainId",
                        column: x => x.GrainId,
                        principalTable: "Grain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivations_Cultivations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Cultivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Farm" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "BaseSalary", "DaysOfWork", "Discriminator", "EndOfContract", "FarmId", "FirstName", "HoursPerDay", "LastName", "Salary", "StartOfContract", "UsdPerHour" },
                values: new object[,]
                {
                    { 1, 949.0, 2, "Driver", new DateTime(2015, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name0", 20, "lastname0", 949.0, new DateTime(2017, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.1 },
                    { 18, 2911.54, 11, "Farmer", new DateTime(2015, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name17", 14, "lastname17", 2911.54, new DateTime(2017, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.01 },
                    { 17, 816.4, 4, "Farmer", new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name16", 10, "lastname16", 816.4, new DateTime(2016, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.41 },
                    { 16, 948.81, 11, "Farmer", new DateTime(2017, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name15", 7, "lastname15", 948.81, new DateTime(2016, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.53 },
                    { 15, 2434.26, 6, "Farmer", new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name14", 19, "lastname14", 2434.2599999999998, new DateTime(2015, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.09 },
                    { 14, 1636.8, 12, "Farmer", new DateTime(2015, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name13", 6, "lastname13", 1636.8000000000002, new DateTime(2017, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.4 },
                    { 13, 7630.8, 20, "Farmer", new DateTime(2015, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name12", 21, "lastname12", 7630.7999999999993, new DateTime(2017, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.74 },
                    { 12, 5610.72, 26, "Farmer", new DateTime(2017, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name11", 22, "lastname11", 5610.72, new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.76 },
                    { 11, 1116.8, 4, "Farmer", new DateTime(2017, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name10", 20, "lastname10", 1116.8, new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.46 },
                    { 10, 623.0, 8, "Driver", new DateTime(2016, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name9", 5, "lastname9", 623.0, new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.95 },
                    { 9, 1713.38, 26, "Driver", new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name8", 19, "lastname8", 1713.38, new DateTime(2017, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.77 },
                    { 8, 835.84, 7, "Driver", new DateTime(2016, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name7", 4, "lastname7", 835.84, new DateTime(2015, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.53 },
                    { 7, 3137.16, 8, "Driver", new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name6", 21, "lastname6", 3137.1600000000003, new DateTime(2015, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.62 },
                    { 6, 652.8, 9, "Driver", new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name5", 20, "lastname5", 652.8, new DateTime(2015, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.71 },
                    { 5, 7496.76, 21, "Driver", new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name4", 18, "lastname4", 7496.7600000000011, new DateTime(2017, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.92 },
                    { 4, 2075.43, 13, "Driver", new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name3", 17, "lastname3", 2075.4300000000003, new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.83 },
                    { 3, 1804.7, 22, "Driver", new DateTime(2015, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name2", 5, "lastname2", 1804.6999999999998, new DateTime(2017, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 13.27 },
                    { 2, 1883.6, 7, "Driver", new DateTime(2016, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name1", 20, "lastname1", 1883.6000000000001, new DateTime(2017, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.99 },
                    { 19, 2491.89, 27, "Farmer", new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name18", 13, "lastname18", 2491.89, new DateTime(2015, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.39 },
                    { 20, 1120.88, 17, "Farmer", new DateTime(2017, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name19", 8, "lastname19", 1120.88, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.83 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_FarmId1",
                table: "Cultivations",
                column: "FarmId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_GrainId",
                table: "Cultivations",
                column: "GrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_ParentId",
                table: "Cultivations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FarmId",
                table: "Machines",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Stables_FarmId",
                table: "Stables",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FarmId",
                table: "Workers",
                column: "FarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cultivations");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Stables");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Grain");

            migrationBuilder.DropTable(
                name: "Farms");
        }
    }
}
