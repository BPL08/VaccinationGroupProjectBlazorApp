﻿// <auto-generated />
using System;
using DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAO.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250402090343_InitialCreateV2")]
    partial class InitialCreateV2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BO.Entity.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FKCenterId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("FKCenterId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BO.Entity.ChildrenProfile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FKAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.HasIndex("FKAccountId");

                    b.ToTable("ChildrenProfiles");
                });

            modelBuilder.Entity("BO.Entity.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FKProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmountPrice")
                        .HasColumnType("int");

                    b.Property<int>("TotalPaidPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("FKProfileId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BO.Entity.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FKOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("FKVaccineId")
                        .HasColumnType("int");

                    b.Property<int?>("FKVaccinePackageId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("FKOrderId");

                    b.HasIndex("FKVaccineId");

                    b.HasIndex("FKVaccinePackageId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BO.Entity.VaccinationSchedule", b =>
                {
                    b.Property<Guid>("VaccinationScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdministeredBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoseNumber")
                        .HasColumnType("int");

                    b.Property<int>("FKCenterId")
                        .HasColumnType("int");

                    b.Property<Guid>("FKOrderDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FKProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("VaccinationScheduleId");

                    b.HasIndex("FKCenterId");

                    b.HasIndex("FKOrderDetailsId");

                    b.HasIndex("FKProfileId");

                    b.ToTable("VaccinationSchedules");
                });

            modelBuilder.Entity("BO.Entity.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineId"));

                    b.Property<DateTime>("BetweenPeriod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKBatchId")
                        .HasColumnType("int");

                    b.Property<int>("FKCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitOfVolume")
                        .HasColumnType("int");

                    b.HasKey("VaccineId");

                    b.HasIndex("FKBatchId");

                    b.HasIndex("FKCategoryId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("BO.Entity.VaccineBatch", b =>
                {
                    b.Property<int>("VaccineBatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineBatchId"));

                    b.Property<string>("ActiveStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FKCenterId")
                        .HasColumnType("int");

                    b.HasKey("VaccineBatchId");

                    b.HasIndex("FKCenterId");

                    b.ToTable("VaccineBatches");
                });

            modelBuilder.Entity("BO.Entity.VaccineCategory", b =>
                {
                    b.Property<int>("VaccineCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineCategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FKParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineCategoryId");

                    b.HasIndex("FKParentCategoryId");

                    b.ToTable("VaccineCategories");
                });

            modelBuilder.Entity("BO.Entity.VaccineCenter", b =>
                {
                    b.Property<int>("VacineCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacineCenterId"));

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VacineCenterId");

                    b.ToTable("VaccineCenters");
                });

            modelBuilder.Entity("BO.Entity.VaccineHistory", b =>
                {
                    b.Property<Guid>("VacineHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdministeredBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AdministeredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DosedNumber")
                        .HasColumnType("int");

                    b.Property<int>("FKCenterId")
                        .HasColumnType("int");

                    b.Property<Guid>("FKProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FKVaccineId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VerifiedStatus")
                        .HasColumnType("int");

                    b.HasKey("VacineHistoryId");

                    b.HasIndex("FKCenterId");

                    b.HasIndex("FKProfileId");

                    b.HasIndex("FKVaccineId");

                    b.ToTable("VaccineHistories");
                });

            modelBuilder.Entity("BO.Entity.VaccinePackage", b =>
                {
                    b.Property<int>("VaccinePackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccinePackageId"));

                    b.Property<string>("PackageDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackageStatus")
                        .HasColumnType("int");

                    b.HasKey("VaccinePackageId");

                    b.ToTable("VaccinePackages");
                });

            modelBuilder.Entity("BO.Entity.VaccinePackageDetail", b =>
                {
                    b.Property<Guid>("VaccinePackageDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FKVaccineId")
                        .HasColumnType("int");

                    b.Property<int>("FKVaccinePackageId")
                        .HasColumnType("int");

                    b.Property<int>("PackagePrice")
                        .HasColumnType("int");

                    b.HasKey("VaccinePackageDetailId");

                    b.HasIndex("FKVaccineId");

                    b.HasIndex("FKVaccinePackageId");

                    b.ToTable("VaccinePackageDetails");
                });

            modelBuilder.Entity("BO.Entity.Account", b =>
                {
                    b.HasOne("BO.Entity.VaccineCenter", "Center")
                        .WithMany()
                        .HasForeignKey("FKCenterId");

                    b.Navigation("Center");
                });

            modelBuilder.Entity("BO.Entity.ChildrenProfile", b =>
                {
                    b.HasOne("BO.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("FKAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BO.Entity.Order", b =>
                {
                    b.HasOne("BO.Entity.ChildrenProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("FKProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("BO.Entity.OrderDetail", b =>
                {
                    b.HasOne("BO.Entity.Order", "Order")
                        .WithMany()
                        .HasForeignKey("FKOrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BO.Entity.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("FKVaccineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BO.Entity.VaccinePackage", "VaccinePackage")
                        .WithMany()
                        .HasForeignKey("FKVaccinePackageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Order");

                    b.Navigation("Vaccine");

                    b.Navigation("VaccinePackage");
                });

            modelBuilder.Entity("BO.Entity.VaccinationSchedule", b =>
                {
                    b.HasOne("BO.Entity.VaccineCenter", "Center")
                        .WithMany()
                        .HasForeignKey("FKCenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BO.Entity.OrderDetail", "OrderDetail")
                        .WithMany()
                        .HasForeignKey("FKOrderDetailsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BO.Entity.ChildrenProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("FKProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("OrderDetail");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("BO.Entity.Vaccine", b =>
                {
                    b.HasOne("BO.Entity.VaccineBatch", "Batch")
                        .WithMany()
                        .HasForeignKey("FKBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BO.Entity.VaccineCategory", "Category")
                        .WithMany()
                        .HasForeignKey("FKCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BO.Entity.VaccineBatch", b =>
                {
                    b.HasOne("BO.Entity.VaccineCenter", "Center")
                        .WithMany()
                        .HasForeignKey("FKCenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("BO.Entity.VaccineCategory", b =>
                {
                    b.HasOne("BO.Entity.VaccineCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("FKParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("BO.Entity.VaccineHistory", b =>
                {
                    b.HasOne("BO.Entity.VaccineCenter", "Center")
                        .WithMany()
                        .HasForeignKey("FKCenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BO.Entity.ChildrenProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("FKProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BO.Entity.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("FKVaccineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Profile");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("BO.Entity.VaccinePackageDetail", b =>
                {
                    b.HasOne("BO.Entity.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("FKVaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BO.Entity.VaccinePackage", "VaccinePackage")
                        .WithMany()
                        .HasForeignKey("FKVaccinePackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaccine");

                    b.Navigation("VaccinePackage");
                });
#pragma warning restore 612, 618
        }
    }
}
