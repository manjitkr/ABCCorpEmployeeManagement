﻿// <auto-generated />
using System;
using ABCCorpEmployeeManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ABCCorp.EmployeeManagement.Persistence.Migrations
{
    [DbContext(typeof(EmployeeManagementDatabaseContext))]
    [Migration("20250202223241_RefactoringChanges")]
    partial class RefactoringChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ABCCorp.EmployeeManagement.Domain.AdminVerificationRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminVerificationComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminVerificationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeRecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeRecordId");

                    b.ToTable("AdminVerificationRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminVerificationComment = "Approved by Admin",
                            AdminVerificationStatus = "Approved",
                            DateCreated = new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(2775),
                            DateModified = new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(2755),
                            EmployeeRecordId = 1
                        });
                });

            modelBuilder.Entity("ABCCorp.EmployeeManagement.Domain.EmployeeRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminVerificationComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminVerificationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceInYears")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousCompanyEmployerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminVerificationStatus = "PendingVerification",
                            DateCreated = new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(4594),
                            DateModified = new DateTime(2025, 2, 3, 4, 2, 41, 38, DateTimeKind.Local).AddTicks(4590),
                            Email = "johndoe@email.com",
                            ExperienceInYears = 0,
                            FirstName = "John",
                            LastName = "Doe",
                            Mobile = "123-456-789",
                            Role = "Developer",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("ABCCorp.EmployeeManagement.Domain.AdminVerificationRecord", b =>
                {
                    b.HasOne("ABCCorp.EmployeeManagement.Domain.EmployeeRecord", "EmployeeRecord")
                        .WithMany()
                        .HasForeignKey("EmployeeRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
