using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace PotterShopCart.Tests
{
    [Binding]
    public class PotterShoppingCartSteps
    {
        private ShoppingCart target = new ShoppingCart();

        [Given(@"第一集買了 (.*) 本")]
        public void Given第一集買了本(int ep1Count)
        {
            ScenarioContext.Current.Set(ep1Count, "ep1Count");
        }
        
        [Given(@"第二集買了 (.*) 本")]
        public void Given第二集買了本(int ep2Count)
        {
            ScenarioContext.Current.Set(ep2Count, "ep2Count");
        }
        
        [Given(@"第三集買了 (.*) 本")]
        public void Given第三集買了本(int ep3Count)
        {
            ScenarioContext.Current.Set(ep3Count, "ep3Count");
        }
        
        [Given(@"第四集買了 (.*) 本")]
        public void Given第四集買了本(int ep4Count)
        {
            ScenarioContext.Current.Set(ep4Count, "ep4Count");
        }
        
        [Given(@"第五集買了 (.*) 本")]
        public void Given第五集買了本(int ep5Count)
        {
            ScenarioContext.Current.Set(ep5Count, "ep5Count");
        }
        
        [When(@"結帳")]
        public void When結帳()
        {
            var currentContext = ScenarioContext.Current;

            var ep1Count = currentContext.Get<int>("ep1Count");
            var ep2Count = currentContext.Get<int>("ep2Count");
            var ep3Count = currentContext.Get<int>("ep3Count");
            var ep4Count = currentContext.Get<int>("ep4Count");
            var ep5Count = currentContext.Get<int>("ep5Count");

            var books = GeneratePotterBooksByEpisodeCount(
                ep1Count, ep2Count, ep3Count, ep4Count, ep5Count
            );

            var actual = target.CalculateSuitePrice(books);

            ScenarioContext.Current.Set(actual);
        }
        
        [Then(@"價格應為 (.*) 元")]
        public void Then價格應為元(int expected)
        {
            var actual = ScenarioContext.Current.Get<int>();

            Assert.AreEqual(expected, actual);
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
    }
}
