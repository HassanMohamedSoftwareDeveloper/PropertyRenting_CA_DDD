﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyRenting.Infrastructure.Persistence.Contexts;

#nullable disable

namespace PropertyRenting.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PropertyRentingWriteContext))]
    [Migration("20221217030806_DB_V1")]
    partial class DB_V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConstructionStatus")
                        .HasColumnType("int")
                        .HasColumnName("ConstructionStatusId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("EstablishYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LevelsNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("RentableArea")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalArea")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<int?>("Type")
                        .HasColumnType("int")
                        .HasColumnName("BuildingTypeId");

                    b.Property<int?>("UnitsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("YearReRentAmount")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<decimal?>("YearRentAmount")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.HasKey("Id");

                    b.ToTable("Buildings", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Contributer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contributers", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Renter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("GenderId");

                    b.Property<string>("GuarantorAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantorMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlackListed")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NationalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RenterType")
                        .HasColumnType("int")
                        .HasColumnName("RenterTypeId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Renters", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Building.BuildingContributer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContributerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("BuildingContributers", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Building.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("ACsNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("AnnualRentAmount")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("FloorNumber")
                        .HasColumnType("bigint");

                    b.Property<long?>("HallsNumber")
                        .HasColumnType("bigint");

                    b.Property<bool>("HasCentralAC")
                        .HasColumnType("bit");

                    b.Property<bool>("HasInternetService")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<long?>("KitchensNumber")
                        .HasColumnType("bigint");

                    b.Property<long?>("PathsNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("RentableArea")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<long?>("RoomsNumber")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("TotalArea")
                        .HasPrecision(20, 4)
                        .HasColumnType("decimal(20,4)");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Units", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Country.City", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Country.District", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Renter.ContactPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.ToTable("ContactPeople", "Lookup");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Renter", b =>
                {
                    b.OwnsOne("PropertyRenting.Domain.ValueObjects.Common.MemberIdentity", "Identity", b1 =>
                        {
                            b1.Property<Guid>("RenterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("IdentityExpiryDate")
                                .HasColumnType("date")
                                .HasColumnName("IdentityExpiryDate");

                            b1.Property<string>("IdentityIssuePlace")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("IdentityIssuePlace");

                            b1.Property<string>("IdentityNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("IdentityNumber");

                            b1.Property<int?>("IdentityType")
                                .HasColumnType("int")
                                .HasColumnName("IdentityTypeId");

                            b1.HasKey("RenterId");

                            b1.ToTable("Renters", "Lookup");

                            b1.WithOwner()
                                .HasForeignKey("RenterId");
                        });

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Building.BuildingContributer", b =>
                {
                    b.HasOne("PropertyRenting.Domain.Aggregates.Building", null)
                        .WithMany("Contributers")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Building.Unit", b =>
                {
                    b.HasOne("PropertyRenting.Domain.Aggregates.Building", null)
                        .WithMany("Units")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Country.City", b =>
                {
                    b.HasOne("PropertyRenting.Domain.Aggregates.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Country.District", b =>
                {
                    b.HasOne("PropertyRenting.Domain.Entities.Country.City", null)
                        .WithMany("Districts")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Renter.ContactPerson", b =>
                {
                    b.HasOne("PropertyRenting.Domain.Aggregates.Renter", null)
                        .WithMany("ContactPeople")
                        .HasForeignKey("RenterId");

                    b.OwnsOne("PropertyRenting.Domain.ValueObjects.Common.MemberIdentity", "Identity", b1 =>
                        {
                            b1.Property<Guid>("ContactPersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("IdentityExpiryDate")
                                .HasColumnType("date")
                                .HasColumnName("IdentityExpiryDate");

                            b1.Property<string>("IdentityIssuePlace")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("IdentityIssuePlace");

                            b1.Property<string>("IdentityNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("IdentityNumber");

                            b1.Property<int?>("IdentityType")
                                .HasColumnType("int")
                                .HasColumnName("IdentityTypeId");

                            b1.HasKey("ContactPersonId");

                            b1.ToTable("ContactPeople", "Lookup");

                            b1.WithOwner()
                                .HasForeignKey("ContactPersonId");
                        });

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Building", b =>
                {
                    b.Navigation("Contributers");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Aggregates.Renter", b =>
                {
                    b.Navigation("ContactPeople");
                });

            modelBuilder.Entity("PropertyRenting.Domain.Entities.Country.City", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
