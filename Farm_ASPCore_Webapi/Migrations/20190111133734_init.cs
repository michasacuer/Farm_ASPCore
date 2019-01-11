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
                    Grain = table.Column<int>(nullable: false),
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
                    { 19, 1176.0, 4, "Farmer", new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name18", 10, 1, "lastname18", 1176.0, new DateTime(2017, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.4 },
                    { 18, 899.0, 13, "Farmer", new DateTime(2017, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name17", 2, 1, "lastname17", 899.0, new DateTime(2015, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.5 },
                    { 17, 1050.24, 3, "Farmer", new DateTime(2015, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name16", 14, 1, "lastname16", 1050.24, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.72 },
                    { 16, 4062.75, 25, "Farmer", new DateTime(2015, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name15", 19, 1, "lastname15", 4062.75, new DateTime(2016, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.29 },
                    { 15, 605.1, 3, "Farmer", new DateTime(2015, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name14", 5, 1, "lastname14", 605.1, new DateTime(2017, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.34 },
                    { 14, 1800.64, 28, "Farmer", new DateTime(2017, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name13", 8, 1, "lastname13", 1800.64, new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.36 },
                    { 13, 1350.0, 20, "Farmer", new DateTime(2016, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name12", 5, 1, "lastname12", 1350.0, new DateTime(2016, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5 },
                    { 12, 1474.2, 4, "Farmer", new DateTime(2016, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name11", 15, 1, "lastname11", 1474.2, new DateTime(2016, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.57 },
                    { 20, 3438.66, 22, "Farmer", new DateTime(2017, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name19", 17, 1, "lastname19", 3438.66, new DateTime(2016, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.59 },
                    { 11, 797.25, 15, "Farmer", new DateTime(2015, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name10", 5, 1, "lastname10", 797.25, new DateTime(2015, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.63 },
                    { 9, 841.64, 4, "Driver", new DateTime(2017, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name8", 16, 0, "lastname8", 841.64, new DateTime(2016, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.76 },
                    { 8, 843.75, 15, "Driver", new DateTime(2017, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name7", 5, 0, "lastname7", 843.75, new DateTime(2016, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.65 },
                    { 7, 574.2, 4, "Driver", new DateTime(2016, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name6", 5, 0, "lastname6", 574.2, new DateTime(2017, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.46 },
                    { 6, 1956.72, 18, "Driver", new DateTime(2015, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name5", 22, 0, "lastname5", 1956.72, new DateTime(2017, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.07 },
                    { 5, 397.92, 7, "Driver", new DateTime(2015, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name4", 9, 0, "lastname4", 397.92, new DateTime(2015, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.84 },
                    { 4, 3106.92, 28, "Driver", new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name3", 8, 0, "lastname3", 3106.92, new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.33 },
                    { 3, 2866.68, 28, "Driver", new DateTime(2017, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name2", 6, 0, "lastname2", 2866.6800000000003, new DateTime(2016, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.01 },
                    { 2, 3170.46, 11, "Driver", new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name1", 18, 0, "lastname1", 3170.46, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.27 },
                    { 10, 5097.0, 30, "Driver", new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name9", 16, 0, "lastname9", 5097.0, new DateTime(2015, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.9 },
                    { 1, 4349.3, 23, "Driver", new DateTime(2016, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "name0", 10, 0, "lastname0", 4349.2999999999993, new DateTime(2017, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.41 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivations_FarmId1",
                table: "Cultivations",
                column: "FarmId1");

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
