namespace L11Assignment_CSI120
{
    internal class Program
    {
        // Arrays for the first and last names of students
        static string[] firstNames = { "Alice", "Bob", "Charlie", "David", "Eva" };
        static string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown" };
        static void Main(string[] args)
        {
            Console.WriteLine("Kady Tran - 5/28/2024");
            Console.WriteLine("Lecture 11 Assignment");

            Menu();

        } // End of Main

        //  Method: string FullName(int studentIndex)
        public static string FullName(int studentIndex)
        {
            // if statement to check if the student index is valid
            if (studentIndex >= 0 && studentIndex < firstNames.Length)
            {
                return $"{firstNames[studentIndex]} {lastNames[studentIndex]}"; // Using concatenation to combine both first and last names togther
            }
            else
            {
                return "The student index is invalid";
            }
        } // End of FullName

        //  Method: void DisplayStudentInformation(int studentIndex)
        public static void DisplayStudentInformation(int studentIndex)
        {
            if (studentIndex >= 0 && studentIndex < firstNames.Length)
            {
                // Student ID
                Console.WriteLine($"Student ID: {studentIndex}");
                // Full Name
                Console.WriteLine($"Full Name: {FullName(studentIndex)}");
                // First Name
                Console.WriteLine($"First Name: {firstNames[studentIndex]}");
                // Last Name
                Console.WriteLine($"Last Name: {lastNames[studentIndex]}");
                // Space
                Console.WriteLine(); 
            }
            else
            {
                Console.WriteLine("Student index is invalid");
            }
        } // End of DisplayStudentInformation

        // Method: void DisplayAllStudents()
        public static void DisplayAllStudents()
        {
            // Using for loop to look through each student 
            for (int i = 0; i < firstNames.Length; i++)
            {
                DisplayStudentInformation(i); // Calling this method to display student's info such as id and full name
            }
        } // End of DisplayAllStudents

        // Method: bool EnrolledInClassByLastName(string studentsLastName)
        public static bool EnrolledInClassByLastName(string studentsLastName)
        {
            // Finding if the last name is in the array or not
            for (int i = 0; i < lastNames.Length; i++)
            {
                if (lastNames[i].ToLower() == studentsLastName.ToLower()) // Putting .ToLower so that if the user enters in with caps or only lowercase, it will still be able to find the last name in any format
                {
                    return true;
                }
            }
            return false;
        } // End of EnrolledInClassByLastName

        // Method: int FindStudentIdByLastName(string studentLastName)
        public static int FindStudentIdByLastName(string studentsLastName)
        {
            for (int i = 0; i < lastNames.Length; i++)
            {
                // If the current value == the searchKey
                if (lastNames[i].ToLower() == studentsLastName.ToLower())
                {
                    // 1.
                    return i;
                    // 2.
                }

            } // end of for loop
            return -1;
        } // End of FindStudentIdByLastName

        // Method: void Menu()
        public static void Menu()
        {
            int choice;
            do
            {
                // Displaying options
                Console.WriteLine("Welcome to the Student Management System");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Check if a Student is enrolled by Last Name");
                Console.WriteLine("3. Display All Information by Last Name");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice)) // the out will put in the new data provided
                {
                    Console.WriteLine("Invalid, Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DisplayAllStudents();
                        break;
                    case 2:
                        Console.Write("Enter student's last name: ");
                        string lastName = Console.ReadLine();
                        if (EnrolledInClassByLastName(lastName))
                        {
                            Console.WriteLine("Yes, the student is enrolled.");
                        }
                        else
                        {
                            Console.WriteLine("No, the student is not enrolled.");
                        }
                        break;
                    case 3:
                        Console.Write("Enter student's last name: ");
                        string searchLastName = Console.ReadLine();
                        int studentIndex = FindStudentIdByLastName(searchLastName);
                        if (studentIndex != -1)
                        {
                            DisplayStudentInformation(studentIndex);
                        }
                        else
                        {
                            Console.WriteLine("Student is not enrolled.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("You have exited");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            } while (choice != 4);
        }
    } // End of Class

} // End of namespace
