using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJNLinkedLists
{
    class Program
    {
        class moduleData // Class hold module information
        {
            public String module_code;
            public String module_title;
            public int module_score;

            public moduleData(String mcode, String mname, int score) // Constructor populate module
            {
                module_code = mcode;
                module_title = mname;
                module_score = score;
            }
        }

        class studentData // class to hold student information including modules
        {
            public String forename;
            public String surname;
            public int id_number;
            public float averageGrade;
            public moduleData[] modules; // Will point to an array of students modules objects

            public studentData(String fName, String sName, int idNum, moduleData[] modules_list)  // Constructor populate student
            {
                forename = fName;
                surname = sName;
                id_number = idNum;
                averageGrade = 0.0f;
                modules = modules_list;

                // Calculate average grade
                int total = 0;
                foreach (moduleData module in modules)
                {
                    total += module.module_score; // Calculate sum of all grades
                }

                averageGrade = (float)total / 6.0f; 
            }
        }


        static void Main(String[] args) // Create students with modules and add them to linked list
        {
            var rand = new Random();
            studentData student;  // student record
            moduleData[] modules; // = new module_data[6];     // Six modules per student

            CJNLinkedListSingle<studentData> myLinkedList = new CJNLinkedListSingle<studentData>(); // Create new linked list of type studentData

            // Arrays holding module codes and titles
            String[] codes = { "CIS2100", "CIS2117", "CIS2109", "CIS2118", "CIS2110", "BUS2005", "CIS2136", "CIS2116", "CIS2113", "CIS2135", "CIS2134" };
            String[] titles = {"Intro to Databases", "Programming Languages", "OO Programming", "Prog Lang: Inspire Creativity", 
                                "Physical COmputing", "Graduate Enterprise", "Work Related Learning", "Team Project", "Games Engines",
                                "Digital Design & Production", "Comp Graphics & Modelling"};

            // Student names           
            String[] fnames = { "Walter", "Bruce", "Clark", "Steve", "Jon", "Jeffrey" };
            String[] snames = { "White", "Wayne", "Kent", "Rogers", "Osterman", "Sinclair" };

            Console.WriteLine("Example using single linked list\n");

            for (int t = 0; t < snames.Length; t++) // Populate students
            {
                modules = new moduleData[6]; // Set asside module space for this student and point modules at it

                for (int u = 0; u < modules.Length; u++) // Populate modules array
                {
                    int mod = rand.Next(0, codes.Length); // Generate a random value to represent the module
                    int score = rand.Next(0, 101);        // maximum random value is exclusive so value should be in range 0 - 100

                    modules[u] = new moduleData(codes[mod], titles[mod], score); // Construct new module_data object and populate
                }

                student = new studentData(fnames[t], snames[t], t + 1, modules); // Construct new student object and populate

                myLinkedList.appendRecord(student); // Add this record to the linked list
            }

            for (int t = 0; t < myLinkedList.sizeOf(); t++) // Display all students
            {
                displayStudent(myLinkedList.getRecord(t));
            }

            // Display student names only
            Console.WriteLine("LinkedList List size = " + myLinkedList.sizeOf() + " and contains records for:");
            for (int t = 0; t < myLinkedList.sizeOf(); t++)
                Console.WriteLine(myLinkedList.getRecord(t).forename + " " + myLinkedList.getRecord(t).surname);

            // Deleta a record from middle of list
            Console.WriteLine("\nDeleting record from middle of list: " + myLinkedList.getRecord(3).forename + " " + myLinkedList.getRecord(3).surname + "\n"); 
            myLinkedList.deleteRecord(3); // Delete record 3

            // Deleta a record from end of list
            Console.WriteLine("Deleting record from tail of list: " + myLinkedList.getRecord(myLinkedList.sizeOf()-1).forename + " " + myLinkedList.getRecord(myLinkedList.sizeOf()-1).surname + "\n");
            myLinkedList.deleteRecord(myLinkedList.sizeOf()-1); // Delete record 3

            // Iterate through remaining records deleting records from head
            int size = myLinkedList.sizeOf(); // Get the size of the list

            Console.WriteLine("Iteritively delete remaining records as they move to head of list:");
            for (int t = 0; t < size; t++)
            {
                // Display name from record at head
                Console.WriteLine("Deleting record for " + myLinkedList.getRecord(0).forename + " " + myLinkedList.getRecord(0).surname);

                myLinkedList.deleteRecord(0); // Delete record at head

                Console.WriteLine("List size = " + myLinkedList.sizeOf()); // Report updated list size
            }


            //for (int t = myLinkedList.sizeOf() - 1; t >= 0; t--) // Delete last student node iteratively 
            //{
            //    myLinkedList.deleteRecord(t);

            //    Console.WriteLine("List size = " + myLinkedList.sizeOf());
            //}

            if (myLinkedList.sizeOf() > 0)
            {   
                for (int t = 0; t < myLinkedList.sizeOf(); t++) // Display students in list
                {
                    displayStudent(myLinkedList.getRecord(t));
                }
            }
            else
                Console.WriteLine("\nNo records in list");

            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }


        static void displayStudent(studentData student) // Output information about all students held in student array
        {

            Console.WriteLine(student.forename + " " + student.surname);
            Console.WriteLine("ID: " + student.id_number);
            Console.WriteLine("AVE Grade: " + student.averageGrade);

            foreach (moduleData md in student.modules) // Loop to output data for all modules in modules array
            {
                Console.WriteLine(md.module_code + "\t" + md.module_title + " " + md.module_score);
            }

            Console.WriteLine(""); // Blank space between records

        }

    }
}
