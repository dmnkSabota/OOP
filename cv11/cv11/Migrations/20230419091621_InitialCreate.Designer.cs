﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cv11.EFCore;

#nullable disable

namespace cv11.Migrations
{
    [DbContext(typeof(EduContext))]
    [Migration("20230419091621_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cv11.EFCore.Grade", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("GradingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumericalGrade")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "Abbreviation");

                    b.HasIndex("Abbreviation");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("cv11.EFCore.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("cv11.EFCore.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId", "Abbreviation");

                    b.HasIndex("Abbreviation");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("cv11.EFCore.Subject", b =>
                {
                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Abbreviation");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("cv11.EFCore.Grade", b =>
                {
                    b.HasOne("cv11.EFCore.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("Abbreviation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cv11.EFCore.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("cv11.EFCore.StudentSubject", b =>
                {
                    b.HasOne("cv11.EFCore.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("Abbreviation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cv11.EFCore.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("cv11.EFCore.Student", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("cv11.EFCore.Subject", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
