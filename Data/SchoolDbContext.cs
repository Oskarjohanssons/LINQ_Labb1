using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SUT23_Labb_1___LINQ.Models;

namespace SUT23_Labb_1___LINQ.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = OSKAR;Initial Catalog = Labb1_LINQDB;Integrated Security=True;TrustServerCertificate=Yes;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherID = 1, TeacherName = "Anas", SubjectID = 3 },
                new Teacher { TeacherID = 2, TeacherName = "Reidar", SubjectID = 5 },
                new Teacher { TeacherID = 3, TeacherName = "Elena", SubjectID = 3 },
                new Teacher { TeacherID = 4, TeacherName = "Sara", SubjectID = 4 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1, CourseName = "SUT21" },
                new Course { CourseID = 2, CourseName = "SUT22" },
                new Course { CourseID = 3, CourseName = "SUT23" }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectID = 1, SubjectName = "Programming1" },
                new Subject { SubjectID = 2, SubjectName = "Programming2" },
                new Subject { SubjectID = 3, SubjectName = "Mathematics" },
                new Subject { SubjectID = 4, SubjectName = "OOP" },
                new Subject { SubjectID = 5, SubjectName = "Database" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, FirstName = "John", LastName = "Sten", CourseID = 1, TeacherID = 1 },
                new Student { StudentID = 2, FirstName = "Jane", LastName = "Doe", CourseID = 2, TeacherID = 2 },
                new Student { StudentID = 3, FirstName = "Steffan", LastName = "Smith", CourseID = 3, TeacherID = 1 },
                new Student { StudentID = 4, FirstName = "Alice", LastName = "Smith", CourseID = 3, TeacherID = 3 },
                new Student { StudentID = 5, FirstName = "Joe", LastName = "Johansson", CourseID = 3, TeacherID = 4 },
                new Student { StudentID = 6, FirstName = "Kalle", LastName = "Andersson", CourseID = 2, TeacherID = 2 },
                new Student { StudentID = 7, FirstName = "Victoria", LastName = "Gunnarsson", CourseID = 1, TeacherID = 3 }
            );
        }
    }
}
