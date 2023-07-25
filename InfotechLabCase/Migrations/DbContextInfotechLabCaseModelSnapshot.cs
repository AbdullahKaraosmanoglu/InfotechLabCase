﻿// <auto-generated />
using System;
using InfotechLabCase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfotechLabCase.Migrations
{
    [DbContext(typeof(DbContextInfotechLabCase))]
    partial class DbContextInfotechLabCaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InfotechLabCase.Models.AdminModel", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AdminId");

                    b.ToTable("TblAdmin");
                });

            modelBuilder.Entity("InfotechLabCase.Models.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("TblCity");
                });

            modelBuilder.Entity("InfotechLabCase.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("AddressCustomer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerPostCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("NeighbourhoodId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("TblCustomer");
                });

            modelBuilder.Entity("InfotechLabCase.Models.DistrictModel", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictId"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictId");

                    b.ToTable("TblDistrict");
                });

            modelBuilder.Entity("InfotechLabCase.Models.ExpertCommentModel", b =>
                {
                    b.Property<int>("ExpertCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpertCommentId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ExpertComment")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExpertCommentId");

                    b.ToTable("TblExpertComment");
                });

            modelBuilder.Entity("InfotechLabCase.Models.ExpertModel", b =>
                {
                    b.Property<int>("ExpertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpertId"));

                    b.Property<string>("AddressExpert")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("ExpertName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExpertPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ExpertSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("NeighbourhoodId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ExpertId");

                    b.ToTable("TblExpert");
                });

            modelBuilder.Entity("InfotechLabCase.Models.NeighbourhoodModel", b =>
                {
                    b.Property<int>("NeighbourhoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NeighbourhoodId"));

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("NeighbourhoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NeighbourhoodId");

                    b.ToTable("TblNeighbourhood");
                });

            modelBuilder.Entity("InfotechLabCase.Models.OfferModel", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("OfferMessage")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("OfferStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OfferId");

                    b.ToTable("TblOffer");
                });

            modelBuilder.Entity("InfotechLabCase.Models.RoleModel", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("TblRole");
                });

            modelBuilder.Entity("InfotechLabCase.Models.ServiceCategoryModel", b =>
                {
                    b.Property<int>("ServiceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceCategoryId"));

                    b.Property<string>("ServiceCategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ServicePrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ServiceCategoryId");

                    b.ToTable("TblServiceCategory");
                });

            modelBuilder.Entity("InfotechLabCase.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("SystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateSystemDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("TblUser");
                });
#pragma warning restore 612, 618
        }
    }
}
