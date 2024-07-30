﻿// <auto-generated />
using System;
using IMD285WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMD285WebAPI.Migrations
{
    [DbContext(typeof(Imd285DbContext))]
    [Migration("20240729050623_mssql.container_migration_initial")]
    partial class mssqlcontainer_migration_initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IMD285WebAPI.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HebrewName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"),
                            HebrewName = "חלב וגבינות",
                            Name = "Milk & Cheese"
                        },
                        new
                        {
                            Id = new Guid("515fd745-63b3-4e46-8bb4-4303cdb2a4ec"),
                            HebrewName = "טואלטיקה",
                            Name = "Toiletries"
                        },
                        new
                        {
                            Id = new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"),
                            HebrewName = "בשר",
                            Name = "Meat"
                        },
                        new
                        {
                            Id = new Guid("358cc0eb-8cc9-460c-a790-b7911ddafae5"),
                            HebrewName = "ירקות ופירות",
                            Name = "Fruit & Vegetable"
                        });
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HebrewName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("51455015-f2a5-4087-8e81-1ba33c9ee4b6"),
                            CategoryId = new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"),
                            HebrewName = "קוטג",
                            Name = "Cottage"
                        },
                        new
                        {
                            Id = new Guid("c00f7014-935d-42bb-b0a8-61ecc7fbed2f"),
                            CategoryId = new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"),
                            HebrewName = "חלב 3%",
                            Name = "Milk 3 Percent"
                        },
                        new
                        {
                            Id = new Guid("c6c21008-7b7f-41af-969e-efea00794b0d"),
                            CategoryId = new Guid("baca1d06-6c48-42e9-90c8-f4ce0c092934"),
                            HebrewName = "שמנת חמוצה",
                            Name = "Sour Cream"
                        },
                        new
                        {
                            Id = new Guid("532c8209-270d-41b4-a8af-80baf532823d"),
                            CategoryId = new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"),
                            HebrewName = "נקניקיות",
                            Name = "Sausage"
                        },
                        new
                        {
                            Id = new Guid("bf0e7ef7-3ea6-4e68-800d-37d5883f4ed0"),
                            CategoryId = new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"),
                            HebrewName = "שוקיים",
                            Name = "Calves"
                        },
                        new
                        {
                            Id = new Guid("99a51df2-2f31-4637-92cc-4f6b9b51a761"),
                            CategoryId = new Guid("4a82a87f-2903-42c1-95f1-ed8428b91a50"),
                            HebrewName = "סלמון",
                            Name = "Salmon"
                        });
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.OrderItem", b =>
                {
                    b.HasOne("IMD285WebAPI.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMD285WebAPI.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Product", b =>
                {
                    b.HasOne("IMD285WebAPI.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("IMD285WebAPI.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
