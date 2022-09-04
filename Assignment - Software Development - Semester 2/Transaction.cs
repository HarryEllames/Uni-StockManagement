namespace Assignment___Software_Development___Semester_2
{
    class Transaction
    {
        public bool Add = true; // Add = True, Remove = False
        public string PersonName = "N/A";
        public byte ItemId = 0;
        public string ItemName;
        public int ItemQuantity;
        public decimal PaidPrice = 0;
        public string OrderDate; //System.Convert.ToString(System.DateTime(Year, Month, Day, Hour, Minute, Second))
    }
}
