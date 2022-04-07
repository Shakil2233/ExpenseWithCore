﻿// <auto-generated />
using System;
using ExcelAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcelAssignment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220406175054_newmigrations")]
    partial class newmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExcelAssignment.Models.Expense", b =>
                {
                    b.Property<int>("ExId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ExAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExCategoryId_FK")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExId");

                    b.HasIndex("ExCategoryId_FK");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExcelAssignment.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("ExCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExCategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ExCategoryId");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("ExcelAssignment.Models.Expense", b =>
                {
                    b.HasOne("ExcelAssignment.Models.ExpenseCategory", "ExpenseCategories")
                        .WithMany("Expenses")
                        .HasForeignKey("ExCategoryId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseCategories");
                });

            modelBuilder.Entity("ExcelAssignment.Models.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}