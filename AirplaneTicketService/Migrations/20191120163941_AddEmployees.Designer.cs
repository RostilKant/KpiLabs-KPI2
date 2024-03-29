﻿// <auto-generated />
using System;
using AirplaneTicketService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirplaneTicketService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191120163941_AddEmployees")]
    partial class AddEmployees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirplaneTicketService.Models.Employee", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("int");

                    b.HasIndex("PlaneId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DayOfLastRepair")
                        .HasColumnType("datetime2");

                    b.Property<long>("NumOfSeats")
                        .HasColumnType("bigint");

                    b.HasKey("PlaneId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Employee", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");
                });
#pragma warning restore 612, 618
        }
    }
}
