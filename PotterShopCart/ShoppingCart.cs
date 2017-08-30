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
            { 4, 0.8m }
        };

        public ShoppingCart()
        {
        }

        public int CalculatePotterPrice(int[] buyedPotterSeries)
        {
            var totalPrice = buyedPotterSeries.Sum() * 100.0;
            var suiteCount = buyedPotterSeries.Where(amount => amount > 0).Count();

            totalPrice *= (double) _discountMap[suiteCount];

            return (int)totalPrice;
        }
    }
}