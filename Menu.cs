using Microsoft.EntityFrameworkCore;
using SUT23_Labb_1___LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb1
{
    internal class Menu
    {
        public static void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to my school program!");
                Console.WriteLine("1. Get all teachers who teach mathematics");
                Console.WriteLine("2. Get all students with their teachers");
                Console.WriteLine("3. Check if the subjects table contains Programming1");
                Console.WriteLine("4. Change a subject from Programming2 to OOP");
                Console.WriteLine("5. Update a student's teacher from Anas to Reidar");
                Console.WriteLine("6. Exit the program");

                Console.Write("Choose between (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetMathTeachers();
                        break;
                    case "2":
                        GetStudentsWithTeachers();
                        break;
                    case "3":
                        CheckForProgramming1();
                        break;
                    case "4":
                        ChangeProgramming2ToOOP();
                        break;
                    case "5":
                        UpdateStudentTeacherFromAnasToReidar();
                        break;
                    case "6":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void GetMathTeachers()
        {
            using (var context = new SchoolDbContext())
            {
                var mathTeachers = from teacher in context.Teachers
                                   where teacher.SubjectID == 3
                                   select teacher;
                if (mathTeachers.Any())
                {
                    Console.WriteLine("Teachers who teach Mathematics:");
                    foreach (var teacher in mathTeachers)
                    {
                        Console.WriteLine($"ID: {teacher.TeacherID}, Name: {teacher.TeacherName}");
                    }

                }
                else
                {
                    Console.WriteLine("Hitta fan inget");
                }
            }
        }


        static void GetStudentsWithTeachers()
        {
            using (var context = new SchoolDbContext())
            {
                var studentsWithTeachers = from student in context.Students
                                           select new
                                           {
                                               Student = student,
                                               student.Teacher
                                           };

                Console.WriteLine("Students with their teachers:");
                foreach (var item in studentsWithTeachers)
                {
                    Console.WriteLine($"Student: {item.Student.FirstName} {item.Student.LastName}, Teacher: {item.Teacher?.TeacherName ?? "No teacher assigned"}");
                }
            }
        }

        static void CheckForProgramming1()
        {
            using (var context = new SchoolDbContext())
            {
                var containsProgramming1 = (from subject in context.Subjects
                                            where subject.SubjectName == "Programming1"
                                            select subject).Any();

                Console.WriteLine($"Contains Programming1 in subjects table: {containsProgramming1}");
            }
        }

        static void ChangeProgramming2ToOOP()
        {
            using (var context = new SchoolDbContext())
            {
                var subjectToChange = context.Subjects
                    .FirstOrDefault(s => s.SubjectName == "Programming2");
                if (subjectToChange != null)
                {
                    subjectToChange.SubjectName = "OOP";
                    context.SaveChanges();
                    Console.WriteLine("Subject changed to OOP.");
                }
                else
                {
                    Console.WriteLine("No subject with name Programming2 found.");
                }
            }
        }

        static void UpdateStudentTeacherFromAnasToReidar()
        {
            using (var context = new SchoolDbContext())
            {
                var studentToUpdate = context.Students
                    .FirstOrDefault(s => s.Teacher != null && s.Teacher.TeacherName == "Anas");
                if (studentToUpdate != null)
                {
                    var newTeacher = context.Teachers.FirstOrDefault(t => t.TeacherName == "Reidar");
                    if (newTeacher != null)
                    {
                        studentToUpdate.Teacher = newTeacher;
                        context.SaveChanges();
                        Console.WriteLine("Student's teacher updated to Reidar.");
                    }
                    else
                    {
                        Console.WriteLine("No teacher with name Reidar found.");
                    }
                }
                else
                {
                    Console.WriteLine("No student with teacher Anas found.");
                }
            }
        }
    }
}
