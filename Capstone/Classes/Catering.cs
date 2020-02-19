using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        public Catering()
        {
            Items = fa.ReadItems();
        }

        protected FileAccess fa = new FileAccess();
        public Dictionary<string, CateringItem> Items { get;}
        public string Message { get; set; }
        public int Quantity { get; set; }

        public bool IsCodeValid(string pc)
        {
            if (Items.ContainsKey(pc))
                return true;
            else
            return false;
        }

        public bool IsQuantityValid(string input)
        {
            if(Int32.TryParse(input,out int result) && result > 0)
            {
                Quantity = result;
                return true;
            }
            return false;
        }

        public bool IsInStock(string pc, int number)
        {
            if (Items[pc].Quantity == 0)
            {
                Message = "SOLD OUT";
                return false;
            }
            if (Items[pc].Quantity - number < 0)
            {
                Message = "Insufficient stock.";
                return false;
            }
                return true;
        }

        public bool DoYouHaveEnoughMoney(string pc, double balance)
        {
            if (balance < (Convert.ToDouble(Items[pc].Price) * Quantity))
                return false;
            else
                return true;
        }

        public void UpdateInventory(string pc, int num)
        {
            Items[pc].Quantity = Items[pc].Quantity - num;
        }



    }
}
