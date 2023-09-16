using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TODO_LIST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#################################################################################################
            // Program
            //#################################################################################################

            Console.WriteLine("Hello!\n");

            string userInput;
            List<string> availableInput = new List<string> { "a", "s", "r", "e" };
            List<string> todoList = new List<string>();
            bool repeat;
            string description;

            do
            {
                repeat = true;
                userInput = returnUserInput();

                switch (userInput)
                {
                    case "s":
                        Console.WriteLine("[S]ee all TODOs\n");
                        SeeAllTodo();
                        repeat = true;
                        break;
                    case "a":
                        AddaTodo();
                        repeat = true;
                        break;
                    case "r":
                        RemoveToDo();
                        repeat = true;
                        break;
                    case "e":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("\nError...\n");
                        break;
                }
            } while (repeat);


            Console.ReadLine();


            //#################################################################################################
            // Methods
            //#################################################################################################



            // This method prints the list of available options
            void printingOptions()
            {
                List<string> intro = new List<string> { "What do you want to do?", "[S]ee all TODOs", "[A]dd a TODO", "[R]emove a TODO", "[E]xit" };
                foreach (string item in intro)
                {
                    Console.WriteLine(item);
                }
            }

            void printingTodoList(List<string> list)
            {
                foreach (string element in list)
                {
                    Console.WriteLine($"{list.IndexOf(element) + 1}. {element}");
                }
            }



            // This method asks the user to input a value and checks if the value exists in the availavble options, returns the input value as a string
            string returnUserInput()
            {
                string output;
                do
                {
                    printingOptions();
                    output = Console.ReadLine();
                    output = output.ToLower();
                    if (!availableInput.Contains(output))
                    {
                        Console.WriteLine("Incorrect Input\n");
                    }
                } while (!availableInput.Contains(output));
                return output;
            }


            // This method displays the TODO list
            void SeeAllTodo()
            {
                if (todoList.Count == 0)
                {
                    Console.WriteLine("No TODOs have been added yet.\n");
                }
                else
                {
                    printingTodoList(todoList);
                    Console.WriteLine("\n");
                }
            }


            // This method adds an element to the TODO list while checking if the element already exits in the list
            void AddaTodo()
            {
                Console.WriteLine("[A]dd a TODO\n");

                Console.Write("Enter a TODO descripton: ");
                description = Console.ReadLine();
                if (todoList.Contains(description))
                {
                    Console.WriteLine("The description must be unique.\n");
                }
                else if (description.Length == 0)
                {
                    Console.WriteLine("The description cannot be empty.\n");
                }
                else
                {
                    todoList.Add(description);
                    Console.WriteLine($"TODO successfully added: {description}.\n");
                }
            }


            // This method removes an element of the TODO list
            void RemoveToDo()
            {
                Console.WriteLine("[R]emove a TODO\n");
                bool condition;
                Console.WriteLine("Select The index of the TODO you want to remove.\n");
                SeeAllTodo();
                string index = Console.ReadLine();
                bool isInt = int.TryParse(index, out int value);
                condition = isInt && value <= todoList.Count && value > 0 && index.Length != 0;
                if (condition)
                {
                    todoList.RemoveAt(value - 1);
                    Console.WriteLine("\n");
                }
                else if (index.Length == 0)
                {
                    Console.WriteLine("Selected index cannot be empty.\n");
                }
                else
                {
                    Console.WriteLine("The given index is not valid.\n");
                }
            }




        }

    }
}
