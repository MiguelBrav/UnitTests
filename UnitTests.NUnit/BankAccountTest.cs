using Moq;
using NUnit.Framework;
using UnitTests.InitialProject.TestExercise;
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
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(money));
            Assert.That(result, Is.TypeOf<bool>());

        }

        [Test]
        [TestCase(200,100)]
        public void WithDraw_Input100WithBalance200_ReturnTrue(int money, int withdraw)
        {
            var loggerMocking = new Mock<IGeneralLogger>();

            loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);

            loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerMocking.Object);
            
            bankAccount.BankDeposit(money);

            var result = bankAccount.BankWithdrawal(withdraw); 

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(money- withdraw));
            Assert.That(result, Is.TypeOf<bool>());

        }

        [Test]
        [TestCase(200, 400)]
        public void WithDraw_Input400WithBalance200_ReturnFalse(int money, int withdraw)
        {
            var loggerMocking = new Mock<IGeneralLogger>();
            //This method is not needed for this case
            //loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);

            
            //loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);

            //Implementing range in mocking
            loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);


            BankAccount bankAccount = new BankAccount(loggerMocking.Object);

            bankAccount.BankDeposit(money);

            var result = bankAccount.BankWithdrawal(withdraw);

            Assert.IsFalse(result);
            Assert.That(result, Is.TypeOf<bool>());
        }


        [Test]
        [TestCase("HELLO I'M MIGUEL")]
        [TestCase("Example With Interfaces Mocking")]
        public void BankAccountGeneralLogger_InputStrLogMocking_ReturnTrue(string message)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            loggerGeneralMocking.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());


            var result = loggerGeneralMocking.Object.MessageWithReturnString(message);

            Assert.That(result,Is.EqualTo(message.ToLower()));
            Assert.That(result, Is.TypeOf<string>());
        }

        [Test]
        [TestCase("MIGUEL")]
        [TestCase("ANGEL")]
        public void BankAccountGeneralLogger_InputStrLogMockingOutPutParameter_ReturnTrue(string message)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            string outputStr;

            string outputParameter;

            loggerGeneralMocking.Setup(u => u.MessageWithOutParameterReturnsBool(It.IsAny<string>(), out outputStr)).Returns(true);

            var result = loggerGeneralMocking.Object.MessageWithOutParameterReturnsBool(message,out outputParameter);

            //Example with assert multiple, to handle errors
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(result, Is.TypeOf<bool>());
            });
        }

        [Test]
        public void BankAccountGeneralLogger_LogMockingObjectRef_ReturnTrue()
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            Client client = new Client();
            Client clientNotUsed = new Client();

            loggerGeneralMocking.Setup(u => u.MessageWithRefObjectReturnBool(ref client)).Returns(true);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client));
                Assert.IsFalse(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref clientNotUsed));
                Assert.That(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client), Is.TypeOf<bool>());
            });
        }


        [Test]
        [TestCase("warning",1)]
        [TestCase("success",2)]
        public void BankAccountGeneralLogger_LogMockingSetupProperties_ReturnTrue(string typeLogger, int priorityType)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            loggerGeneralMocking.Setup(u => u.TypeLogger).Returns(typeLogger);
            loggerGeneralMocking.Setup(u => u.PriorityLogger).Returns(priorityType);

            //This method is used to update property of an object moq
            //loggerGeneralMocking.SetupAllProperties();
            //loggerGeneralMocking.Object.PriorityLogger = 5;

            Assert.Multiple(() =>
            {
                Assert.That(loggerGeneralMocking.Object.TypeLogger, Is.EqualTo(typeLogger));
                Assert.That(loggerGeneralMocking.Object.PriorityLogger, Is.EqualTo(priorityType));
                Assert.That(loggerGeneralMocking.Object.TypeLogger, Is.TypeOf<string>());
                Assert.That(loggerGeneralMocking.Object.PriorityLogger, Is.TypeOf<int>());
            });

            //Callbacks
            
            string tempTxt = "callbck";
            string bdTxt = "key_database";
            string expectedResult = string.Concat(tempTxt, bdTxt);

            loggerGeneralMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true).Callback((string parameter) => tempTxt += parameter);

            loggerGeneralMocking.Object.LogDatabase(bdTxt);

            Assert.That(expectedResult, Is.EqualTo(tempTxt));
        }

        [Test]
        [TestCase(20)]
        [TestCase(100)]
        public void BankAccountGeneralLogger_VerifyExample_ReturnTrue(int money)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();
            string txtValidate = "Another text";

            BankAccount bankAccount = new BankAccount(loggerGeneralMocking.Object);

            bankAccount.BankDeposit(money);

            //Validate if message method is executed 3 times with moq
            //If Times executed is distinct to 3, the test fails

            loggerGeneralMocking.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(3));

            //Validate if message method is executed at least once with the parameter
            loggerGeneralMocking.Verify(u => u.Message(txtValidate),Times.AtLeastOnce);

            //Validate if property is setted one time with moq
            loggerGeneralMocking.VerifySet(u => u.PriorityLogger = money, Times.Once);

            //Validate if property is getted one time with moq
            loggerGeneralMocking.VerifyGet(u => u.PriorityLogger, Times.AtLeastOnce);

            Assert.Multiple(() =>
            {
                Assert.That(bankAccount.GetBalance, Is.TypeOf<int>());
                Assert.That(bankAccount.GetBalance, Is.EqualTo(money));
            });
        }
    }
}