/*
* Author: Sheetal Rana
* Date: 14 Feburary 2025
* Project: Assignment 2 : Task_1
* Description: For this assignment use the same problem you worked on for Task 1.
1. Create an interface, which will declare the functionality of the base class including all
methods and properties.
2. Implement a base class as abstract (declaring supplementary tasks as abstract
method).
3. Derive all classes from this abstract class, implementing, overloading and overriding
methods as needed. Remember that abstract methods are virtual.

*
*/
using System;

namespace AssignmentTwoTaskTwo
{
    // Interface to declare the functionality of the base class
    public interface ICustomer
    {
        void DisplaySummary();
        void PerformTask();
    }
    // Abstract base class implementing the interface
    public abstract class Customer : ICustomer
    {
        public string Name;
        public string BuildingType;
        public int BuildingSize;
        public int Bulbs;
        public int Outlets;
        public string CreditCard;

        public void DisplaySummary()
        {
            Console.WriteLine("\n--- Customer Summary ---");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Building Type: {BuildingType}");
            Console.WriteLine($"Building Size: {BuildingSize} sqft");
            Console.WriteLine($"Bulbs: {Bulbs}");
            Console.WriteLine($"Outlets: {Outlets}");
            Console.WriteLine($"Credit Card: {CreditCard.Substring(0, 4)} XXXX XXXX {CreditCard.Substring(12)}");
        }

        public abstract void PerformTask(); // Declaring supplementary task as an abstract method
    }

    // Derived class for HouseCustomer
    public class HouseCustomer : Customer
    {
        public override void PerformTask()
        {
            Console.WriteLine("Installing fire alarms.");
        }
    }

    // Derived class for BarnCustomer
    public class BarnCustomer : Customer
    {
        public override void PerformTask()
        {
            Console.WriteLine("Wiring milking equipment.");
        }
    }

    // Derived class for GarageCustomer
    public class GarageCustomer : Customer
    {
        public override void PerformTask()
        {
            Console.WriteLine("Installing automatic doors.");
        }
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
                    Customer customer = GetCustomerDetails();
                    customer.DisplaySummary();
                    customer.PerformTask();

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
        static Customer GetCustomerDetails()
        {
            string name = GetCustomerName();
            string type = GetBuildingType();
            int size = GetBuildingSize();
            int bulbs = GetNumberOfBulbs();
            int outlets = GetNumberOfOutlets();
            string creditCard = GetCreditCardNumber();

            Customer customer;
            switch (type)
            {
                case "house":
                    customer = new HouseCustomer();
                    break;
                case "barn":
                    customer = new BarnCustomer();
                    break;
                case "garage":
                    customer = new GarageCustomer();
                    break;
                default:
                    throw new Exception("Invalid building type.");
            }

            customer.Name = name;
            customer.BuildingType = type;
            customer.BuildingSize = size;
            customer.Bulbs = bulbs;
            customer.Outlets = outlets;
            customer.CreditCard = creditCard;

            return customer;
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
                try
                {
                    int size = int.Parse(Console.ReadLine());
                    if (size >= 1000 && size <= 50000) return size;
                    Console.WriteLine("Invalid size. Please enter a value between 1000 and 50000.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static int GetNumberOfBulbs()
        {
            while (true)
            {
                Console.Write("Enter Number of Bulbs (Max 20): ");
                try
                {
                    int bulbs = int.Parse(Console.ReadLine());
                    if (bulbs >= 0 && bulbs <= 20) return bulbs;
                    Console.WriteLine("Invalid number. Enter a value between 0 and 20.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static int GetNumberOfOutlets()
        {
            while (true)
            {
                Console.Write("Enter Number of Outlets (Max 50): ");
                try
                {
                    int outlets = int.Parse(Console.ReadLine());
                    if (outlets >= 0 && outlets <= 50) return outlets;
                    Console.WriteLine("Invalid number. Enter a value between 0 and 50.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
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
    }
}
