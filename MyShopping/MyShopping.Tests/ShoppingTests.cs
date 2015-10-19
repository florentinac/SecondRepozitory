using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyShopping.Tests
{
    [TestClass]
    public class ShoppingTests
    {
        public Shopping.ShoppingCart[] Cart = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart{ ProductName = "vegetables", Price = 12 },
            new Shopping.ShoppingCart{ ProductName = "chocolate", Price = 15 },
            new Shopping.ShoppingCart{ ProductName = "milk", Price = 14},
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 },
            new Shopping.ShoppingCart{ ProductName = "cookies", Price = 50 },
            new Shopping.ShoppingCart{ ProductName = "bread", Price = 36 }
        };
        public Shopping.ShoppingCart[] CartPlusNewProduct = new Shopping.ShoppingCart[]
      {
            new Shopping.ShoppingCart{ ProductName = "vegetables", Price = 12 },
            new Shopping.ShoppingCart{ ProductName = "chocolate", Price = 15 },
            new Shopping.ShoppingCart{ ProductName = "milk", Price = 14},
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 },
            new Shopping.ShoppingCart{ ProductName = "cookies", Price = 50 },
            new Shopping.ShoppingCart{ ProductName = "bread", Price = 36 },
            new Shopping.ShoppingCart{ ProductName = "fruits", Price = 10 }
      };
        public Shopping.ShoppingCart[] CartWithMultiplePriceMinim = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart{ ProductName = "vegetables", Price = 12 },
            new Shopping.ShoppingCart{ ProductName = "chocolate", Price = 15 },
            new Shopping.ShoppingCart{ ProductName = "water", Price = 7},
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 },
            new Shopping.ShoppingCart{ ProductName = "cookies", Price = 50 },
            new Shopping.ShoppingCart{ ProductName = "bread", Price = 36 }
        };

        public Shopping.ShoppingCart[] ProductMinim = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 }
        };

        public Shopping.ShoppingCart[] ProductsMinim = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart{ ProductName = "water", Price = 7 },
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 }
        };

        public Shopping.ShoppingCart[] CartRemoveProduct = new Shopping.ShoppingCart[]
       {
            new Shopping.ShoppingCart{ ProductName = "vegetables", Price = 12 },
            new Shopping.ShoppingCart{ ProductName = "chocolate", Price = 15 },
            new Shopping.ShoppingCart{ ProductName = "milk", Price = 14},
            new Shopping.ShoppingCart{ ProductName = "yogurt", Price = 7 },
            new Shopping.ShoppingCart{ ProductName = "bread", Price = 36 }
       };

        [TestMethod]
        public void TotalPriceFromShoppingCart()
        {
            var expectedPrice = 134;
            var actualPrice = Shopping.GetTotalPrice(Cart);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void PriceMinimFromShoppingCart()
        {
            var expectedPrice = 7;
            var actualPrice = Shopping.GetMinim(Cart);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void MoreProductWithPriceMinimFromShoppingCart()
        {
            var expectedProducts = ProductsMinim;
            var actualProducts = Shopping.GetProductWithMinimPrice(CartWithMultiplePriceMinim);
            CollectionAssert.AreEqual(expectedProducts, actualProducts);
        }

        [TestMethod]
        public void OneProductWithPriceMinimFromShoppingCart()
        {
            var expectedProduct = ProductMinim;
            var actualProduct = Shopping.GetProductWithMinimPrice(Cart);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void AveregePriceFromShoppingCart()
        {
            var expectedPrice = 22.333;
            var actualPrice = Shopping.GetAveregePrice(Cart);
            Assert.AreEqual(expectedPrice, Math.Round(actualPrice, 3));
        }

        [TestMethod]
        public void MaximPriceFromShoppingCart()
        {
            var expectedPrice = 50;
            var actualPrice = Shopping.GetMaxim(Cart);
            Assert.AreEqual(expectedPrice, actualPrice);
        }
        [TestMethod]
        public void AddProductInShoppingCart()
        {
            var product = new Shopping.ShoppingCart { ProductName = "fruits", Price = 10 };
            var expectedProduct = CartPlusNewProduct;
            var actualProduct = Shopping.AddToArray(ref Cart, product);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

        [TestMethod]
        public void RemoveProductFromShoppingCart()
        {
            var expectedProduct = CartRemoveProduct;
            var actualProduct = Shopping.RemoveProduct(Cart);
            CollectionAssert.AreEqual(expectedProduct, actualProduct);
        }

    }
}
