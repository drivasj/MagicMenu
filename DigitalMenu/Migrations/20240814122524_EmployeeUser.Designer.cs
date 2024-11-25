﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWeb;

#nullable disable

namespace DigitalMenu.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240814122524_EmployeeUser")]
    partial class EmployeeUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Application", b =>
                {
                    b.Property<int>("IdApplication")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Display")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegisterUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdApplication");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Document")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MotherLastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegisterUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEmployee");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.EmployeeDetails", b =>
                {
                    b.Property<int>("IdEmployeeDetails")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEmployeeDetails");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Employeedetails");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Action")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Controller")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Movil")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegisterUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdMenu");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Privilege")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegisterUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Rolemenu", b =>
                {
                    b.Property<int>("IdRoleMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("IdRoleMenu");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("Rolemenu");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Roleuser", b =>
                {
                    b.Property<int>("IdRoleUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdRoleUser");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Roleuser");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastUpdateUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("PasswordUpdate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RegisterUser")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdUser");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.EmployeeDetails", b =>
                {
                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Employee", "Employee")
                        .WithOne("Employeedetails")
                        .HasForeignKey("DigitalMenu.Models.EntityAdministrator.EmployeeDetails", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Menu", b =>
                {
                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Application", "application")
                        .WithMany("menu")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("application");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Rolemenu", b =>
                {
                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Menu", "menu")
                        .WithMany("rolemenu")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Role", "role")
                        .WithMany("rolemenu")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("menu");

                    b.Navigation("role");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Roleuser", b =>
                {
                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Role", "role")
                        .WithMany("roleuser")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Models.EntityAdministrator.User", "user")
                        .WithOne("roleuser")
                        .HasForeignKey("DigitalMenu.Models.EntityAdministrator.Roleuser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.User", b =>
                {
                    b.HasOne("DigitalMenu.Models.EntityAdministrator.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("DigitalMenu.Models.EntityAdministrator.User", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Application", b =>
                {
                    b.Navigation("menu");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Employee", b =>
                {
                    b.Navigation("Employeedetails");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Menu", b =>
                {
                    b.Navigation("rolemenu");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.Role", b =>
                {
                    b.Navigation("rolemenu");

                    b.Navigation("roleuser");
                });

            modelBuilder.Entity("DigitalMenu.Models.EntityAdministrator.User", b =>
                {
                    b.Navigation("roleuser");
                });
#pragma warning restore 612, 618
        }
    }
}
