using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_Array_Use_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //This program is longer and more complicated than required in the Assessment Brief.
            //To see the actual main assignment portion of the program please go to line 157 - If (!customize)

            // I initialized these here because that is probably what was expected if I hadn't added extra options. If this program was simply 
            // the assignment this would have been the best way. As I added the option for the user to input their own grades, I ended up 
            // resetting the grades to their default values later in the program. As I set them to default later, I could have simply set this
            // up as a new array here - double[] grades = new double[5];
            double[] grades = { 34.7, 56.9, 75, 52, 92.2 };
            double lookup;
            double lookupdefault = 56.9;
            string option;
            string keepgoing = "y";
            bool customize = false;
            bool gradeinprogram = false;

            while (keepgoing == "y")
            {
                Console.Clear();
                Console.WriteLine("Welcome to G R A D E S");
                Console.WriteLine("Would you like to input your own grades?");

                do
                {
                    Console.WriteLine("Y for settings, N for default grades");
                    option = Console.ReadLine().ToUpper();

                    if (option == "Y")
                    {
                        customize = true;
                    }
                    else if (option == "N")
                    {
                        customize = false;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid input.");
                    }
                }
                while (option != "Y" && option != "N");

                //if the user has selected to customize settings (above) customize will be true and will go into the loop below.
                while (customize && option != "6")
                {
                    Console.Clear();

                    //the user enter a number (option) based on the menu & what they would like to do
                    option = CustomMenu();
                    Console.Clear();

                    // stay in the settings menu if any of the settings options are selected, AND customize is true
                    while (customize && (option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6"))
                    {
                        if (option == "1") //enter own grades
                        {
                            for (int i = 0; i < grades.Length; i++)
                            {
                                Console.Clear();
                                Console.WriteLine($"Please enter grade number {i + 1}");
                                grades[i] = CheckDoubleGrade(); //validate that the number is actually a double
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Your new grades have been stored.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.WriteLine("Press enter to go back to settings");
                            Console.ReadLine();
                            Console.Clear();
                            option = CustomMenu();
                        }
                        else if (option == "2") //search for a grade to see if the number is currently in the system
                        {
                            gradeinprogram = false;
                            Console.Clear();
                            Console.WriteLine("Enter the grade you would like to search for:");
                            lookup = CheckDoubleGrade();

                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int i = 0; i < grades.Length; i++)
                            {
                                if (grades[i] == lookup)
                                {
                                    gradeinprogram = true;
                                    Console.WriteLine($"The grade {lookup} is currently being held in place {i} (starting from 0).");
                                }
                            }
                            if (!gradeinprogram)
                            {
                                Console.WriteLine($"Sorry, {lookup} is not currently a grade in the system.");
                            }
                            Console.ForegroundColor = ConsoleColor.White;

                            BackToSettings();

                            option = CustomMenu();
                        }
                        else if (option == "3") //sort & dispay grades low to high
                        {
                            Array.Sort(grades);

                            Console.Clear();
                            Console.WriteLine("The grades from lowest to highest are:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (var g in grades)
                            {
                                Console.WriteLine(g);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            BackToSettings();
                            option = CustomMenu();
                        }
                        else if (option == "4") //sort & display grades high to low
                        {
                            Array.Sort(grades);
                            Array.Reverse(grades);

                            Console.Clear();
                            Console.WriteLine("The grades from highest to lowest are:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            foreach (var g in grades)
                            {
                                Console.WriteLine(g);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            BackToSettings();
                            option = CustomMenu();
                        }
                        else if (option == "5")// reset grades and run default program. Will cause to exit this while loop in order to run default program below.
                        {
                            customize = false;
                        }
                        else // quit program
                        {
                            keepgoing = "n";
                            break;
                        }
                    }
                }
                if (!customize) //DEFAULT PROGRAM AS PER ASSIGNMENT
                {
                    Console.Clear();
                    grades[0] = 34.7;
                    grades[1] = 56.9;
                    grades[2] = 75;
                    grades[3] = 52;
                    grades[4] = 92.2;
                    Console.WriteLine($"There are {grades.Length} grades being stored");

                    for (int i = 0; i < grades.Length; i++)
                    {
                        if (grades[i] == lookupdefault)
                        {
                            Console.WriteLine($"The grade {grades[i]} is being held in the system.");
                        }
                    }

                    Console.WriteLine("The grades stored in the system are:");
                    foreach (var g in grades)
                    {
                        Console.WriteLine(g);
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Would you like to start over? y/n");
                    Console.ForegroundColor = ConsoleColor.White;
                    keepgoing = Console.ReadLine().ToLower();
                    while (keepgoing != "y" && keepgoing != "n")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("That is not a valid input.");
                        Console.WriteLine("Would you like to start over? y/n");
                        Console.ForegroundColor = ConsoleColor.White;
                        keepgoing = Console.ReadLine().ToLower();
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Thank you for using G R A D E S. Goodbye!");
        }

        private static void BackToSettings()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to go back to settings");
            Console.ReadLine();
            Console.Clear();
        }

        private static double CheckDoubleGrade()
        {
            bool success = false;
            double num;

            success = double.TryParse(Console.ReadLine(), out num);

            while (!success || num > 100 || num < 0)
            {
                Console.WriteLine("You must enter a number from 0 - 100.");
                Console.WriteLine("Please enter the grade");
                success = double.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        private static string CustomMenu()
        {
            string option;

            Console.WriteLine("************************");
            Console.WriteLine("Please select a setting:");
            Console.WriteLine("************************");
            Console.WriteLine("1. Input custom grades");
            Console.WriteLine("2. Search for a grade");
            Console.WriteLine("3. Grade order lowest to highest");
            Console.WriteLine("4. Grade order highest to lowest");
            Console.WriteLine("5. Reset grades / Default program");
            Console.WriteLine("6. Quit program");
            option = Console.ReadLine();
            while (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6")
            {
                Console.WriteLine("That is not a valid option.");
                option = Console.ReadLine();
            }
            return option;
        }
    }
}
