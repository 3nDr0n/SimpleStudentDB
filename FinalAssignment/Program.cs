using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace StudentAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var schoolDb = new SchoolContext())
            {
                Console.Write("Please enter the new student's name: ");
                var name = Console.ReadLine();
                Console.WriteLine("Now, Please enter their date of birth following the format of YYYY/MM/DD:");
                var DoB = Console.ReadLine();
                var parsedDate = DateTime.Parse(DoB);
                Console.WriteLine("Please enter what grade they are currently in:");
                var grade = Console.ReadLine();
                var newStudent = new Student() { StudentName = name, DateOfBirth = parsedDate, Grade = grade };
                schoolDb.Students.Add(newStudent);
                schoolDb.SaveChanges();
            }
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Grade { get; set; }
    }


    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}