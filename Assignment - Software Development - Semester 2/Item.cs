using System;

namespace Assignment___Software_Development___Semester_2
{
    public class Item
    {
        public byte Id;  //Item Id[order of when added]
        public string Name; //Item Name[Id number]
        public int Quantity =  0; // Item Quantity[Id Number]
        public decimal PricePaid = 0;



        public Item()
        {
            // used to initially create item
            Id = 000;
            Name = "ItemName";
            Quantity = 0;
            
        }

        public Item(byte ItemID, string ItemName)
        {
            // used to initially create item
            Id = ItemID;
            Name = ItemName;
            Quantity = 0;
        }
        public Item(byte ItemID, string ItemName, int ItemQuantity)
        {
            //and price paid and date
            Id = ItemID;
            Name = ItemName;
            Quantity = Quantity + ItemQuantity;
            
        }
        
    }
}
