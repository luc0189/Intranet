﻿// <auto-generated />
using System;
using Intranet.web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intranet.web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200819203608_Solutionaddsons")]
    partial class Solutionaddsons
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Intranet.web.Data.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int?>("SiteHeadquartersId");

                    b.HasKey("Id");

                    b.HasIndex("SiteHeadquartersId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.CajaCompensacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CajaCompensacions");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreditEntitiesId");

                    b.Property<int>("DeadlinePay")
                        .HasMaxLength(50);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("NumberL")
                        .HasMaxLength(90);

                    b.Property<int>("Quotmonthly")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TotalPrice")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CreditEntitiesId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.CreditEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CreditEntities");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<int?>("EpsId");

                    b.Property<int?>("PensionId");

                    b.Property<int?>("PositionEmployeeId");

                    b.Property<string>("UserId");

                    b.Property<int?>("cajaCompensacionId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("EpsId");

                    b.HasIndex("PensionId");

                    b.HasIndex("PositionEmployeeId");

                    b.HasIndex("UserId");

                    b.HasIndex("cajaCompensacionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Endowment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasMaxLength(10);

                    b.Property<DateTime>("DateDelivery");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Endowments");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Eps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Eps");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("ExamsTypeId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ExamsTypeId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.ExamsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("ExamsTypes");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Pension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Pensions");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.PersonContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("relationship")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PersonContacts");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.PositionEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("PositionEmployees");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.purchasing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Purchasings");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Recursoshumanos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recursoshumanos");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.SiteHeadquarters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SiteHeadquarters");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Sons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datebirth")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sons");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.StoreLeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StoreLeaders");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<bool>("Arl")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("License");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Movil")
                        .HasMaxLength(10);

                    b.Property<string>("NivelEducation")
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Rh")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SiteBirth")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SiteExpedition")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.UserImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("UserImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Area", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.SiteHeadquarters", "SiteHeadquarters")
                        .WithMany("Areas")
                        .HasForeignKey("SiteHeadquartersId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Credit", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.CreditEntities", "CreditEntities")
                        .WithMany("Credits")
                        .HasForeignKey("CreditEntitiesId");

                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany("Credits")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Employee", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Area", "Area")
                        .WithMany("Employees")
                        .HasForeignKey("AreaId");

                    b.HasOne("Intranet.web.Data.Entities.Eps", "Eps")
                        .WithMany("Employees")
                        .HasForeignKey("EpsId");

                    b.HasOne("Intranet.web.Data.Entities.Pension", "Pension")
                        .WithMany("Employees")
                        .HasForeignKey("PensionId");

                    b.HasOne("Intranet.web.Data.Entities.PositionEmployee", "PositionEmployee")
                        .WithMany("Employees")
                        .HasForeignKey("PositionEmployeeId");

                    b.HasOne("Intranet.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Intranet.web.Data.Entities.CajaCompensacion", "cajaCompensacion")
                        .WithMany("Employees")
                        .HasForeignKey("cajaCompensacionId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Endowment", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany("Endowments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Exams", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany("Exams")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Intranet.web.Data.Entities.ExamsType", "ExamsType")
                        .WithMany("Exams")
                        .HasForeignKey("ExamsTypeId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Manager", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.PersonContact", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany("PersonContacts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.purchasing", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Recursoshumanos", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.Sons", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany("Sons")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.StoreLeader", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Intranet.web.Data.Entities.UserImages", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Intranet.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Intranet.web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
