using System;
using System.Collections.Generic;

namespace StockManagement
{
    class Program
    {
        public static AdminUI adminUI { get; private set; }

        static void Main(string[] args)
        {
            StockManager mgr = new StockManager();
            TransactionManager tm = new TransactionManager();
            adminUI = new AdminUI(mgr, tm);

            bool systemActive = true;

            while(systemActive)
            {
                DisplayMenu();
                int menuInput = ReadInteger("\n    Please choose a menu option:\n    > ");

                switch (menuInput)
                {
                    case 1:
                        AddANewItemOfStock();
                        break;

                    case 2:
                        AddQuantityToAStockItem();
                        break;

                    case 3:
                        DeleteAStockItem();
                        break;

                    case 4:
                        RemoveQuantityFromAStockItem();
                        break;

                    case 5:
                        ViewStockLevel();
                        break;

                    case 6:
                        ViewTransactionLog();
                        break;

                    case 7:
                        systemActive = false;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n    ==============================");
                        Console.WriteLine("    System shutting down, goodbye.");
                        Console.WriteLine("    ==============================");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n    Press any key to continue...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n    USER ERROR: Please select a valid menu option");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("    Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }

            }

        }

        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Menu Options");
            Console.WriteLine("    ------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Stock managemnt functions:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1) Add a new item to stock.");
            Console.WriteLine("\t2) Add a quantity to an existing stock item.");
            Console.WriteLine("\t3) Delete an item from stock.");
            Console.WriteLine("\t4) Remove a quantity from an existing stock item.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    Reporting functions:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t5) View stock levels.");
            Console.WriteLine("\t6) View stock transactions.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t7) EXIT.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DisplayResults(List<string> results)
        {
            foreach (string result in results)
            {
                Console.WriteLine($"\n    {result}");
            }
        }

        private static int ReadInteger(string prompt)
        {
            {
                int num = 0;
                bool dataOK = false;

                while (!dataOK)
                {

                    try
                    {
                        Console.Write(prompt);
                        num = Convert.ToInt32(Console.ReadLine());
                        dataOK = true;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n    USER ERROR: Please an integer");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("    Press any key to continue...");
                        Console.ReadKey();
                    }

                }
                return num;
            }
        }
    

        private static string ReadString(string prompt)
        {
            Console.Write($"    {prompt}");
            string str = Console.ReadLine();
            string cleanStr = str.Trim();
            return cleanStr;
        }

        private static void AddANewItemOfStock()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Add a new item to stock");
            Console.WriteLine("    -----------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Please input the details of the new item:");
            Console.ForegroundColor = ConsoleColor.White;

            int itemCode = ReadInteger("\n    Please input new item code:\n    > ");
            string itemName = ReadString("\n    Please input new item name:\n    > ");
            int itemQty = ReadInteger("\n    Please input new item quantity:\n    > ");

            List<string> systemFeedback = adminUI.AddANewItemOfStock(itemCode, itemName, itemQty);
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AddQuantityToAStockItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Add a quantity to an existing stock item");
            Console.WriteLine("    ----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Please input the details of the stock addition:");
            Console.ForegroundColor = ConsoleColor.White;

            int itemCode = ReadInteger("\n    Please input the item code:\n    > ");
            int itemQty = ReadInteger("\n    Please input quantity to add to stock:\n    > ");

            List<string> systemFeedback = adminUI.AddQuantityToAStockItem(itemCode, itemQty);
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DeleteAStockItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Delete a stock item");
            Console.WriteLine("    -------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Please input the details of the item to delete:");
            Console.ForegroundColor = ConsoleColor.White;

            int itemCode = ReadInteger("\n    Please input the item code:\n    > ");
            
            List<string> systemFeedback = adminUI.DeleteAStockItem(itemCode);
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void RemoveQuantityFromAStockItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Remove a quantity to an existing stock item");
            Console.WriteLine("    -------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Please input the details of the stock subtraction:");
            Console.ForegroundColor = ConsoleColor.White;

            int itemCode = ReadInteger("\n    Please input the item code:\n    > ");
            int itemQty = ReadInteger("\n    Please input quantity to remove from stock:\n    > ");

            List<string> systemFeedback = adminUI.RemoveQuantityFromAStockItem(itemCode, itemQty);
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ViewStockLevel()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Stock levels report");
            Console.WriteLine("    -------------------");
            Console.ForegroundColor = ConsoleColor.White;

            List<string> systemFeedback = adminUI.ViewStockLevels();
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ViewTransactionLog()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n    ============================");
            Console.WriteLine("    STOCK MANAGER USER INTERFACE");
            Console.WriteLine("    ============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    Transaction activity report");
            Console.WriteLine("    ---------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            List<string> systemFeedback = adminUI.ViewTransactionLog();
            DisplayResults(systemFeedback);
            Console.WriteLine("\n    Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
