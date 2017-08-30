using System.Collections.Generic;
using System.Linq;

namespace PotterShopCart
{
    public class ShoppingCart
    {
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

        public int CalculatePotterPrice(int[] buyedPotterSeries)
        {
            var suites = ArrangeBooksToSuites(buyedPotterSeries);

            var totalPrice = suites.Select(suite =>
            {
                var suitePrice = suite.Sum() * 100;
                var suiteCount = suite.Where(amount => amount > 0).Count();

                return suitePrice * _discountMap[suiteCount];
            }).Sum();

            return (int)totalPrice;
        }

        private List<int[]> ArrangeBooksToSuites(int[] books)
        {
            List<int[]> suites = new List<int[]>();
            int episodes = books.Length;

            while (books.Any(amount => amount > 0))
            {
                int[] suite = new int[episodes];

                for (int index = 0; index < episodes; index++)
                {
                    if (books[index] > 0)
                    {
                        suite[index] = 1;
                        books[index]--;
                    }
                }

                suites.Add(suite);
            }

            return suites;
        }
    }
}