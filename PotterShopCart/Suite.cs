using System.Collections.Generic;

namespace PotterShopCart
{
    public class Suite
    {
        /// <summary>
        /// Key: 一套有幾本; Value: 打幾折
        /// </summary>
        private static Dictionary<int, decimal> _discountMap = new Dictionary<int, decimal>()
        {
            { 1, 1 },
            { 2, 0.95m },
            { 3, 0.9m },
            { 4, 0.8m },
            { 5, 0.75m }
        };

        private const int PricePerBook = 100;

        public List<PotterBook> Books { get; set; }


        public int CalculatePrice()
        {
            var suiteCount = Books.Count;

            return (int)(suiteCount * PricePerBook * _discountMap[suiteCount]);
        }
    }
}