﻿// <auto-generated />
using System;
using HRTrainingTracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRTrainingTracker.Entities.Migrations
{
    [DbContext(typeof(HRTrainingContext))]
    partial class HRTrainingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeTraining", b =>
                {
                    b.Property<int>("EmployeesEmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingListTrainingID")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeID", "TrainingListTrainingID");

                    b.HasIndex("TrainingListTrainingID");

                    b.ToTable("EmployeeTraining");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Building", b =>
                {
                    b.Property<int>("BuildingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateID")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingID");

                    b.HasIndex("StateID");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Manager")
                        .HasColumnType("bit");

                    b.Property<int>("ShiftID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeID");

                    b.HasIndex("BuildingID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("ShiftID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Local", b =>
                {
                    b.Property<int>("LocalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalID");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Shift", b =>
                {
                    b.Property<int>("ShiftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShiftID");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Expired")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalityLocalID")
                        .HasColumnType("int");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TrainingExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingTypesID")
                        .HasColumnType("int");

                    b.HasKey("TrainingID");

                    b.HasIndex("LocalityLocalID");

                    b.HasIndex("TrainingTypesID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.TrainingTypes", b =>
                {
                    b.Property<int>("TrainingTypesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingTypesID");

                    b.ToTable("TrainingTypes");
                });

            modelBuilder.Entity("EmployeeTraining", b =>
                {
                    b.HasOne("HRTrainingTracker.Entities.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRTrainingTracker.Entities.Models.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingListTrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Building", b =>
                {
                    b.HasOne("HRTrainingTracker.Entities.Models.State", "State")
                        .WithMany("Buildings")
                        .HasForeignKey("StateID");

                    b.Navigation("State");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Employee", b =>
                {
                    b.HasOne("HRTrainingTracker.Entities.Models.Building", "Building")
                        .WithMany("Employees")
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRTrainingTracker.Entities.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRTrainingTracker.Entities.Models.Shift", "Shift")
                        .WithMany("Employees")
                        .HasForeignKey("ShiftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Department");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Training", b =>
                {
                    b.HasOne("HRTrainingTracker.Entities.Models.Local", "Locality")
                        .WithMany("Trainings")
                        .HasForeignKey("LocalityLocalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRTrainingTracker.Entities.Models.TrainingTypes", "TrainingType")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingTypesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");

                    b.Navigation("TrainingType");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Building", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Local", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.Shift", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.State", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("HRTrainingTracker.Entities.Models.TrainingTypes", b =>
                {
                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
