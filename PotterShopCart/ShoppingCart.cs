using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShopCart
{
    public class ShoppingCart
    {
        private const int PricePerBook = 100;

        /// <summary>
        /// Key: 一套有幾本; Value: 打幾折
        /// </summary>
        private Dictionary<int, decimal> _discountMap = new Dictionary<int, decimal>()
        {
            { 1, 1 },
            { 2, 0.95m },
            { 3, 0.9m },
            { 4, 0.8m },
            { 5, 0.75m }
        };

        public ShoppingCart()
        {
        }

        public int CalculateSuitePrice(List<PotterBook> potterBooks)
        {
            var suites = ArrangeBooksToSuites(potterBooks);

            var totalPrice = suites.Select(suite =>
            {
                var suiteCount = suite.Count;

                return suiteCount * PricePerBook * _discountMap[suiteCount];
            }).Sum();

            return (int)totalPrice;
        }

        private List<List<PotterBook>> ArrangeBooksToSuites(List<PotterBook> potterBooks)
        {
            var suites = new List<List<PotterBook>>();

            while (potterBooks.Any())
            {
                var episodeGroups = potterBooks.GroupBy(b => b.Episode);

                var suite = episodeGroups.Select(g => g.First()).ToList();

                suite.ForEach(book => potterBooks.Remove(book));

                suites.Add(suite);
            }

            return suites;
        }
    }
}