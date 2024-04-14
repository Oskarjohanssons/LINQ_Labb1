﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUT23_Labb_1___LINQ.Data;

#nullable disable

namespace LINQ_Labb1.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            CourseName = "SUT21"
                        },
                        new
                        {
                            CourseID = 2,
                            CourseName = "SUT22"
                        },
                        new
                        {
                            CourseID = 3,
                            CourseName = "SUT23"
                        });
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            CourseID = 1,
                            FirstName = "John",
                            LastName = "Sten",
                            TeacherID = 1
                        },
                        new
                        {
                            StudentID = 2,
                            CourseID = 2,
                            FirstName = "Jane",
                            LastName = "Doe",
                            TeacherID = 2
                        },
                        new
                        {
                            StudentID = 3,
                            CourseID = 3,
                            FirstName = "Steffan",
                            LastName = "Smith",
                            TeacherID = 1
                        },
                        new
                        {
                            StudentID = 4,
                            CourseID = 3,
                            FirstName = "Alice",
                            LastName = "Smith",
                            TeacherID = 3
                        },
                        new
                        {
                            StudentID = 5,
                            CourseID = 3,
                            FirstName = "Joe",
                            LastName = "Johansson",
                            TeacherID = 4
                        },
                        new
                        {
                            StudentID = 6,
                            CourseID = 2,
                            FirstName = "Kalle",
                            LastName = "Andersson",
                            TeacherID = 2
                        },
                        new
                        {
                            StudentID = 7,
                            CourseID = 1,
                            FirstName = "Victoria",
                            LastName = "Gunnarsson",
                            TeacherID = 3
                        });
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectID = 1,
                            SubjectName = "Programming1"
                        },
                        new
                        {
                            SubjectID = 2,
                            SubjectName = "Programming2"
                        },
                        new
                        {
                            SubjectID = 3,
                            SubjectName = "Mathematics"
                        },
                        new
                        {
                            SubjectID = 4,
                            SubjectName = "OOP"
                        },
                        new
                        {
                            SubjectID = 5,
                            SubjectName = "Database"
                        });
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherID");

                    b.HasIndex("CourseID");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherID = 1,
                            SubjectID = 3,
                            TeacherName = "Anas"
                        },
                        new
                        {
                            TeacherID = 2,
                            SubjectID = 5,
                            TeacherName = "Reidar"
                        },
                        new
                        {
                            TeacherID = 3,
                            SubjectID = 3,
                            TeacherName = "Elena"
                        },
                        new
                        {
                            TeacherID = 4,
                            SubjectID = 4,
                            TeacherName = "Sara"
                        });
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.Property<int>("StudentsStudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.HasKey("StudentsStudentID", "SubjectsSubjectID");

                    b.HasIndex("SubjectsSubjectID");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherID")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectID", "TeachersTeacherID");

                    b.HasIndex("TeachersTeacherID");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Student", b =>
                {
                    b.HasOne("SUT23_Labb_1___LINQ.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23_Labb_1___LINQ.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Teacher", b =>
                {
                    b.HasOne("SUT23_Labb_1___LINQ.Models.Course", null)
                        .WithMany("Teachers")
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.HasOne("SUT23_Labb_1___LINQ.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23_Labb_1___LINQ.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("SUT23_Labb_1___LINQ.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUT23_Labb_1___LINQ.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Course", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SUT23_Labb_1___LINQ.Models.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
