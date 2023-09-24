using NUnit.Framework;
using UnitTests.Project.TestExercise;

namespace UnitTests.NUnit
{
    [TestFixture]

    public class BankAccountTest
    {
        private BankAccount _bankAccount;

        [OneTimeSetUp]

        public void SetUp()
        {

            _bankAccount = new BankAccount(new LoggerFake());
        }

        [Test]
        [TestCase(100)]
        public void BankDeposit_Input100_ReturnTrue(int money)
        {
            var result = _bankAccount.BankDeposit(money);

            Assert.IsTrue(result);
            Assert.That(_bankAccount.GetBalance, Is.EqualTo(money));
            
        }
    }
}