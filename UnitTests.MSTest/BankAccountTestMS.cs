using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.InitialProject.TestExercise;
using UnitTests.Project.TestExercise;

namespace UnitTests.MSTest
{
    [TestClass]
    public class BankAccountTestMS
    {
        [TestMethod]
        [DataRow(100)]
        public void BankDeposit_Input100LoggerFake_ReturnTrue(int money)
        {
            BankAccount bankAccount = new BankAccount(new LoggerFake());
            var result = bankAccount.BankDeposit(money);

            Assert.IsTrue(result);
            Assert.AreEqual(money, bankAccount.GetBalance());
        }

        [TestMethod]
        [DataRow(100)]
        public void BankDeposit_Input100Mocking_ReturnTrue(int money)
        {
            var mocking = new Mock<IGeneralLogger>();
            BankAccount bankAccount = new BankAccount(mocking.Object);
            var result = bankAccount.BankDeposit(money);

            Assert.IsTrue(result);
            Assert.AreEqual(money, bankAccount.GetBalance());
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        [DataRow(200, 100)]
        public void WithDraw_Input100WithBalance200_ReturnTrue(int money, int withdraw)
        {
            var loggerMocking = new Mock<IGeneralLogger>();

            loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);

            loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerMocking.Object);

            bankAccount.BankDeposit(money);

            var result = bankAccount.BankWithdrawal(withdraw);

            Assert.IsTrue(result);
            Assert.AreEqual(money - withdraw, bankAccount.GetBalance());
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        [DataRow(200, 400)]
        public void WithDraw_Input400WithBalance200_ReturnFalse(int money, int withdraw)
        {
            var loggerMocking = new Mock<IGeneralLogger>();

            loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new BankAccount(loggerMocking.Object);

            bankAccount.BankDeposit(money);

            var result = bankAccount.BankWithdrawal(withdraw);

            Assert.IsFalse(result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        [DataRow("HELLO I'M MIGUEL")]
        [DataRow("Example With Interfaces Mocking")]
        public void BankAccountGeneralLogger_InputStrLogMocking_ReturnTrue(string message)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            loggerGeneralMocking.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var result = loggerGeneralMocking.Object.MessageWithReturnString(message);

            Assert.AreEqual(message.ToLower(), result);
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        [DataRow("MIGUEL")]
        [DataRow("ANGEL")]
        public void BankAccountGeneralLogger_InputStrLogMockingOutPutParameter_ReturnTrue(string message)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            string outputStr;

            string outputParameter;

            loggerGeneralMocking.Setup(u => u.MessageWithOutParameterReturnsBool(It.IsAny<string>(), out outputStr)).Returns(true);

            var result = loggerGeneralMocking.Object.MessageWithOutParameterReturnsBool(message, out outputParameter);

            Assert.IsTrue(result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        public void BankAccountGeneralLogger_LogMockingObjectRef_ReturnTrue()
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            Client client = new Client();
            Client clientNotUsed = new Client();

            loggerGeneralMocking.Setup(u => u.MessageWithRefObjectReturnBool(ref client)).Returns(true);

            Assert.IsTrue(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client));
            Assert.IsFalse(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref clientNotUsed));
            Assert.IsInstanceOfType(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client), typeof(bool));
        }

        [TestMethod]
        [DataRow("warning", 1)]
        [DataRow("success", 2)]
        public void BankAccountGeneralLogger_LogMockingSetupProperties_ReturnTrue(string typeLogger, int priorityType)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            loggerGeneralMocking.Setup(u => u.TypeLogger).Returns(typeLogger);
            loggerGeneralMocking.Setup(u => u.PriorityLogger).Returns(priorityType);

            Assert.AreEqual(typeLogger, loggerGeneralMocking.Object.TypeLogger);
            Assert.AreEqual(priorityType, loggerGeneralMocking.Object.PriorityLogger);
            Assert.IsInstanceOfType(loggerGeneralMocking.Object.TypeLogger, typeof(string));
            Assert.IsInstanceOfType(loggerGeneralMocking.Object.PriorityLogger, typeof(int));

            string tempTxt = "callbck";
            string bdTxt = "key_database";
            string expectedResult = string.Concat(tempTxt, bdTxt);

            loggerGeneralMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true).Callback((string parameter) => tempTxt += parameter);

            loggerGeneralMocking.Object.LogDatabase(bdTxt);

            Assert.AreEqual(expectedResult, tempTxt);
        }

        [TestMethod]
        [DataRow(20)]
        [DataRow(100)]
        public void BankAccountGeneralLogger_VerifyExample_ReturnTrue(int money)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();
            string txtValidate = "Another text";

            BankAccount bankAccount = new BankAccount(loggerGeneralMocking.Object);

            bankAccount.BankDeposit(money);

            loggerGeneralMocking.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(3));

            loggerGeneralMocking.Verify(u => u.Message(txtValidate), Times.AtLeastOnce);

            loggerGeneralMocking.VerifySet(u => u.PriorityLogger = money, Times.Once);

            loggerGeneralMocking.VerifyGet(u => u.PriorityLogger, Times.AtLeastOnce);

            Assert.AreEqual(money, bankAccount.GetBalance());
        }
    }
}