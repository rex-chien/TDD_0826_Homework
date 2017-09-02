using System.Collections.Generic;
using System.Linq;

namespace PotterShopCart
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public int CalculateSuitePrice(List<PotterBook> potterBooks)
        {
            var combinations = ProduceCombinations(potterBooks);

            if (combinations.Count == 0)
            {
                return 0;
            }

            var combinationsPrice = combinations.Select(suites =>
            {
                return suites.Select(suite => suite.CalculatePrice()).Sum();
            });

            return combinationsPrice.Min();
        }

        /// <summary>
        /// 窮舉所有組合
        /// </summary>
        /// <param name="potterBooks"></param>
        /// <returns></returns>
        private List<List<Suite>> ProduceCombinations(List<PotterBook> potterBooks)
        {
            var combinations = new List<List<Suite>>();

            var maxBookCountPerSuite = potterBooks.GroupBy(b => b.Episode).Count();

            for (int bookCountPerSuite = 1; bookCountPerSuite <= maxBookCountPerSuite; bookCountPerSuite++)
            {
                combinations.Add(ProduceSuites(potterBooks, bookCountPerSuite));
            }

            return combinations;
        }

        private List<Suite> ProduceSuites(List<PotterBook> potterBooks, int count)
        {
            var suites = new List<Suite>();
            var books = new List<PotterBook>(potterBooks);

            if (count > 0)
            {
                while (books.Any())
                {
                    var suiteBooks = books.GroupBy(b => b.Episode)
                        .OrderByDescending(g => g.Count())
                        .Take(count)
                        .Select(g => g.First()).ToList();

                    suiteBooks.ForEach(book => books.Remove(book));

                    suites.Add(new Suite
                    {
                        Books = suiteBooks
                    });
                }
            }

            return suites;
        }
    }
}