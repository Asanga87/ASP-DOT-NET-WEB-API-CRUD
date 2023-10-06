﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPILnkdn.Data;

#nullable disable

namespace WebAPILnkdn.Migrations
{
    [DbContext(typeof(APIDbContext))]
    partial class APIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPILnkdn.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Addreess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionID")
                        .HasColumnType("int");

                    b.Property<int>("SalaryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.HasIndex("SalaryID");

                    b.ToTable("people");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.PersonDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("personDetails");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("positions");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Person", b =>
                {
                    b.HasOne("WebAPILnkdn.Model.Position", "position")
                        .WithMany("people")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPILnkdn.Model.Salary", "salary")
                        .WithMany("people")
                        .HasForeignKey("SalaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("position");

                    b.Navigation("salary");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.PersonDetail", b =>
                {
                    b.HasOne("WebAPILnkdn.Model.Person", "Person")
                        .WithOne("personDetail")
                        .HasForeignKey("WebAPILnkdn.Model.PersonDetail", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Position", b =>
                {
                    b.HasOne("WebAPILnkdn.Model.Department", "department")
                        .WithMany("positions")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Department", b =>
                {
                    b.Navigation("positions");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Person", b =>
                {
                    b.Navigation("personDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Position", b =>
                {
                    b.Navigation("people");
                });

            modelBuilder.Entity("WebAPILnkdn.Model.Salary", b =>
                {
                    b.Navigation("people");
                });
#pragma warning restore 612, 618
        }
    }
}
