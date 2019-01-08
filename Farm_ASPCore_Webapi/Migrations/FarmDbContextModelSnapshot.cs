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

                    b.Property<int>("FarmId");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Cultivations");
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

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FarmId");

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

                    b.Property<int>("DaysOfWork");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("EndOfContract");

                    b.Property<int>("FarmId");

                    b.Property<string>("FirstName");

                    b.Property<int>("HoursPerDay");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("StartOfContract");

                    b.Property<float>("UsdPerHour");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.ToTable("Workers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Worker");
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Driver", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Worker");


                    b.ToTable("Driver");

                    b.HasDiscriminator().HasValue("Driver");

                    b.HasData(
                        new { Id = 1, DaysOfWork = 0, EndOfContract = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, HoursPerDay = 0, StartOfContract = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 0f }
                    );
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Farmer", b =>
                {
                    b.HasBaseType("Farm_ASPCore_Webapi.Models.Worker");


                    b.ToTable("Farmer");

                    b.HasDiscriminator().HasValue("Farmer");

                    b.HasData(
                        new { Id = 2, DaysOfWork = 0, EndOfContract = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), FarmId = 1, HoursPerDay = 0, StartOfContract = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), UsdPerHour = 0f }
                    );
                });

            modelBuilder.Entity("Farm_ASPCore_Webapi.Models.Cultivation", b =>
                {
                    b.HasOne("Farm_ASPCore_Webapi.Models.Farm", "Farm")
                        .WithMany("Cultivations")
                        .HasForeignKey("FarmId")
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
#pragma warning restore 612, 618
        }
    }
}
