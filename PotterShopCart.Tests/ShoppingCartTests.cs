using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShopCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShopCart.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_0_0_0_0_總價_100()
        {
            // arrange
            var shoppingCart = new ShoppingCart();
            var buyedPotterSeries = new[] { 1, 0, 0, 0, 0 };

            var expected = 100;

            // act
            var actual = shoppingCart.CalculatePotterPrice(buyedPotterSeries);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_0_0_0_總價_190()
        {
            // arrange
            var shoppingCart = new ShoppingCart();
            var buyedPotterSeries = new[] { 1, 1, 0, 0, 0 };

            var expected = 190;

            // act
            var actual = shoppingCart.CalculatePotterPrice(buyedPotterSeries);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_1_0_0_總價_270()
        {
            // arrange
            var shoppingCart = new ShoppingCart();
            var buyedPotterSeries = new[] { 1, 1, 1, 0, 0 };

            var expected = 270;

            // act
            var actual = shoppingCart.CalculatePotterPrice(buyedPotterSeries);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_1_1_0_總價_320()
        {
            // arrange
            var shoppingCart = new ShoppingCart();
            var buyedPotterSeries = new[] { 1, 1, 1, 1, 0 };

            var expected = 320;

            // act
            var actual = shoppingCart.CalculatePotterPrice(buyedPotterSeries);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}