
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


/*Break the provided code into the following methods

Main Method: Calls the Menu method.
Menu Method: Displays the menu, reads user input, and calls the appropriate method based on 
the user's choice.
PrintNumbers Method: Handles the functionality to print numbers from a start to an end value.
PerformAlgebra Method: Displays a submenu for choosing an equation, reads input values, 
and calls the appropriate method for the selected equation.
SolveEquation1 Method: Solves the equation 
y=2x+3.
SolveEquation2 Method: Solves the equation 
y=ax2+bx.
SolveEquation3 Method: Solves the equation 
y=a(x−b)(x+c).
WorkWithNames Method: Prompts the user to enter names, stores them in an array, and 
displays the entered names.
Add, Subtract, Multiply, Divide Methods: Basic arithmetic operations used by the 
equation-solving methods. These methods handle the arithmetic operations and can be 
reused for different calculations.*/


namespace Prog120_S24_L9_Methods
{

    class Program
    {
        internal static class Method
        { 
           static void Main()
           {
            
            bool condition = true;
            Console.WriteLine("\nVitalii Bobyr - 05/27/24");
            Console.WriteLine("Programming 120 - S24_L9_Methods\n");
                #region start_menu
            while (condition)
            {
                Console.OutputEncoding = Encoding.Unicode;
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Print from one number to another using loops");
                    Console.WriteLine("2. Perform an algebra level equation");
                    Console.WriteLine("3. Work with an array of names");
                    Console.WriteLine("4. Exit");
                                             
                string choice;
                choice = Console.ReadLine().ToLower();

                try
                {

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Print from one number to another using loops");
                            PrintNumbers();
                            break;

                        case "2":
                            Console.WriteLine("Perform an algebra level equation");
                            PerformAlgebra();
                            break;

                        case "3":
                            Console.WriteLine("Work with an array of names");
                            WorkWithNames();
                            break;

                        case "4":
                             Console.WriteLine("Exit from progarm");
                             condition = false;
                             break;

                        default: Console.WriteLine("Invalid option. Please choose again.");
                                break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something going wrong! Please try again!");
                        break;
                };
                    #endregion

                    #region Methods
                    static void PrintNumbers()
                    {
                        Console.Write("Enter the starting number: ");
                        int start = int.Parse(Console.ReadLine());
                        Console.Write("Enter the ending number: ");
                        int end = int.Parse(Console.ReadLine());

                        if (start <= end)
                        {
                            for (int i = start; i <= end; i++) { Console.WriteLine(i); }
                                   
                        }
                        else
                        {
                            for (int i = start; i >= end; i--) { Console.WriteLine(i); }
                        }
                    }

                    static void PerformAlgebra()
                    {
                        Console.WriteLine("Choose an equation to solve:");
                        Console.WriteLine("1. y = 2x + 3");
                        Console.WriteLine("2. y = ax^2 + bx");
                        Console.WriteLine("3. y = a(x - b)(x + c)");
                        Console.Write("Choose an equation (1-3): ");
                        string equationChoice = Console.ReadLine();

                        if (equationChoice == "1") { SolveEquation1(); }
                        else if (equationChoice == "2") { SolveEquation2(); }
                        else if (equationChoice == "3") { SolveEquation3(); }
                        else { Console.WriteLine("Invalid option. Returning to main menu."); }
                                                                            
                    }
                                        
                               }

                static void SolveEquation1()
                {
                    Console.Write("Enter the value for x: ");
                    double x = double.Parse(Console.ReadLine());
                    double y = Add(Multiply(2, x), 3);
                    Console.WriteLine($"The result of 2 * {x} + 3 is {y}");
                }

                static void SolveEquation2()
                {
                    Console.Write("Enter the value for a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for x: ");
                    double x = double.Parse(Console.ReadLine());
                    double y = Add(Multiply(a, Multiply(x, x)), Multiply(b, x));
                    Console.WriteLine($"The result of {a} * {x}^2 + {b} * {x} is {y}");
                }

                static void SolveEquation3()
                {
                    Console.Write("Enter the value for a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for c: ");
                    double c = double.Parse(Console.ReadLine());
                    Console.Write("Enter the value for x: ");
                    double x = double.Parse(Console.ReadLine());
                    double y = Multiply(a, Multiply(Subtract(x, b), Add(x, c)));
                    Console.WriteLine($"The result of {a} * ({x} - {b}) * ({x} + {c}) is {y}");
                }

                static void WorkWithNames()
                {
                    string[] names = new string[5];
                    for (int i = 0; i < names.Length; i++)
                    {
                        Console.Write($"Enter name {i + 1}: ");
                        names[i] = Console.ReadLine();
                    }

                    Console.WriteLine("You entered the following names:");
                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                    }
                }

                static double Add(double a, double b) { return a + b; }               
                static double Subtract(double a, double b) { return a - b; }
                static double Multiply(double a, double b) { return a * b; }
                static double Divide(double a, double b)
                {
                    if (b == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return a / b;
                }

                #endregion
            }

        }
    }
}