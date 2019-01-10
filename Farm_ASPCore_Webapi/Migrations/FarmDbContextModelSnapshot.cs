﻿// <auto-generated />
using System;
using Farm_ASPCore_Webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Farm_ASPCore_Webapi.Migrations
{
    [DbContext(typeof(FarmDbContext))]
    partial class FarmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Cultivation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("FarmId1");

                    b.Property<int>("GrainId");

                    b.HasKey("Id");

                    b.HasIndex("FarmId1");

                    b.HasIndex("GrainId");

                    b.ToTable("Cultivations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Cultivation");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Farm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Farms");

                    b.HasData(
                        new { Id = 1, Name = "Farm" }
                    );
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Grain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Grain");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysOfWork");

                    b.Property<int>("FarmId");

                    b.Property<int>("HoursPerDay");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Stable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FarmId");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Stables");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BaseSalary");

                    b.Property<int>("DaysOfWork");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("EndOfContract");

                    b.Property<int>("FarmId");

                    b.Property<string>("FirstName");

                    b.Property<int>("HoursPerDay");

                    b.Property<string>("LastName");

                    b.Property<double>("Salary");

                    b.Property<DateTime>("StartOfContract");

                    b.Property<double>("UsdPerHour");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Workers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Worker");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.CultivationComposite", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Cultivation");


                    b.ToTable("CultivationComposite");

                    b.HasDiscriminator().HasValue("CultivationComposite");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.CultivationLeaf", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Cultivation");

                    b.Property<int?>("ParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("CultivationLeaf");

                    b.HasDiscriminator().HasValue("CultivationLeaf");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Driver", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Worker");


                    b.ToTable("Driver");

                    b.HasDiscriminator().HasValue("Driver");

                    b.HasData(
                        new { Id = 1, BaseSalary = 949.0, DaysOfWork = 2, EndOfContract = new DateTime(2015, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name0", HoursPerDay = 20, LastName = "lastname0", Salary = 949.0, StartOfContract = new DateTime(2017, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 15.1 },
                        new { Id = 2, BaseSalary = 1883.6, DaysOfWork = 7, EndOfContract = new DateTime(2016, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name1", HoursPerDay = 20, LastName = "lastname1", Salary = 1883.6000000000001, StartOfContract = new DateTime(2017, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 10.99 },
                        new { Id = 3, BaseSalary = 1804.7, DaysOfWork = 22, EndOfContract = new DateTime(2015, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name2", HoursPerDay = 5, LastName = "lastname2", Salary = 1804.6999999999998, StartOfContract = new DateTime(2017, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 13.27 },
                        new { Id = 4, BaseSalary = 2075.43, DaysOfWork = 13, EndOfContract = new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name3", HoursPerDay = 17, LastName = "lastname3", Salary = 2075.4300000000003, StartOfContract = new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 7.83 },
                        new { Id = 5, BaseSalary = 7496.76, DaysOfWork = 21, EndOfContract = new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name4", HoursPerDay = 18, LastName = "lastname4", Salary = 7496.7600000000011, StartOfContract = new DateTime(2017, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 18.92 },
                        new { Id = 6, BaseSalary = 652.8, DaysOfWork = 9, EndOfContract = new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name5", HoursPerDay = 20, LastName = "lastname5", Salary = 652.8, StartOfContract = new DateTime(2015, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 1.71 },
                        new { Id = 7, BaseSalary = 3137.16, DaysOfWork = 8, EndOfContract = new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name6", HoursPerDay = 21, LastName = "lastname6", Salary = 3137.1600000000003, StartOfContract = new DateTime(2015, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 16.62 },
                        new { Id = 8, BaseSalary = 835.84, DaysOfWork = 7, EndOfContract = new DateTime(2016, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name7", HoursPerDay = 4, LastName = "lastname7", Salary = 835.84, StartOfContract = new DateTime(2015, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 17.53 },
                        new { Id = 9, BaseSalary = 1713.38, DaysOfWork = 26, EndOfContract = new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name8", HoursPerDay = 19, LastName = "lastname8", Salary = 1713.38, StartOfContract = new DateTime(2017, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 2.77 },
                        new { Id = 10, BaseSalary = 623.0, DaysOfWork = 8, EndOfContract = new DateTime(2016, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name9", HoursPerDay = 5, LastName = "lastname9", Salary = 623.0, StartOfContract = new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 6.95 }
                    );
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Farmer", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Worker");


                    b.ToTable("Farmer");

                    b.HasDiscriminator().HasValue("Farmer");

                    b.HasData(
                        new { Id = 11, BaseSalary = 1116.8, DaysOfWork = 4, EndOfContract = new DateTime(2017, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name10", HoursPerDay = 20, LastName = "lastname10", Salary = 1116.8, StartOfContract = new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 6.46 },
                        new { Id = 12, BaseSalary = 5610.72, DaysOfWork = 26, EndOfContract = new DateTime(2017, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name11", HoursPerDay = 22, LastName = "lastname11", Salary = 5610.72, StartOfContract = new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 8.76 },
                        new { Id = 13, BaseSalary = 7630.8, DaysOfWork = 20, EndOfContract = new DateTime(2015, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name12", HoursPerDay = 21, LastName = "lastname12", Salary = 7630.7999999999993, StartOfContract = new DateTime(2017, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 16.74 },
                        new { Id = 14, BaseSalary = 1636.8, DaysOfWork = 12, EndOfContract = new DateTime(2015, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name13", HoursPerDay = 6, LastName = "lastname13", Salary = 1636.8000000000002, StartOfContract = new DateTime(2017, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 14.4 },
                        new { Id = 15, BaseSalary = 2434.26, DaysOfWork = 6, EndOfContract = new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name14", HoursPerDay = 19, LastName = "lastname14", Salary = 2434.2599999999998, StartOfContract = new DateTime(2015, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 16.09 },
                        new { Id = 16, BaseSalary = 948.81, DaysOfWork = 11, EndOfContract = new DateTime(2017, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name15", HoursPerDay = 7, LastName = "lastname15", Salary = 948.81, StartOfContract = new DateTime(2016, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 4.53 },
                        new { Id = 17, BaseSalary = 816.4, DaysOfWork = 4, EndOfContract = new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name16", HoursPerDay = 10, LastName = "lastname16", Salary = 816.4, StartOfContract = new DateTime(2016, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 5.41 },
                        new { Id = 18, BaseSalary = 2911.54, DaysOfWork = 11, EndOfContract = new DateTime(2015, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name17", HoursPerDay = 14, LastName = "lastname17", Salary = 2911.54, StartOfContract = new DateTime(2017, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 15.01 },
                        new { Id = 19, BaseSalary = 2491.89, DaysOfWork = 27, EndOfContract = new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name18", HoursPerDay = 13, LastName = "lastname18", Salary = 2491.89, StartOfContract = new DateTime(2015, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 5.39 },
                        new { Id = 20, BaseSalary = 1120.88, DaysOfWork = 17, EndOfContract = new DateTime(2017, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, FirstName = "name19", HoursPerDay = 8, LastName = "lastname19", Salary = 1120.88, StartOfContract = new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 3.83 }
                    );
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Cultivation", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Farm")
                        .WithMany("Cultivations")
                        .HasForeignKey("FarmId1");

                    b.HasOne("Farm_ASPCore_Webapi.Models.Grain", "Grain")
                        .WithMany()
                        .HasForeignKey("GrainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Machine", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Farm", "Farm")
                        .WithMany("Machines")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Stable", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Farm", "Farm")
                        .WithMany("Stables")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Worker", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Farm", "Farm")
                        .WithMany("Workers")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.CultivationLeaf", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Cultivation", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
