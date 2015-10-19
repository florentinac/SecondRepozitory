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
            public string ProductName;
            public int Price;
        };

        public static float GetTotalPrice(ShoppingCart[] cart)
        {
            float totalPrice = 0;
            for (var i = 0; i < cart.Length; i++)
                totalPrice += cart[i].Price;
            return totalPrice;
        }

        public static float GetMinim(ShoppingCart[] cart)
        {
            float minValue = cart[0].Price;
            for (var i = 0; i < cart.Length; i++)
                if (cart[i].Price < minValue)
                    minValue = cart[i].Price;
            return minValue;
        }

        public static ShoppingCart[] AddToArray(ref ShoppingCart[] array, ShoppingCart newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;
            return array;
        }

        public static ShoppingCart[] ResizeArray(ShoppingCart[] oldArray, int difference)
        {
            var newArray = new ShoppingCart[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public static ShoppingCart[] GetProductWithMinimPrice(ShoppingCart[] cart)
        {
            var minPrice = GetMinim(cart);
            var productsMinim = new ShoppingCart[0];

            for (var i = 0; i < cart.Length; i++)
            {
                if (cart[i].Price == minPrice)
                {
                    productsMinim = AddToArray(ref productsMinim, cart[i]);
                }
            }
            return productsMinim;
        }

        public static float GetAveregePrice(ShoppingCart[] cart)
        {
            float averegePrice = 0;
            float totalPrice = GetTotalPrice(cart);
            averegePrice = totalPrice / cart.Length;

            return averegePrice;
        }

        public static float GetMaxim(ShoppingCart[] cart)
        {
            float maxPrice = cart[0].Price;
            for (var i = 0; i < cart.Length; i++)
                if (cart[i].Price > maxPrice)
                    maxPrice = cart[i].Price;
            return maxPrice;
        }

        public static ShoppingCart[] RemoveAtIndex(ShoppingCart[] array, int index)
        {
            var count = array.Length - 1;
            var newArray = new ShoppingCart[count];

            if (index > 0)
                Array.Copy(array, 0, newArray, 0, index);
            if (index < count)
                Array.Copy(array, index + 1, newArray, index, count - index);
            return newArray;
        }

        public static ShoppingCart[] RemoveProduct(ShoppingCart[] cart)
        {
            var maxPrice = GetMaxim(cart);
            var newArray = new ShoppingCart[cart.Length - 1];

            for (var i = 0; i < cart.Length; i++)
            {
                if (cart[i].Price == maxPrice)
                    newArray = RemoveAtIndex(cart, i);
            }
            return newArray;
        }
    }
}
