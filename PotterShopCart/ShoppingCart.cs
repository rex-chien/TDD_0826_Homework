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

            if (buyedPotterSeries.Where(amount => amount > 0).Count() == 2)
            {
                totalPrice *= 0.95;
            }

            if (buyedPotterSeries.Where(amount => amount > 0).Count() == 3)
            {
                totalPrice *= 0.90;
            }

            return (int) totalPrice;
        }
    }
}