/*
* Author: Sheetal Rana
* Date: 13 Feburary 2025
* Project: Assignment 2 : Task_1
* Description: Program that take information from the unlimited number of customers for Electrician. At the end,
the information is displayed back to the electrician.
*
*/
namespace AssignmentTwoTaskTwo
{
    // Interface to declare the functionality of the base class
    public interface ICustomer
    {
        void DisplaySummary();
        void PerformTask();
    }

    class Program
        {
            static void Main(string[] args)
            {
                // Asking user for customer details and processing
                while (true)
                {
                    try
                    {
                        string name = GetCustomerName();
                        string type = GetBuildingType();
                        int size = GetBuildingSize();
                        int bulbs = GetNumberOfBulbs();
                        int outlets = GetNumberOfOutlets();
                        string creditCard = GetCreditCardNumber();

                        DisplaySummary(name, type, size, bulbs, outlets, creditCard);
                        PerformTask(type);

                        // Ask if the user wants to continue
                        Console.Write("Do you want to enter another customer? (yes/no): ");
                        string response = Console.ReadLine().ToLower();
                        if (response != "yes")
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any unexpected errors
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }

            static string GetCustomerName()
            {
                while (true)
                {
                    Console.Write("Enter Customer Name: ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) return name;
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
            }

            static string GetBuildingType()
            {
                while (true)
                {
                    Console.WriteLine("Select Building Type (House, Barn, Garage): ");
                    string type = Console.ReadLine().ToLower();
                    if (type == "house" || type == "barn" || type == "garage") return type;
                    Console.WriteLine("Invalid input. Please enter House, Barn, or Garage.");
                }
            }

            static int GetBuildingSize()
            {
                while (true)
                {
                    Console.Write("Enter Building Size (1000 - 50000 sqft): ");
                    if (int.TryParse(Console.ReadLine(), out int size) && size >= 1000 && size <= 50000) return size;
                    Console.WriteLine("Invalid size. Please enter a value between 1000 and 50000.");
                }
            }

            static int GetNumberOfBulbs()
            {
                while (true)
                {
                    Console.Write("Enter Number of Bulbs (Max 20): ");
                    if (int.TryParse(Console.ReadLine(), out int bulbs) && bulbs >= 0 && bulbs <= 20) return bulbs;
                    Console.WriteLine("Invalid number. Enter a value between 0 and 20.");
                }
            }

            static int GetNumberOfOutlets()
            {
                while (true)
                {
                    Console.Write("Enter Number of Outlets (Max 50): ");
                    if (int.TryParse(Console.ReadLine(), out int outlets) && outlets >= 0 && outlets <= 50) return outlets;
                    Console.WriteLine("Invalid number. Enter a value between 0 and 50.");
                }
            }

            static string GetCreditCardNumber()
            {
                while (true)
                {
                    Console.Write("Enter 16-digit Credit Card Number: ");
                    string creditCard = Console.ReadLine();
                    if (creditCard.Length == 16 && long.TryParse(creditCard, out _)) return creditCard;
                    Console.WriteLine("Invalid credit card. Enter exactly 16 digits.");
                }
            }

            static void DisplaySummary(string name, string type, int size, int bulbs, int outlets, string creditCard)
            {
                Console.WriteLine("\n--- Customer Summary ---");
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Building Type: {type}");
                Console.WriteLine($"Building Size: {size} sqft");
                Console.WriteLine($"Bulbs: {bulbs}");
                Console.WriteLine($"Outlets: {outlets}");
                Console.WriteLine($"Credit Card: {creditCard.Substring(0, 4)} XXXX XXXX {creditCard.Substring(12)}");
            }

            static void PerformTask(string type)
            {
                switch (type)
                {
                    case "house":
                        Console.WriteLine("Installing fire alarms.");
                        break;
                    case "barn":
                        Console.WriteLine("Wiring milking equipment.");
                        break;
                    case "garage":
                        Console.WriteLine("Installing automatic doors.");
                        break;
                    default:
                        Console.WriteLine("Invalid building type.");
                        break;
                }
            }
        }
    }
