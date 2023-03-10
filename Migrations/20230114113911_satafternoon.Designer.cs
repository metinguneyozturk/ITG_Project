// <auto-generated />
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
    [Migration("20230114113911_satafternoon")]
    partial class satafternoon
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ITG_Project.Models.BillModel", b =>
                {
                    b.Property<int>("billId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("billId"));

                    b.Property<int>("billedproductproductId")
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

                    b.Property<int?>("RetailerModelretailerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<string>("productName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("retailerId")
                        .HasColumnType("integer");

                    b.Property<int>("supplierId")
                        .HasColumnType("integer");

                    b.HasKey("productId");

                    b.HasIndex("RetailerModelretailerId");

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
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("productId")
                        .HasColumnType("integer");

                    b.HasKey("supplierId");

                    b.HasIndex("productId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ProductModelProductModel", b =>
                {
                    b.Property<int>("retailerProductsproductId")
                        .HasColumnType("integer");

                    b.Property<int>("supplierProductsproductId")
                        .HasColumnType("integer");

                    b.HasKey("retailerProductsproductId", "supplierProductsproductId");

                    b.HasIndex("supplierProductsproductId");

                    b.ToTable("ProductModelProductModel");
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

            modelBuilder.Entity("ITG_Project.Models.ProductModel", b =>
                {
                    b.HasOne("ITG_Project.Models.RetailerModel", null)
                        .WithMany("retailerProducts")
                        .HasForeignKey("RetailerModelretailerId");
                });

            modelBuilder.Entity("ITG_Project.Models.SupplierModel", b =>
                {
                    b.HasOne("ITG_Project.Models.ProductModel", "product")
                        .WithMany()
                        .HasForeignKey("productId");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.HasOne("Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("ProductModelProductModel", b =>
                {
                    b.HasOne("ITG_Project.Models.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("retailerProductsproductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITG_Project.Models.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("supplierProductsproductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("ITG_Project.Models.RetailerModel", b =>
                {
                    b.Navigation("retailerProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
