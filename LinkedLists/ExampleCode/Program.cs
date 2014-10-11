using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCode
{
    class Program
    {
        public struct student_data
        {
            public string forename;
            public string surname;
            public int id_number;
            public float averageGrade;
        }
        // Notice that a reference to the struct is being passed in
        static void populateStruct(out student_data student, string fname, string surname, int id_number)
        {
            student.forename = fname;
            student.surname = surname;
            student.id_number = id_number;
            student.averageGrade = 0.0F;
        }

        static void Main(string[] args)
        {
            student_data student1, student2, student3;

            populateStruct(out student1, "Mark", "Anderson", 1);
            printStudent(student1);

            populateStruct(out student3, "Tom", "Jones", 3);
            printStudent(student3);

            Console.ReadKey();
        }

        static void printStudent(student_data student)
        {
            Console.WriteLine("Name: " + student.forename + " " + student.surname);
            Console.WriteLine("Id: " + student.id_number);
            Console.WriteLine("Av grade: " + student.averageGrade);
        }
    }
}
