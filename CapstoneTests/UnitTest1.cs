using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        Catering ci = new Catering();

        [TestMethod]
        public void AddToCartTest()
        {
            Order order = new Order();

            Assert.AreEqual("You added: 5 Cake to the cart.", order.AddToCart("D2", 5));
            Assert.AreEqual("You added: 15 Beer to the cart.", order.AddToCart("B3", 15));
        }
        [TestMethod]
        public void ItemTypeConverterTest()
        {
            Order order = new Order();

            Assert.AreEqual("Beverage", order.ItemTypeConverter("B"));
            Assert.AreEqual("Entree", order.ItemTypeConverter("E"));
            Assert.AreEqual("Z", order.ItemTypeConverter("Z"));
        }
        [TestMethod]
        public void CalculateChangeTest()
        {
            Order order = new Order();
            order.Balance = 196.65;
            Assert.AreEqual("Change due: 9 Twenties 1 Tens 1 Fives 1 Ones 2 Quarters 1 Dimes 1 Nickels.",order.CalculateChange());
            order.Balance = 85.40;
            Assert.AreEqual("Change due: 4 Twenties 0 Tens 1 Fives 0 Ones 1 Quarters 1 Dimes 1 Nickels.", order.CalculateChange());
            order.Balance = 14.05;
            Assert.AreEqual("Change due: 0 Twenties 1 Tens 0 Fives 4 Ones 0 Quarters 0 Dimes 1 Nickels.", order.CalculateChange());
        }
        [TestMethod]
        public void IsCodeValidTest()
        {
            Assert.AreEqual(false, ci.IsCodeValid("b3"));
            Assert.AreEqual(true, ci.IsCodeValid("B3"));
            Assert.AreEqual(false, ci.IsCodeValid("D6"));
        }
    }
}
