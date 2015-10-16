using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShopping;

namespace MyShopping.Tests
{
    [TestClass]
    public class ShoppingTests
    {
        public Shopping.ShoppingCart[] Cart = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart {ProducName = "milk", Price = 10},
            new Shopping.ShoppingCart {ProducName = "yogurt", Price = 13},
            new Shopping.ShoppingCart {ProducName = "bread", Price = 4},
            new Shopping.ShoppingCart {ProducName = "apple", Price = 20},
            new Shopping.ShoppingCart {ProducName = "cico", Price = 5},
            new Shopping.ShoppingCart {ProducName = "strawberries", Price = 100},
            new Shopping.ShoppingCart {ProducName = "vegetables", Price = 1},          
        };

        public Shopping.ShoppingCart[] DeleteCart = new Shopping.ShoppingCart[]
        {
            new Shopping.ShoppingCart {ProducName = "milk", Price = 10},
            new Shopping.ShoppingCart {ProducName = "yogurt", Price = 13},
            new Shopping.ShoppingCart {ProducName = "bread", Price = 4},
            new Shopping.ShoppingCart {ProducName = "apple", Price = 20},
            new Shopping.ShoppingCart {ProducName = "cico", Price = 5},
            new Shopping.ShoppingCart {ProducName = "vegetables", Price = 1},
        };


        [TestMethod]
        public void TestToalPriceOfSoppingCart()
        {
            var expectedPrice = 283;
            var acutalPrice = Shopping.GetTotalPaymentOfShoppingCart(Cart);
            Assert.AreEqual(expectedPrice,acutalPrice);

        }

        [TestMethod]
        public void CheapestProductFromSoppingCart()
        {
            var expectedProduct = "vegetables";
            var acutalProduct = Shopping.GetTheCheapestProduct(Cart);
            Assert.AreEqual(expectedProduct, acutalProduct);

        }

        [TestMethod]
        public void MaxPriceOfProductFromSoppingCart()
        {
            var expectedProduct = 119;            
            var acutalProduct = Shopping.GetMaximPrice(Cart);
            Assert.AreEqual(expectedProduct, acutalProduct);

        }
        [TestMethod]
        public void DeleteProductWhoHeveMaxPriceFromSoppingCart()
        {
            var expectedProduct = DeleteCart;
            var acutalProduct = Shopping.DeleteProduct(Cart);
            Assert.AreEqual(expectedProduct, acutalProduct);

        }


    }
}
