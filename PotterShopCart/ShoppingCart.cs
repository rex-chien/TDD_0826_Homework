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
            var totalPrice = buyedPotterSeries.Sum() * 100.0;

            if (buyedPotterSeries.Where(amount => amount > 0).Count() > 1)
            {
                totalPrice *= 0.95;
            }

            return (int) totalPrice;
        }
    }
}