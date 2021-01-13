﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210113114819_RefillDeliveryDates")]
    partial class RefillDeliveryDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Domain.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CouponNumber")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CouponNumber")
                        .IsUnique();

                    b.HasIndex("TruckId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Domain.Entities.ExampleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExampleEntityListId")
                        .HasColumnType("int");

                    b.Property<int>("ExampleEnum")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ExampleEntityListId");

                    b.ToTable("ExampleEntities");
                });

            modelBuilder.Entity("Domain.Entities.ExampleEntityList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ExampleEntityLists");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("TankNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Refill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ActualDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CouponId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EndAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ExpectedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.Property<double>("StartAmount")
                        .HasColumnType("float");

                    b.Property<int>("TankState")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("Refills");
                });

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Domain.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Domain.Entities.Coupon", b =>
                {
                    b.HasOne("Domain.Entities.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Domain.Entities.ExampleEntity", b =>
                {
                    b.HasOne("Domain.Entities.ExampleEntityList", "ExampleEntityList")
                        .WithMany("ExampleEntities")
                        .HasForeignKey("ExampleEntityListId");

                    b.Navigation("ExampleEntityList");
                });

            modelBuilder.Entity("Domain.Entities.Refill", b =>
                {
                    b.HasOne("Domain.Entities.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Route", null)
                        .WithMany("Refills")
                        .HasForeignKey("RouteId");

                    b.Navigation("Coupon");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.Truck", b =>
                {
                    b.HasOne("Domain.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Domain.Entities.ExampleEntityList", b =>
                {
                    b.Navigation("ExampleEntities");
                });

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Navigation("Refills");
                });
#pragma warning restore 612, 618
        }
    }
}
