﻿// <auto-generated />
using System;
using ITG_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adi
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITG_Project.Models.BillModel", b =>
                {
                    b.Property<int>("billId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("billId"));

                    b.Property<int>("billedproductproductId")
                        .HasColumnType("integer");

                    b.Property<int>("retailerId")
                        .HasColumnType("integer");

                    b.Property<int>("supplierId")
                        .HasColumnType("integer");

                    b.Property<int>("totalAmount")
                        .HasColumnType("integer");

                    b.HasKey("billId");

                    b.HasIndex("billedproductproductId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ITG_Project.Models.ProductModel", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("productId"));

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<string>("productImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("productName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("supplierId")
                        .HasColumnType("integer");

                    b.HasKey("productId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ITG_Project.Models.RetailerModel", b =>
                {
                    b.Property<int>("retailerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("retailerId"));

                    b.Property<string>("email")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("retailerId");

                    b.ToTable("Retailers");
                });

            modelBuilder.Entity("ITG_Project.Models.SupplierModel", b =>
                {
                    b.Property<int>("supplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("supplierId"));

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("productId")
                        .HasColumnType("integer");

                    b.HasKey("supplierId");

                    b.HasIndex("productId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ITG_Project.Models.BillModel", b =>
                {
                    b.HasOne("ITG_Project.Models.ProductModel", "billedproduct")
                        .WithMany()
                        .HasForeignKey("billedproductproductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("billedproduct");
                });

            modelBuilder.Entity("ITG_Project.Models.SupplierModel", b =>
                {
                    b.HasOne("ITG_Project.Models.ProductModel", "product")
                        .WithMany()
                        .HasForeignKey("productId");

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
