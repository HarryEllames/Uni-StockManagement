using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Software_Development___Semester_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            PersonReport.Persons.Report.Add(new Person());


            // Creates items in inventory  --------------------------------------------------------------------------------------------

            ItemList.Items.SetItemList("Pen", 23); ItemList.Items.SetItemList("Pencil", 11); ItemList.Items.SetItemList("Paper", 253); ItemList.Items.SetItemList("Ruler", 4); ItemList.Items.SetItemList("Rubber", 17); ItemList.Items.SetItemList("Calculator", 0);
            TransactionLog.Transactions.InitialsLogs();
            // ---------------------------------------------------------------------------------------  Creates items in inventory ----

            printMenu(ItemList.Items.itemList);
            //--------------------------------------------------------- 'ItemList.Items.itemList' ------------- 

        }

        public static string TakeFromStock(List<Item> LstItem)
        {
            Console.WriteLine("------------------------- Take From Stock -------------------------");
            int i = 0;
            Console.WriteLine("Existing items listed below");
            foreach (Item itm in LstItem)
            {
                // prints out all Items
                Console.WriteLine("{0}. Item ID: {1}, Item Name: {2}, Item Quantity Availible: {3}", i, itm.Id, itm.Name, itm.Quantity);
                i = i + 1;
            }
            Console.WriteLine("Enter the Item number of the item you wish to remove");
            try
            {
                int newQuantity;
                var selection = Console.ReadLine();
                
                    Console.WriteLine("You have selected {0}", LstItem[Convert.ToByte(selection)].Name);
                Console.WriteLine("What is your name?");
                string userName = Console.ReadLine();
                PersonReport.Persons.InputPersonData(userName);
                
                Console.WriteLine("How many of this item do you wish to take?");
                newQuantity = Convert.ToInt32(Console.ReadLine());
                if (LstItem[Convert.ToByte(selection)].Quantity - newQuantity < 0)
                {
                    Console.WriteLine("Invalid Amount. Cannot withdraw more than is in stock");
                    TakeFromStock(LstItem);
                }
                else
                {
                    newQuantity = 0 - newQuantity;
                    ItemList.Items.SetItemList(Convert.ToByte(selection), newQuantity, 0);
                    TransactionLog.Transactions.TakeLog(ItemList.Items.itemList[Convert.ToByte(selection)].Name, ItemList.Items.itemList[Convert.ToByte(selection)].Id, newQuantity, userName);
                }
            }
            catch (Exception)
            {
                // catches exceptions if the user inputs an invalid value or no value at all.
                Console.WriteLine("INVALID INPUT. Please try again.");
                Console.WriteLine();
                TakeFromStock(LstItem);
            }
            return "";
        }

        public static string InventoryReport(List<Item> LstItem)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------- Inventory Report: -------------------------");
            foreach (Item itm in LstItem)
            {
                // prints out all Items
                Console.WriteLine("Item ID: {0}, Item Name: {1}", itm.Id, itm.Name);
                Console.WriteLine("Item Quantity: {0}", itm.Quantity);
                Console.WriteLine();
            }
            return "";
        }
        public static string FinanceReport(List<Item> LstItem)
        {
            decimal TotalExpenditure = 0;
            Console.WriteLine();
            Console.WriteLine("------------------------- Finance Report: -------------------------");
            foreach (Item itm in LstItem)
            {
                // prints out all Items
                Console.WriteLine("Item ID: {0}, Item Name: {1}", itm.Id, itm.Name);
                Console.WriteLine("Item Cost: £{0}", itm.PricePaid);
                Console.WriteLine();
                TotalExpenditure = TotalExpenditure + itm.PricePaid;
            }
            Console.WriteLine("Total Expenditure = £{0}", TotalExpenditure);
            return "";
        }
        public static string Transactions(List<Transaction> LstTransactions)
        {

            Console.WriteLine();
            Console.WriteLine("------------------------- Transaction Log: -------------------------");
            foreach (Transaction trans in LstTransactions)
            {
                // prints out all Items
                if(trans.Add == true)
                {
                    Console.WriteLine("Transaction type: Add to Stock");
                    Console.WriteLine("Transaction Date/Time: {0}", trans.OrderDate);
                    Console.WriteLine("Item Cost: £{0}", trans.PaidPrice);
                }
                else
                {
                    Console.WriteLine("Transaction type: Take from Stock");
                    Console.WriteLine("Transaction Date/Time: {0}", trans.OrderDate);
                    Console.WriteLine("Item taken out by: {0}", trans.PersonName);
                }
                Console.WriteLine("Item Code: {0}, Item Name: {1}", trans.ItemId, trans.ItemName);
                
                Console.WriteLine();

            }
            return "";
        }

        public static string PersonalUseage(List<Transaction> LstTransactions, List<Person> LstPerson)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------- Report Personal Useage: -------------------------");
            int prsonCount = 0;
            int transCount = 0;
            foreach (Person prson in LstPerson)
            {
                Console.WriteLine("Person Name: {0}", LstPerson[prsonCount].PersonName);
                foreach (Transaction trans in LstTransactions)
                {
                    if(LstPerson[prsonCount].PersonName == LstTransactions[transCount].PersonName)
                    {
                        Console.WriteLine("    Item Number: '{0}', Item Name: '{1}', Date Taken: {2}", LstTransactions[transCount].ItemId, LstTransactions[transCount].ItemName, LstTransactions[transCount].OrderDate);
                    }
                    // prints out all Items
                    transCount = transCount + 1;
                }
                prsonCount = prsonCount + 1;
                transCount = 0;
            }
            return "";
        }

        public static string AddToStock(List<Item> LstItem)
        {
            Console.WriteLine("------------------------- Add To Stock -------------------------");
            int i = 0;
             Console.WriteLine("Do you want to add a new item or an existing item?");
             Console.WriteLine("Existing items listed below");
             foreach (Item itm in LstItem)
             {
                // prints out all Items
                Console.WriteLine("{0}. Item ID: {1}, Item Name: {2}", i, itm.Id, itm.Name);
                i = i + 1; 
             }
             Console.WriteLine("If item exists, enter number, if not type 'new'");
            //wrapped in exception handling block
            try
            {
                int newQuantity;
                decimal newPricePaid;
                var selection = Console.ReadLine();
                if (selection == "new")
                {
                    Console.WriteLine("What is the Name of your item?");
                    string newItemName = Console.ReadLine();
                    Console.WriteLine("How many of this item do you wish to add?");
                    newQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How much did you pay for this?");
                    newPricePaid = Convert.ToDecimal(Console.ReadLine());
                    ItemList.Items.SetItemList(newItemName, newQuantity, newPricePaid);
                    
                    byte a = Convert.ToByte(ItemList.Items.x -1);
                    TransactionLog.Transactions.AddLog(ItemList.Items.itemList[a].Name, ItemList.Items.itemList[a].Id, newQuantity, newPricePaid);

                }
                else
                {
                    Console.WriteLine("You have selected {0}", LstItem[Convert.ToByte(selection)].Name);
                    
                    Console.WriteLine("How many of this item do you wish to add?");
                    newQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How much did you pay for this?");
                    newPricePaid = Convert.ToDecimal(Console.ReadLine());
                    ItemList.Items.SetItemList(Convert.ToByte(selection), newQuantity, newPricePaid);
                    TransactionLog.Transactions.AddLog(ItemList.Items.itemList[Convert.ToByte(selection)].Name, ItemList.Items.itemList[Convert.ToByte(selection)].Id, newQuantity, newPricePaid);
                }

            }
            catch (Exception)
            {
                // catches exceptions if the user inputs an invalid value or no value at all.
                Console.WriteLine("INVALID INPUT. Please try again.");
                Console.WriteLine();
                AddToStock(LstItem);
            }
             return"";
        }
        
     
        public static string printMenu(List<Item> ItemList)
        {
            Console.WriteLine(" ------------------------- Menu -------------------------");
            Console.WriteLine("Press the appropriate number followed by the 'ENTER' key");
            Console.WriteLine("1. Add to stock");
            Console.WriteLine("2. Take from stock");
            Console.WriteLine("3. Inventory report");
            Console.WriteLine("4. Financial report");
            Console.WriteLine("5. Transaction Log");
            Console.WriteLine("6. Personal Useage Report");
            Console.WriteLine("Press 'Z' to exit");
            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You have selected Add To Stock");
                        AddToStock(ItemList);
                        break;

                    case "2":
                        Console.WriteLine("You have selected Take From Stock");
                        TakeFromStock(ItemList);
                        break;
                    case "3":
                        Console.WriteLine("You have selected Inventory Report");
                        InventoryReport(ItemList);
                    break;
                    case "4":
                        Console.WriteLine("You have selected Financial Report");
                        FinanceReport(ItemList);

                        break;
                    case "5":
                        Console.WriteLine("You have selected Transaction Log");
                        Transactions(TransactionLog.Transactions.Log);
                        break;
                    case "6":
                        Console.WriteLine("You have selected Personal Useage Report");
                        PersonalUseage(TransactionLog.Transactions.Log, PersonReport.Persons.Report); // NEED TO CREATE
                        break;
                    case "z":
                        Console.WriteLine("Menu selection loop exited");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.WriteLine("Menu Reloaded ...");
                        printMenu(ItemList);
                        break;
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID INPUT");
                printMenu(ItemList);
            }

            Console.WriteLine("do you wish to continue? (Y/N)");
            string yn = Console.ReadLine();
            if (yn == "Y")
            {
                printMenu(ItemList);
            } 
            else if(yn == "y") { printMenu(ItemList); }
            else { Console.WriteLine("Menu Exited"); }
            return "";
        }

        
    }
}
