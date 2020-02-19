using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item
        public CateringItem(string[] arr)
        {
            ItemCode = arr[0];
            ItemName = arr[1];
            Price = arr[2];
            ItemType = arr[3];
            Quantity = 50;
        }
        public string ItemCode { get;}
        public string ItemName { get;}
        public string Price { get;}
        public string ItemType { get;}
        public int Quantity { get; set; }


    }
}
