using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.MSTest
{
    [TestClass]
    public class ProductTestMS
    {
        [TestMethod]
        [DataRow(50, true)]
        [DataRow(800, true)]
        public void GetPrice_PremiumClient_ReturnsPrice80Percent(int priceProduct, bool isClientPremium)
        {
            Product product = new Product()
            {
                Price = priceProduct
            };

            var result = product.GetPrice(new Client { IsPremium = isClientPremium });

            Assert.AreEqual(product.Price * 0.8, result);
            Assert.IsInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        [DataRow(50, true)]
        [DataRow(800, true)]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80Percent(int priceProduct, bool isClientPremium)
        {
            Product product = new Product()
            {
                Price = priceProduct
            };

            var client = new Mock<IClient>();

            client.Setup(s => s.IsPremium).Returns(isClientPremium);

            var result = product.GetPrice(client.Object);

            Assert.AreEqual(product.Price * 0.8, result);
            Assert.IsInstanceOfType(result, typeof(double));
        }
    }
}
