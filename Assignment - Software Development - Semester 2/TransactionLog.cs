using System.Collections.Generic;

namespace Assignment___Software_Development___Semester_2
{
    class TransactionLog
    {
        int x = 0;
        private static TransactionLog TransactionList = new TransactionLog();
        public static TransactionLog Transactions
        {
            get { return TransactionList; }
 
        }
        public List<Transaction> Log = new List<Transaction>();
        private TransactionLog() { }
        public void AddLog(string ItemName, byte ItemID, int ItemQuantity, decimal ItemPricePaid)
        {
            //Add transaction
            Log.Add(new Transaction());
            Log[x].ItemId = ItemID;
            Log[x].ItemName = ItemName;
            Log[x].ItemQuantity = ItemQuantity;
            Log[x].PaidPrice = ItemPricePaid;
            Log[x].Add = true;
            Log[x].OrderDate = System.Convert.ToString(System.DateTime.Now);
            x = x + 1;
        }
        public void TakeLog(string ItemName, byte ItemID, int ItemQuantity, string personName)
        {
            //Take transaction
            Log.Add(new Transaction());
            Log[x].ItemId = ItemID;
            Log[x].ItemName = ItemName;
            Log[x].ItemQuantity = ItemQuantity;
            Log[x].Add = false;
            Log[x].PersonName = personName;
            Log[x].OrderDate = System.Convert.ToString(System.DateTime.Now);
            x = x + 1;
        }
        //All Code below used purely for initising example transaction logs
        public void InitialsLogs()
        {
            //used to input example data so transaction log has more data to output.
            InitAddLog("Pen", 0, 5, System.Convert.ToDecimal(2.50), "10/04/2020 10:50:00");
            InitAddLog("Pencil", 1, 3, System.Convert.ToDecimal(1.50), "10/04/2020 10:53:00");
            InitAddLog("Paper", 2, 120, System.Convert.ToDecimal(8.00), "12/04/2020 12:50:00");
            InitTakeLog("Pen", 0, 1, "13/04/2020 12:25:00", "James"); PersonReport.Persons.InputPersonData("James");
            InitTakeLog("Paper", 2, 4, "13/04/2020 12:26:00", "James"); PersonReport.Persons.InputPersonData("James");
            InitTakeLog("Ruler", 3, 4, "14/04/2020 13:10:00", "Fred"); PersonReport.Persons.InputPersonData("Fred");
            InitAddLog("Paper", 2, 50, System.Convert.ToDecimal(8.00), "16/04/2020 10:50:00");
        }
        public void InitAddLog(string ItemName, byte ItemID, int ItemQuantity, decimal ItemPricePaid, string dateTime)
        {
            //Add transaction
            Log.Add(new Transaction());
            Log[x].ItemId = ItemID;
            Log[x].ItemName = ItemName;
            Log[x].ItemQuantity = ItemQuantity;
            Log[x].PaidPrice = ItemPricePaid;
            Log[x].Add = true;
            Log[x].OrderDate = dateTime;
            x = x + 1;
        }
        public void InitTakeLog(string ItemName, byte ItemID, int ItemQuantity, string dateTime, string personName)
        {
            //Take transaction
            Log.Add(new Transaction());
            Log[x].ItemId = ItemID;
            Log[x].ItemName = ItemName;
            Log[x].ItemQuantity = ItemQuantity;
            Log[x].Add = false;
            Log[x].PersonName = personName;
            Log[x].OrderDate = dateTime;
            x = x + 1;
        }
    }
}
