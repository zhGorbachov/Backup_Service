﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(BackupContext))]
    [Migration("20230519204203_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdStorage")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TariffType")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("IdStorage");

                    b.HasIndex("IdUser");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataLayer.Entities.Backup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdStorage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TariffType")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("IdStorage");

                    b.HasIndex("TariffType");

                    b.ToTable("Backups");
                });

            modelBuilder.Entity("DataLayer.Entities.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UsedSize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("DataLayer.Entities.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BackupSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TariffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.HasOne("DataLayer.Entities.Storage", "Storage")
                        .WithMany("Accounts")
                        .HasForeignKey("IdStorage")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataLayer.Entities.Tariff", "Tariff")
                        .WithMany("Accounts")
                        .HasForeignKey("TariffType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Storage");

                    b.Navigation("Tariff");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Backup", b =>
                {
                    b.HasOne("DataLayer.Entities.Storage", "Storage")
                        .WithMany("Backups")
                        .HasForeignKey("IdStorage")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataLayer.Entities.Account", "Account")
                        .WithMany("Backups")
                        .HasForeignKey("TariffType")
                        .HasPrincipalKey("TariffType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.Navigation("Backups");
                });

            modelBuilder.Entity("DataLayer.Entities.Storage", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Backups");
                });

            modelBuilder.Entity("DataLayer.Entities.Tariff", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
