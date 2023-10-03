using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.NUnit
{
    [TestFixture]

    public class ProductTest
    {
        [Test]
        [TestCase(50,true)]
        [TestCase(800, true)]
        public void GetPrice_PremiumClient_ReturnsPrice80Percent(int priceProduct, bool isClientPremium)
        {
            //Notes: Class without Interface, don't need mocking

            Product product = new Product()
            {
                Price = priceProduct
            };
            
            var result = product.GetPrice(new Client { IsPremium = isClientPremium });

            Assert.That(result, Is.EqualTo(product.Price*.8));
            Assert.That(result, Is.TypeOf<double>());

        }

        [Test]
        [TestCase(50, true)]
        [TestCase(800, true)]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80Percent(int priceProduct, bool isClientPremium)
        {
            //Notes: Example mocking with interface

            Product product = new Product()
            {
                Price = priceProduct
            };

            var client = new Mock<IClient>();

            client.Setup(s => s.IsPremium ).Returns(isClientPremium);

            var result = product.GetPrice(client.Object);

            Assert.That(result, Is.EqualTo(product.Price * .8));
            Assert.That(result, Is.TypeOf<double>());

        }
    }
}
