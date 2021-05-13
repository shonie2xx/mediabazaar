using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarProject.Logic;

namespace UnitTestMBazar
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void NewProductTest()
        {
            Product product = new Product("TV", 299, 20, 10, "tvs", 5);
            Assert.AreEqual("TV", product.Name);
            Assert.AreEqual(299, product.Price);
            Assert.AreEqual(20, product.Stocks);
            Assert.AreEqual(10, product.Sold);
            Assert.AreEqual("tvs", product.Category);
            Assert.AreEqual(5, product.Requested);
        }
        [TestMethod]
        public void GetInfoTest()
        {
            Product product = new Product("TV", 299, 20, 10, "tvs", 5);
            string info = product.GetInfo();
            Assert.AreEqual("name: TV price:299 stock: 20 sold: 10", info);
        }
        [TestMethod]
        public void GetRequestInfoTest()
        {
            Product product = new Product("TV", 299, 20, 10, "tvs", 5);
            string info = product.GetRequestInfo();
            Assert.AreEqual("name: TV Requested: 5", info);
        }
        
    }
}
