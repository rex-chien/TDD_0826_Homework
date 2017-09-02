using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PotterShopCart.Tests
{
    [TestClass]
    [Ignore]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_0_0_0_0_總價_100()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                    ep1Count: 1
                );

            AssertPriceShouldEqual(100, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_0_0_0_總價_190()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 1
            );

            AssertPriceShouldEqual(190, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_1_0_0_總價_270()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 1,
                ep3Count: 1
            );

            AssertPriceShouldEqual(270, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_1_1_0_總價_320()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 1,
                ep3Count: 1,
                ep4Count: 1
            );

            AssertPriceShouldEqual(320, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_1_1_1_總價_375()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 1,
                ep3Count: 1,
                ep4Count: 1,
                ep5Count: 1
            );

            AssertPriceShouldEqual(375, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_1_2_0_0_總價_370()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 1,
                ep3Count: 2
            );

            AssertPriceShouldEqual(370, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_1_2_2_0_0_總價_460()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 1,
                ep2Count: 2,
                ep3Count: 2
            );

            AssertPriceShouldEqual(460, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_2_2_2_1_1_總價_640()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 2,
                ep2Count: 2,
                ep3Count: 2,
                ep4Count: 1,
                ep5Count: 1
            );

            AssertPriceShouldEqual(640, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_2_2_2_2_1_總價_695()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 2,
                ep2Count: 2,
                ep3Count: 2,
                ep4Count: 2,
                ep5Count: 1
            );

            AssertPriceShouldEqual(695, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_4_4_4_2_2_總價_1280()
        {
            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count: 4,
                ep2Count: 4,
                ep3Count: 4,
                ep4Count: 2,
                ep5Count: 2
            );

            AssertPriceShouldEqual(1280, books);
        }

        [TestMethod]
        public void CalculatePriceTest_五集買的本數_0_0_0_0_0_總價_0()
        {
            var books = GeneratePotterBooksByEpisodeCount();

            AssertPriceShouldEqual(0, books);
        }

        private List<PotterBook> GeneratePotterBooksByEpisodeCount(
            int ep1Count = 0, int ep2Count = 0, int ep3Count = 0,
            int ep4Count = 0, int ep5Count = 0)
        {
            var books = new List<PotterBook>();

            books.AddRange(Enumerable.Repeat(new PotterBook { Episode = 1 }, ep1Count));
            books.AddRange(Enumerable.Repeat(new PotterBook { Episode = 2 }, ep2Count));
            books.AddRange(Enumerable.Repeat(new PotterBook { Episode = 3 }, ep3Count));
            books.AddRange(Enumerable.Repeat(new PotterBook { Episode = 4 }, ep4Count));
            books.AddRange(Enumerable.Repeat(new PotterBook { Episode = 5 }, ep5Count));

            return books;
        }

        private void AssertPriceShouldEqual(int expectedPrice, List<PotterBook> books)
        {
            var sut = new ShoppingCart();

            var actual = sut.CalculateSuitePrice(books);

            // assert
            Assert.AreEqual(expectedPrice, actual);
        }
    }
}