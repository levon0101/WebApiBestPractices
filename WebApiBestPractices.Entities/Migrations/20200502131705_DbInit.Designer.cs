﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiBestPractices.Entities;

namespace WebApiBestPractices.Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200502131705_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApiBestPractices.Entities.Model.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c01"),
                            AccountType = "Tirakal",
                            DateCreated = new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade01")
                        });
                });

            modelBuilder.Entity("WebApiBestPractices.Entities.Model.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            OwnerId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade01"),
                            Address = "Earth",
                            DateOfBirth = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Levon Mardanyan"
                        },
                        new
                        {
                            OwnerId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade02"),
                            Address = "Earth",
                            DateOfBirth = new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Grigori Mardanyan"
                        });
                });

            modelBuilder.Entity("WebApiBestPractices.Entities.Model.Account", b =>
                {
                    b.HasOne("WebApiBestPractices.Entities.Model.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
