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
            var combinations = ProduceCombinations(potterBooks);

            var a = combinations.Select(suites =>
            {
                return suites.Select(suite =>
                {
                    var suiteCount = suite.Count;

                    return suiteCount * PricePerBook * _discountMap[suiteCount];
                }).Sum();
            }).Min();

            return (int)a;
        }

        private List<List<PotterBook>> ArrangeBooksToSuites(List<PotterBook> potterBooks)
        {
            var suites = new List<List<PotterBook>>();

            potterBooks = new List<PotterBook>(potterBooks);

            while (potterBooks.Any())
            {
                var episodeGroups = potterBooks.GroupBy(b => b.Episode);

                var suite = episodeGroups.Select(g => g.First()).ToList();

                suite.ForEach(book => potterBooks.Remove(book));

                suites.Add(suite);
            }

            return suites;
        }

        /// <summary>
        /// 窮舉所有組合
        /// </summary>
        /// <param name="potterBooks"></param>
        /// <returns></returns>
        private List<List<List<PotterBook>>> ProduceCombinations(List<PotterBook> potterBooks)
        {
            var combinations = new List<List<List<PotterBook>>>();

            var maxBookCountPerSuite = potterBooks.GroupBy(b => b.Episode).Count();

            for (int bookCountPerSuite = maxBookCountPerSuite / 2 + 1; bookCountPerSuite <= maxBookCountPerSuite; bookCountPerSuite++)
            {
                combinations.Add(ProduceSuites(potterBooks, bookCountPerSuite));
            }

            return combinations;
        }

        private List<List<PotterBook>> ProduceSuites(List<PotterBook> potterBooks, int count)
        {
            var suites = new List<List<PotterBook>>();
            var books = new List<PotterBook>(potterBooks);

            if (count > 0)
            {
                while (books.Any())
                {
                    var suite = books.GroupBy(b => b.Episode)
                        .OrderByDescending(g => g.Count())
                        .Take(count)
                        .Select(g => g.First()).ToList();

                    suite.ForEach(book => books.Remove(book));

                    suites.Add(suite);
                }
            }

            return suites;
        }
    }
}