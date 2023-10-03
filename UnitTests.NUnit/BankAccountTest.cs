using Moq;
using NUnit.Framework;
using UnitTests.Project.TestExercise;

namespace UnitTests.NUnit
{
    [TestFixture]

    public class BankAccountTest
    {
        private BankAccount _account;

        [OneTimeSetUp]

        public void SetUp()
        {

        }

        [Test]
        [TestCase(100)]
        public void BankDeposit_Input100LoggerFake_ReturnTrue(int money)
        {
            BankAccount bankAccount = new BankAccount(new LoggerFake());
            var result = bankAccount.BankDeposit(money);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(money));
            
        }

        [Test]
        [TestCase(100)]
        public void BankDeposit_Input100Mocking_ReturnTrue(int money)
        {
            var mocking = new Mock<IGeneralLogger>();
            BankAccount bankAccount = new BankAccount(mocking.Object);
            var result = bankAccount.BankDeposit(money);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(money));

        }
    }
}