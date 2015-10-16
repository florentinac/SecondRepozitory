using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopping
{
    public class Shopping
    {
        public struct ShoppingCart
        {
            public string ProducName;
            public int Price;
                   

        }

        public static int GetTotalPaymentOfShoppingCart(ShoppingCart[] cart)
        {
            var totalPayment = 0;
            for (var i = 0; i < cart.Length; i++)
                totalPayment += cart[i].Price;

            return totalPayment;
        }

        public static string GetTheCheapestProduct(ShoppingCart[] cart)
        {
            var cheapestProduct = cart[0].ProducName;
            var minPrice = cart[0].Price;
            for (var i=0;i<cart.Length;i++)
                if (cart[i].Price < minPrice)
                {                   
                    minPrice = cart[i].Price;
                    cheapestProduct = cart[i].ProducName;
                }

            return cheapestProduct;
        }

        public static int GetMaximPrice(ShoppingCart[] cart)
        {
            var maxPrice = cart[0].Price;
            for(var i=0;i<cart.Length;i++)
                if (cart[i].Price > maxPrice)
                    maxPrice = cart[i].Price;
            return maxPrice;
        }

        public static ShoppingCart[] DeleteProduct(ShoppingCart[] cart)
        {
            var maxPrice = GetMaximPrice(cart);
            var newCart = new ShoppingCart[cart.Length-1];
            for( var i=1;i<cart.Length;i++)
                if (cart[i].Price != maxPrice)
                    newCart[i-1] = cart[i];
            return newCart;

        }
    }
}
