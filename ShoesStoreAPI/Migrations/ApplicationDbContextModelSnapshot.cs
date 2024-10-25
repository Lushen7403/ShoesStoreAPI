﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoesStoreAPI.Data;

#nullable disable

namespace ShoesStoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoesStoreAPI.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Binh Luc, Ha Nam",
                            Email = "tudepzai@gmail.com",
                            Name = "Nguyen Van Tu",
                            Password = "123456",
                            Role = "Admin",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Chi Linh, Hai Duong",
                            Email = "binhboong@gmail.com",
                            Name = "Ngo Van Binh",
                            Password = "123456",
                            Role = "Customer",
                            UserName = "binhboong"
                        });
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Addidas"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "Nike"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "Gucci"
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "MLB"
                        });
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoroies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Giày thể thao"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Giày boot"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Giày cao gót"
                        });
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ShoeId");

                    b.HasIndex("ShoeId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Shoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 2,
                            CategoryId = 1,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Giày đẹp, hiện đại, phù hợp vận động thể thao",
                            ImageUrl = "nikeair1.png",
                            Name = "Giày thể thao nam Nike Air Force 1",
                            Price = 100.0,
                            Quantity = 1000,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            CategoryId = 1,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Giày thể thao nam kiểu dáng hiện đại, đi êm",
                            ImageUrl = "adidasrunfalcon.png",
                            Name = "Giày thể thao nam Adidas Runfalcon",
                            Price = 79.0,
                            Quantity = 500,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 2,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Giày boot nữ hiện dại, sang trọng, quý tộc",
                            ImageUrl = "gucciblackrubber.png",
                            Name = "Giày Boot Nữ Gucci Black Rubber Horsebit",
                            Price = 150.0,
                            Quantity = 200,
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Order", b =>
                {
                    b.HasOne("ShoesStoreAPI.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("ShoesStoreAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoesStoreAPI.Models.Shoe", "Shoe")
                        .WithMany()
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Shoe");
                });

            modelBuilder.Entity("ShoesStoreAPI.Models.Shoe", b =>
                {
                    b.HasOne("ShoesStoreAPI.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoesStoreAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
