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
                name: "Cultivations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmId = table.Column<int>(nullable: false),
                    Grain = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultivations_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivations_Cultivations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Cultivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Kind = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Farm" });

            migrationBuilder.InsertData(
                table: "Stables",
                columns: new[] { "Id", "FarmId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "BaseSalary", "DaysOfWork", "Discriminator", "EndOfContract", "FarmId", "FirstName", "HoursPerDay", "Kind", "LastName", "Salary", "StartOfContract", "UsdPerHour" },
                values: new object[,]
                {
                    { 19, 10119.93, 27, "Farmer", new DateTime(2017, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name18", 21, 1, "lastname18", 10119.929999999998, new DateTime(2015, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.79 },
                    { 18, 1884.14, 26, "Farmer", new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name17", 11, 1, "lastname17", 1884.14, new DateTime(2015, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.49 },
                    { 17, 2851.26, 11, "Farmer", new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name16", 18, 1, "lastname16", 2851.2599999999998, new DateTime(2015, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.37 },
                    { 16, 1446.9, 15, "Farmer", new DateTime(2017, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name15", 6, 1, "lastname15", 1446.9, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.41 },
                    { 15, 847.59, 3, "Farmer", new DateTime(2016, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name14", 7, 1, "lastname14", 847.59, new DateTime(2016, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.79 },
                    { 14, 2385.42, 18, "Farmer", new DateTime(2015, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name13", 13, 1, "lastname13", 2385.42, new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.63 },
                    { 13, 779.04, 6, "Farmer", new DateTime(2016, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name12", 4, 1, "lastname12", 779.04, new DateTime(2017, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.46 },
                    { 12, 1480.5, 5, "Farmer", new DateTime(2017, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name11", 10, 1, "lastname11", 1480.5, new DateTime(2017, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.61 },
                    { 20, 616.38, 21, "Farmer", new DateTime(2017, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name19", 6, 1, "lastname19", 616.38, new DateTime(2016, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.13 },
                    { 11, 1373.25, 15, "Farmer", new DateTime(2017, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name10", 5, 1, "lastname10", 1373.25, new DateTime(2017, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.31 },
                    { 9, 815.4, 28, "Driver", new DateTime(2016, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name8", 7, 0, "lastname8", 815.40000000000009, new DateTime(2015, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.4 },
                    { 8, 895.2, 3, "Driver", new DateTime(2016, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name7", 20, 0, "lastname7", 895.2, new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.17 },
                    { 7, 593.4, 5, "Driver", new DateTime(2015, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name6", 12, 0, "lastname6", 593.4, new DateTime(2015, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.14 },
                    { 6, 1163.09, 29, "Driver", new DateTime(2016, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name5", 13, 0, "lastname5", 1163.0900000000001, new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.17 },
                    { 5, 352.46, 1, "Driver", new DateTime(2017, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name4", 1, 0, "lastname4", 352.46, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.46 },
                    { 4, 3800.76, 28, "Driver", new DateTime(2016, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name3", 11, 0, "lastname3", 3800.76, new DateTime(2017, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.22 },
                    { 3, 1803.73, 13, "Driver", new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name2", 7, 0, "lastname2", 1803.73, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.03 },
                    { 2, 356.93, 1, "Driver", new DateTime(2016, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name1", 1, 0, "lastname1", 356.93, new DateTime(2017, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.93 },
                    { 10, 517.8, 8, "Driver", new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name9", 8, 0, "lastname9", 517.8, new DateTime(2017, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.7 },
                    { 1, 1717.0, 16, "Driver", new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name0", 7, 0, "lastname0", 1717.0, new DateTime(2017, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_FarmId",
                table: "Cultivations",
                column: "FarmId");

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
                name: "Farms");
        }
    }
}
