﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webhelp.PruebaTecnica.Infrastructure;

#nullable disable

namespace Webhelp.PruebaTecnica.Infrastructure.Migrations
{
    [DbContext(typeof(MedicalCenterDBContext))]
    [Migration("20240114050604_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.AppointmentEntity", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time(6)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("PatientId");

                    b.HasIndex("StateId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.AppointmentStateEntity", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StateId");

                    b.ToTable("AppointmentStates");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.DocumentTypeEntity", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DocumentId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.PatientEntity", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.HasIndex("Document")
                        .IsUnique();

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.AppointmentEntity", b =>
                {
                    b.HasOne("Webhelp.PruebaTecnica.Infrastructure.Entities.PatientEntity", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.HasOne("Webhelp.PruebaTecnica.Infrastructure.Entities.AppointmentStateEntity", "AppointmentState")
                        .WithMany("Appointments")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentState");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.PatientEntity", b =>
                {
                    b.HasOne("Webhelp.PruebaTecnica.Infrastructure.Entities.DocumentTypeEntity", "DocumentType")
                        .WithMany("Patients")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.AppointmentStateEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.DocumentTypeEntity", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Webhelp.PruebaTecnica.Infrastructure.Entities.PatientEntity", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
