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
    [Migration("20210128093923_DebtorLocationUniqueIndex")]
    partial class DebtorLocationUniqueIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

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

            modelBuilder.Entity("Domain.Entities.Debtor", b =>
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

                    b.ToTable("Debtors");
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

            modelBuilder.Entity("Domain.Entities.FuelTank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MinimumFuelAmount")
                        .HasColumnType("float");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<double>("TankCapacity")
                        .HasColumnType("float");

                    b.Property<int>("TankNumber")
                        .HasColumnType("int");

                    b.Property<int>("TankType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FuelTanks");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaysBetweenRefills")
                        .HasColumnType("int");

                    b.Property<double>("EstimateFuelConsumption")
                        .HasColumnType("float");

                    b.Property<int>("FuelTankId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Schedule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FuelTankId");

                    b.HasIndex("RegionId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.LocationDebtor", b =>
                {
                    b.Property<int>("DebtorId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("DebtorId", "LocationId");

                    b.HasIndex("LocationId", "DebtorId", "Type")
                        .IsUnique();

                    b.ToTable("LocationDebtor");
                });

            modelBuilder.Entity("Domain.Entities.LocationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaysBetweenRefills")
                        .HasColumnType("int");

                    b.Property<double>("EstimateFuelConsumption")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Schedule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("RegionId");

                    b.ToTable("LocationHistories");
                });

            modelBuilder.Entity("Domain.Entities.Refill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("ActualDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CouponId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EndAmount")
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

                    b.Property<int?>("RefillNumber")
                        .HasColumnType("int");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.Property<double?>("StartAmount")
                        .HasColumnType("float");

                    b.Property<int?>("TankState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("Refills");
                });

            modelBuilder.Entity("Domain.Entities.Region", b =>
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

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.Entities.RegionDailyTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("RegionDailyTemps");
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

            modelBuilder.Entity("Domain.Entities.Street", b =>
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Streets");
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.Property<double>("TankCapacity")
                        .HasColumnType("float");

                    b.Property<string>("TruckIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Domain.Entities.TruckDailyState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("EveningQuantity")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<double>("MorningQuantity")
                        .HasColumnType("float");

                    b.Property<int>("StartRefillNumber")
                        .HasColumnType("int");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckDailyStates");
                });

            modelBuilder.Entity("Domain.Entities.TruckRefill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuelCardNumber")
                        .HasColumnType("int");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("TruckDailyStateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruckDailyStateId");

                    b.ToTable("TruckRefills");
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

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.HasOne("Domain.Entities.FuelTank", "FuelTank")
                        .WithMany()
                        .HasForeignKey("FuelTankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Region", "Region")
                        .WithMany("Locations")
                        .HasForeignKey("RegionId");

                    b.Navigation("FuelTank");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.LocationDebtor", b =>
                {
                    b.HasOne("Domain.Entities.Debtor", "Debtor")
                        .WithMany("Locations")
                        .HasForeignKey("DebtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("Debtors")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Debtor");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.LocationHistory", b =>
                {
                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("LocationHistories")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.Refill", b =>
                {
                    b.HasOne("Domain.Entities.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.HasOne("Domain.Entities.Location", "Location")
                        .WithMany("Refills")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Route", null)
                        .WithMany("Refills")
                        .HasForeignKey("RouteId");

                    b.Navigation("Coupon");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entities.RegionDailyTemp", b =>
                {
                    b.HasOne("Domain.Entities.Region", "Region")
                        .WithMany("DailyTemperatures")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.Street", b =>
                {
                    b.HasOne("Domain.Entities.Region", "Region")
                        .WithMany("Streets")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.Truck", b =>
                {
                    b.HasOne("Domain.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Domain.Entities.TruckDailyState", b =>
                {
                    b.HasOne("Domain.Entities.Truck", "Truck")
                        .WithMany("DailyStates")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Domain.Entities.TruckRefill", b =>
                {
                    b.HasOne("Domain.Entities.TruckDailyState", "TruckDailyState")
                        .WithMany("TruckRefills")
                        .HasForeignKey("TruckDailyStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TruckDailyState");
                });

            modelBuilder.Entity("Domain.Entities.Debtor", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Domain.Entities.ExampleEntityList", b =>
                {
                    b.Navigation("ExampleEntities");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Navigation("Debtors");

                    b.Navigation("LocationHistories");

                    b.Navigation("Refills");
                });

            modelBuilder.Entity("Domain.Entities.Region", b =>
                {
                    b.Navigation("DailyTemperatures");

                    b.Navigation("Locations");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Navigation("Refills");
                });

            modelBuilder.Entity("Domain.Entities.Truck", b =>
                {
                    b.Navigation("DailyStates");
                });

            modelBuilder.Entity("Domain.Entities.TruckDailyState", b =>
                {
                    b.Navigation("TruckRefills");
                });
#pragma warning restore 612, 618
        }
    }
}
