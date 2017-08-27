using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShopCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShopCart.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        [TestMethod()]
        public void CalculatePriceTest_五集買的本數_1_0_0_0_0_總價_100()
        {
            // arrange
            var shoppingCart = new ShoppingCart();
            var buiedPotterSeries = new[] { 1, 0, 0, 0, 0 };

            var expected = 100;

            // act
            var actual = shoppingCart.CalculatePotterPrice(buiedPotterSeries);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}