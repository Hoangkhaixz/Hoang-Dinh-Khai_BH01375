using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false; // Loop until exit  is set to true
            while (!exit) 
            {
                Menu();
                string choice = GetChoice(); // Get user's choice from menu
                string name = GetName();  // Get customer name

                if (choice == "5")  // Exit the program if choice is "5"
                {
                    break;
                }
                // Prompt user to enter water usage for last month and this month
                int last_month = Number("Enter water usage last month: ");
                Console.WriteLine("Water usage last month: " + last_month + "m3");
                int this_month = Number("Enter water usage this month: ");
                Console.WriteLine("Water usage this month: " + this_month + "m3");

                // Validate input: this_month should be greater than last_month
                if (last_month <= this_month)
                {
                    break; // Restart the loop if input is invalid
                }
                Console.WriteLine("Invalid input. Please try again..!");
                int consumption = this_month - last_month; // Calculate water consumption
                if (choice == "1") 
                {
                    int NumberOfPeople = int.Parse(Console.ReadLine());
                    double m3 = consumption / (double)  NumberOfPeople; 
                    Console.WriteLine("The average amount of water used by each person is: " + m3 + "m3");
                }
                Console.WriteLine("Water consumption is: " + consumption + " m3");

                // Calculate water price based on choice and consumption
                double waterPrice = GetWaterPrice(choice, consumption);
                Console.WriteLine("Total water bill: " + waterPrice + " VND");

                // Calculate additional fees and taxes
                double envFee = waterPrice * 0.1;
                Console.WriteLine("Environment Fee is: " + envFee + " VND");
                double VAT = waterPrice * 0.1;
                Console.WriteLine("VAT is: " + VAT + " VND");

                double totalBill;
                totalBill = waterPrice + VAT + envFee;
                Console.WriteLine("Total bill is: " + totalBill + " VND");

                Console.WriteLine("===== Please press enter key to continue =====");
                Console.ReadLine(); // Wait for user to press Enter
                Console.Clear(); // Clear console for next iteration
            }
        }
        // // Get user's choice from menu
        static void Menu()
        {
            Console.WriteLine("======= MENU =======");
            Console.WriteLine("1. HouseHold");
            Console.WriteLine("2. Business services");
            Console.WriteLine("3. Administrative agency, public services");
            Console.WriteLine("4. Production units");
            Console.WriteLine("5. Exit the program..!");
        }
        // Validate user input
        static string GetChoice() 
        {
            Console.WriteLine("Enter yourChoice: ");
            string choice = Console.ReadLine();
            while(choice != "1" && choice != "2" && choice != "3" && choice != "4") 
            {
                Console.WriteLine("There is no right type of customer. Please re-enter..!");
                choice = Console.ReadLine();
            }
            return choice;
        }
        // Get customer name input

        static string GetName() 
        {
            Console.WriteLine("Enter the customer name: ");
            string name = Console.ReadLine();
            return name;
        }
        // Prompt user to enter an integer (for water usage inputs)
        static int Number(string message)
        {
            Console.Write(message);
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        // Calculate water price based on choice and consumption
        static double GetWaterPrice(string choice, int consumption) 
        {
            double waterPrice = 0;
            // Switch case to determine price based on user's choice
            switch (choice) 
            {
                case "1": // HouseHold
                    if (consumption <= 10)
                    {
                        waterPrice = 5.973 * consumption;
                    }
                    else if (consumption <= 20)
                    {
                        waterPrice = (10 * 5.973) + ((consumption - 10) * 7.052);
                    }
                    else if (consumption <= 30)
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + ((consumption - 20) * 8.699);
                    }
                    else 
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + ((consumption - 30) * 15.929);
                    }
                    break;
                case "2": // Business services
                    waterPrice = consumption * 22.068;
                    break;
                case "3": // Administrative agency, public services
                    waterPrice = consumption * 9.955;
                    break;
                case "4": // Production units
                    waterPrice = consumption * 11.615;
                    break;
                case "5": // Exit the program
                    Console.WriteLine("Exit the programm..!");
                    Environment.Exit(0);
                    break;
            }
            return waterPrice;
        }
    }
}
