using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        public struct module_data // Structure to hold module information
        {
            public string module_code;
            public string module_title;
            public int module_score;
        }

        public struct student_data // Structure to hold student information including modules
        {
            public string forename;
            public string surname;
            public int id_number;
            public float averageGrade;
            public module_data[] modules; // Will point to an array of students modules

        }

        static void populateModules(out module_data module, string mcode, string mname, int score) // populate module using reference to module
        {
            module.module_code = mcode;
            module.module_title = mname;
            module.module_score = score;
        }

        // Notice that a reference to the struct is being passed in along with a reference to the module list array
        static void populateStruct(out student_data student, string fname, string surname, int id_number, module_data[] modules_list)
        {
            student.forename = fname;
            student.surname = surname;
            student.id_number = id_number;
            student.averageGrade = 0.0f;
            student.modules = modules_list;

            // Calculate average grade
            int total = 0;
            foreach (module_data module in student.modules)
            {
                total += module.module_score; // Calculate sum of all grades
            }

            student.averageGrade = (float)total / 6.0f;

        }


        static void Main(string[] args)
        {
            var rand = new Random();
            student_data[] students = new student_data[6];  // Six students
            module_data[] modules; // = new module_data[6];     // Six modules per student

            // Arrays holding module codes and titles
            string[] codes = { "CIS2100", "CIS2117", "CIS2109", "CIS2118", "CIS2110", "BUS2005", "CIS2136", "CIS2116", "CIS2113", "CIS2135", "CIS2134" };
            string[] titles = {"Intro to Databases", "Programming Languages", "OO Programming", "Prog Lang: Inspire Creativity", 
                                  "Physical COmputing", "Graduate Enterprise", "Work Related Learning", "Team Project", "Games Engines",
                                   "Digital Design & Production", "Comp Graphics & Modelling"};

            // Student names           
            string[] fnames = { "Walter", "Bruce", "Clark", "Steve", "Jon", "Jeffrey" };
            string[] snames = { "White", "Wayne", "Kent", "Rogers", "Osterman", "Sinclair" };

            for (int t = 0; t < students.Length; t++) // Populate students
            {
                modules = new module_data[6]; // Set asside module space for this student and point modules at it

                for (int u = 0; u < modules.Length; u++) // Populate modules array
                {
                    int mod = rand.Next(0, codes.Length); // Generate a random value to represent the module
                    int score = rand.Next(0, 101);        // maximum random value is exclusive so value should be in range 0 - 100

                    populateModules(out modules[u], codes[mod], titles[mod], score); // Populate module data
                }

                populateStruct(out students[t], fnames[t], snames[t], t + 1, modules);  // Populate this student's data
            }

            printAllStudents(students); // Display all students' data to console

            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }


        static void printAllStudents(student_data[] students) // Output information about all students held in student array
        {
            foreach (student_data student in students) // Loop to run through the students in the array
            {
                Console.WriteLine(student.forename + " " + student.surname);
                Console.WriteLine("ID: " + student.id_number);
                Console.WriteLine("AVE Grade: " + student.averageGrade);

                foreach (module_data md in student.modules) // Loop to output data for all modules in modules array
                {
                    Console.WriteLine(md.module_code + "\t" + md.module_title + " " + md.module_score);
                }

                Console.WriteLine(""); // Blank space between records
            }
        }

    }

}
