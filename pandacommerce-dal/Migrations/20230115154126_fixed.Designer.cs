﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pandacommerce_dal.Data;

#nullable disable

namespace pandacommercedal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230115154126_fixed")]
    partial class @fixed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("pandacommerce_dal.Model.NavCategory", b =>
                {
                    b.Property<int>("NavCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NavCategoryId"));

                    b.Property<string>("NavCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NavCategoryId");

                    b.ToTable("navCategories");
                });

            modelBuilder.Entity("pandacommerce_dal.Model.Product", b =>
                {
                    b.Property<int>("product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_Id"));

                    b.Property<int>("categoryid")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("product_Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("pandacommerce_dal.Model.ProductCategory", b =>
                {
                    b.Property<int>("categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryid"));

                    b.Property<string>("categoryname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryid");

                    b.ToTable("productCategories");
                });
#pragma warning restore 612, 618
        }
    }
}