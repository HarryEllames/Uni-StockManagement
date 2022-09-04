using System.Collections.Generic;

namespace Assignment___Software_Development___Semester_2
{

    class ItemList
    {
        public int x = 0;
        private static ItemList _ItemList = new ItemList();
        public static ItemList Items
        {
            get { return _ItemList; }
            set
            {
                _ItemList.SetItemList("EXAMPLE", 0);
            }
        }
        public List<Item> itemList = new List<Item>();
        private ItemList() { }
        private ItemList(string ItemName)
        {
            //adds new items to the system
            itemList.Add(new Item());
            itemList[x].Id = System.Convert.ToByte(x);
            itemList[x].Name = ItemName;
            itemList[x].Quantity = 0;
            itemList[x].PricePaid = 0;
            x = x + 1;
        }
        public void SetItemList(string ItemName, int ItemQuantity)
        {
            //adds new items to the system
            itemList.Add(new Item());
            itemList[x].Id = System.Convert.ToByte(x);
            itemList[x].Name = ItemName;
            itemList[x].Quantity = ItemQuantity;
            itemList[x].PricePaid = 0;

            x = x + 1;
        }
        public void SetItemList(string ItemName, int ItemQuantity, decimal ItemPricePaid)
        {
            //adds new items to the system
            itemList.Add(new Item());
            itemList[x].Id = System.Convert.ToByte(x);
            itemList[x].Name = ItemName;
            itemList[x].Quantity = ItemQuantity;
            itemList[x].PricePaid = ItemPricePaid;

            x = x + 1;
        }
        public void SetItemList(byte ItemID, int ItemQuantity, decimal ItemPricePaid)
        {
            //Used for existing items
            itemList[ItemID].Quantity = itemList[ItemID].Quantity + ItemQuantity;
            itemList[ItemID].PricePaid = itemList[ItemID].PricePaid + ItemPricePaid;

        }
        public string returnName(byte x)
        {
            return itemList[x].Name;
        }
    }
}
