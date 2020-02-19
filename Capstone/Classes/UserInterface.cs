using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should 
        // be in this class.


        private Catering catering = new Catering();

        public void RunInterface()
        {
            string input = "";
            Order order = new Order();
            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Display catering items");
                Console.WriteLine("2 - Order");
                Console.WriteLine("3 - Quit");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PrintMenu();
                        break;
                    case "2":
                        Menu2();
                        break;
                    case "3":
                        done = true;
                        order.WriteLog();
                        break;
                    default:
                        Console.WriteLine("Please select 1 , 2 or 3");
                        break;
                }
            }

            void Menu2()
            {
                bool doneInner = false;
                while (!doneInner)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Add money");
                    Console.WriteLine("2 - Select products");
                    Console.WriteLine("3 - Complete transaction");
                    Console.WriteLine("Current account balance: $" + order.Balance);
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            AddMoney();
                            break;
                        case "2":
                            SelectProduct();
                            break;
                        case "3":
                            doneInner = true;
                            CompleteTransaction();
                            break;
                        default:
                            break;
                    }
                }
            }

            void PrintMenu()
            {
                foreach (KeyValuePair<string, CateringItem> kvp in catering.Items)
                {
                    Console.WriteLine("{0, -15}{1,-30}{2,-15}{3, -15}{4, 0}",
                    kvp.Value.ItemCode, kvp.Value.ItemName, kvp.Value.Price,
                    kvp.Value.ItemType, kvp.Value.Quantity);

                }

            }

            void AddMoney()
            {
                bool validAmount = false;
                while (!validAmount)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("How much money would you like to add (can't exceed 5,000$).");
                    validAmount = Int32.TryParse(Console.ReadLine(), out int amount);
                    if (validAmount == false)
                    {
                        Console.WriteLine("Amount was invalid.");
                        continue;
                    }
                    else if ((order.Balance + amount > 5000) || (amount < 1))
                    {
                        validAmount = false;
                        Console.WriteLine("Balance can't exceed 5000$!");
                        Console.WriteLine("Also can't enter less than 1$!");
                        continue;
                    }
                    else
                    {
                        validAmount = true;
                        order.Balance = order.Balance + amount;
                        Console.WriteLine("Currency added to balance: " + amount);
                        order.LogAddMoney(amount);

                    }
                }
            }

            void SelectProduct()
            {
                string productCode = "";
                Console.WriteLine();
                PrintMenu();
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select valid item code.");
                    productCode = Console.ReadLine();
                    if(!catering.IsCodeValid(productCode))
                    {
                        Console.WriteLine("Product code invalid.");
                        continue;
                    }
                    Console.WriteLine("How many would you like?");
                    
                    if (!catering.IsQuantityValid(Console.ReadLine()))
                    {
                        Console.WriteLine("Invalid input. Example 1, 2, 3, etc...");
                        continue;
                    }
                    if(!catering.IsInStock(productCode, catering.Quantity))
                    {
                        Console.WriteLine(catering.Message);
                        continue;
                    }
                    if(!catering.DoYouHaveEnoughMoney(productCode, order.Balance))
                    {
                        Console.WriteLine("You don't have enough money!");
                        continue;
                    }
                    Console.WriteLine(order.AddToCart(productCode, catering.Quantity));
                    catering.UpdateInventory(productCode, catering.Quantity);
                    order.LogTransaction(productCode, catering.Quantity);
                    break;
                }

            }
            void CompleteTransaction()
            {
                Console.WriteLine();
                Console.WriteLine(order.CalculateChange());
                Console.WriteLine();
                Console.WriteLine(order.ScreenReport());
            }
        }
    }
}
