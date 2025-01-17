using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap3
{
    internal class Program
    {
        static void Main(string[] args)

        {
           Student student = new Student();
            student.DisplayInfo();
           Student student2 = new Student("Trang", "Huyen", new DateTime(2004, 06, 03));
            student2.DisplayInfo();

        }
    }
    class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        private static int totalStudents;


        public Student( ) 
        {
            FirstName = "Default FirstName";
            LastName = "Default Lastname";
            DoB = null;
            totalStudents++;
        
        }
        public Student(string firstName, string lastName, DateTime? dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = dateOfBirth ?? new DateTime(2006, 1, 1);
            totalStudents++;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {StudentID}, Name: {FirstName} {LastName}, Date of Birth: {DoB}, Enrollment Date: {EnrollmentDate}");
        }
    }

}
