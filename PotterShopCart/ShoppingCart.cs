using System.Linq;

namespace PotterShopCart
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public int CalculatePotterPrice(int[] buyedPotterSeries)
        {
            var totalPrice = buyedPotterSeries.Sum() * 100;

            return totalPrice;
        }
    }
}