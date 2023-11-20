using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;
using Xunit;

namespace UnitTests.XUnit
{
    public class ProductTestXUnit
    {
        [Theory]
        [InlineData(50, true)]
        [InlineData(800, true)]
        public void GetPrice_PremiumClient_ReturnsPrice80Percent(int priceProduct, bool isClientPremium)
        {
            //Notes: Class without Interface, don't need mocking

            Product product = new Product()
            {
                Price = priceProduct
            };
            
            var result = product.GetPrice(new Client { IsPremium = isClientPremium });

            // xUnit Equivalent for Assert.That(result, Is.EqualTo(product.Price * 0.8));
            Assert.Equal(product.Price * 0.8, result);

            // xUnit Equivalent for Assert.That(result, Is.TypeOf<double>());
            Assert.IsType<double>(result);

        }

        [Theory]
        [InlineData(50, true)]
        [InlineData(800, true)]
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

            // xUnit Equivalent for Assert.That(result, Is.EqualTo(product.Price * 0.8));
            Assert.Equal(product.Price * 0.8, result);

            // xUnit Equivalent for Assert.That(result, Is.TypeOf<double>());
            Assert.IsType<double>(result);

        }
    }
}
