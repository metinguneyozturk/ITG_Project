﻿// <auto-generated />
using System;
using ITG_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adi
{
    [DbContext(typeof(DataContext))]
    [Migration("20230111094314_BillModelTabelgetirme")]
    partial class BillModelTabelgetirme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("billedProductproductId")
                        .HasColumnType("integer");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<int>("totalAmount")
                        .HasColumnType("integer");

                    b.HasKey("billId");

                    b.HasIndex("billedProductproductId");

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

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("productId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ITG_Project.Models.RetailerModel", b =>
                {
                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.HasKey("phoneNumber");

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
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("productId")
                        .HasColumnType("integer");

                    b.HasKey("supplierId");

                    b.HasIndex("productId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ITG_Project.Models.BillModel", b =>
                {
                    b.HasOne("ITG_Project.Models.ProductModel", "billedProduct")
                        .WithMany()
                        .HasForeignKey("billedProductproductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("billedProduct");
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
