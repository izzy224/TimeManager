﻿// <auto-generated />
using System;
using ASPBackend.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220331181510_ChangedColumnName")]
    partial class ChangedColumnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASPBackend.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrencyId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ASPBackend.Models.ManagementEntity", b =>
                {
                    b.Property<int>("ManagementEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagementEntityId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ManagementEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("ManagementEntities");
                });

            modelBuilder.Entity("ASPBackend.Models.TimeSchedule", b =>
                {
                    b.Property<int>("TimeScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeScheduleId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManagementEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeScheduleId");

                    b.HasIndex("ManagementEntityId");

                    b.ToTable("TimeSchedules");
                });

            modelBuilder.Entity("ASPBackend.Models.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ManagementEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ToDoStatusId")
                        .HasColumnType("int");

                    b.HasKey("ToDoId");

                    b.HasIndex("ManagementEntityId");

                    b.HasIndex("ToDoStatusId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("ASPBackend.Models.ToDoStatus", b =>
                {
                    b.Property<int>("ToDoStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoStatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToDoStatusId");

                    b.ToTable("ToDoStatuses");
                });

            modelBuilder.Entity("ASPBackend.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TransactionCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("TransactionCategoryId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ASPBackend.Models.TransactionCategory", b =>
                {
                    b.Property<int>("TransactionCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionCategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionCategoryId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("TransactionCategories");
                });

            modelBuilder.Entity("ASPBackend.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("ASPBackend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASPBackend.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ASPBackend.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletId"), 1L, 1);

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("ASPBackend.Models.ManagementEntity", b =>
                {
                    b.HasOne("ASPBackend.Models.User", "User")
                        .WithMany("ManagementEntities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASPBackend.Models.TimeSchedule", b =>
                {
                    b.HasOne("ASPBackend.Models.ManagementEntity", "ManagementEntity")
                        .WithMany()
                        .HasForeignKey("ManagementEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagementEntity");
                });

            modelBuilder.Entity("ASPBackend.Models.ToDo", b =>
                {
                    b.HasOne("ASPBackend.Models.ManagementEntity", "ManagementEntity")
                        .WithMany()
                        .HasForeignKey("ManagementEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBackend.Models.ToDoStatus", "ToDoStatus")
                        .WithMany("Todos")
                        .HasForeignKey("ToDoStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagementEntity");

                    b.Navigation("ToDoStatus");
                });

            modelBuilder.Entity("ASPBackend.Models.Transaction", b =>
                {
                    b.HasOne("ASPBackend.Models.TransactionCategory", "TransactionCategory")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBackend.Models.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionCategory");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("ASPBackend.Models.TransactionCategory", b =>
                {
                    b.HasOne("ASPBackend.Models.TransactionType", "TransactionType")
                        .WithMany("TransactionCategories")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("ASPBackend.Models.User", b =>
                {
                    b.HasOne("ASPBackend.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ASPBackend.Models.Wallet", b =>
                {
                    b.HasOne("ASPBackend.Models.Currency", "Currency")
                        .WithMany("Wallets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBackend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASPBackend.Models.Currency", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("ASPBackend.Models.ToDoStatus", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("ASPBackend.Models.TransactionCategory", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ASPBackend.Models.TransactionType", b =>
                {
                    b.Navigation("TransactionCategories");
                });

            modelBuilder.Entity("ASPBackend.Models.User", b =>
                {
                    b.Navigation("ManagementEntities");
                });

            modelBuilder.Entity("ASPBackend.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ASPBackend.Models.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
