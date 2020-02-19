using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{ 
    public class Order : Catering, ILog
    {
        public Order()
        {
            Balance = 0;
        }

        private List<string[]> CartList = new List<string[]>();
        public double Balance { get; set; }
        private string message = "";
        private string time = "";
        public string TheLog { get; set; }

        public string AddToCart(string pc, int quantity)
        {
            string[] newItem = { quantity.ToString(), Items[pc].ItemType, Items[pc].ItemName, Items[pc].Price,
               (Convert.ToDouble(Items[pc].Price) * quantity).ToString() };
            newItem[1] = ItemTypeConverter(newItem[1]);
            CartList.Add(newItem);
            Balance = Balance - (Convert.ToDouble(Items[pc].Price) * quantity);
            message = String.Format("You added: {0} {1} to the cart.", quantity, Items[pc].ItemName);

            return message;
        }

        public string ItemTypeConverter(string type)
        {
            string newType = "";
            if (type == "B")
                newType = "Beverage";
            else if (type == "A")
                newType = "Appetizer";
            else if (type == "E")
                newType = "Entree";
            else if (type == "D")
                newType = "Dessert";
            else
                newType = type;
            return newType;
        }

        public string CalculateChange()
        {

            int twenties = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            double newBalance = Balance;
            twenties = (int)Balance / 20;
            Balance = Balance % 20;
            tens = (int)Balance / 10;
            Balance = Balance % 10;
            fives = (int)Balance / 5;
            Balance = Balance % 5;
            ones = (int)Math.Floor(Balance);

            Balance = Math.Round((Balance - ones) * 100);

            quarters = (int)Balance / 25;
            Balance = Balance % 25;
            dimes = (int)Balance / 10;
            Balance = Balance % 10;
            nickels = (int)Balance / 5;
            Balance = 0;
            LogGiveChange(newBalance);

            message = $"Change due: {twenties} Twenties {tens} Tens" +
                    $" {fives} Fives {ones} Ones {quarters} Quarters " +
                    $"{dimes} Dimes {nickels} Nickels.";

            return message;
        }

        public void LogAddMoney(double money)
        {
            time = DateTime.Now.ToString();
            TheLog += time + " ADD MONEY: $" + money + " $" + Balance + "\n";

        }

        public void LogGiveChange(double change)
        {
            time = DateTime.Now.ToString();
            TheLog += time + " GIVE CHANGE: $" + change + " $" + Balance + "\n";
        }

        public void LogTransaction(string pc, int quantity)
        {
            time = DateTime.Now.ToString();
            string totalPrice = (Convert.ToDouble(Items[pc].Price) * quantity).ToString();
            TheLog += $"{time} {quantity} {Items[pc].ItemName} {Items[pc].ItemCode} ${totalPrice} ${Balance}\n";

        }

        public string ScreenReport()
        {
            string report = "";
            double priceTotal = 0;
            foreach (string[] item in CartList)
            {
                report += String.Format($"{ item[0],-5} { item[1],-10} { item[2],-15} { item[3],-15} { item[4],0}\n");
                priceTotal += Convert.ToDouble(item[4]);
            }
            report += "\nTotal: $" + priceTotal;

            return report;
        }

        public void WriteLog()
        {
            fa.WriteItems(TheLog);
        }
    }
}
