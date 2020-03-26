﻿// <auto-generated />
using System;
using DrugManufacturing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrugManufacturing.Migrations
{
    [DbContext(typeof(DrugManufacturingContext))]
    [Migration("20200323010111_Refactoring2")]
    partial class Refactoring2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrugManufacturing.Entities.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("Form")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternationalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.DrugManufacturer", b =>
                {
                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.HasKey("DrugId", "ManufacturerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("DrugManufacturer");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApplicant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsManufacturer")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.Applicant", b =>
                {
                    b.HasOne("DrugManufacturing.Entities.User", "User")
                        .WithOne("Applicant")
                        .HasForeignKey("DrugManufacturing.Entities.Applicant", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrugManufacturing.Entities.Drug", b =>
                {
                    b.HasOne("DrugManufacturing.Entities.Applicant", "Applicant")
                        .WithMany("Drugs")
                        .HasForeignKey("ApplicantId");
                });

            modelBuilder.Entity("DrugManufacturing.Entities.DrugManufacturer", b =>
                {
                    b.HasOne("DrugManufacturing.Entities.Drug", "Drug")
                        .WithMany("DrugManufacturers")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugManufacturing.Entities.Manufacturer", "Manufacturer")
                        .WithMany("DrugManufacturers")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrugManufacturing.Entities.Manufacturer", b =>
                {
                    b.HasOne("DrugManufacturing.Entities.User", "User")
                        .WithOne("Manufacturer")
                        .HasForeignKey("DrugManufacturing.Entities.Manufacturer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
