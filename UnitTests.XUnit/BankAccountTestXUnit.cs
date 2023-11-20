using Moq;
using UnitTests.InitialProject.TestExercise;
using UnitTests.Project.TestExercise;
using Xunit;

namespace UnitTests.XUnit
{
    public class BankAccountTestXUnit
    {
        private BankAccount _account;

        [Theory]
        [InlineData(100)]
        public void BankDeposit_Input100LoggerFake_ReturnTrue(int money)
        {
            BankAccount bankAccount = new BankAccount(new LoggerFake());
            var result = bankAccount.BankDeposit(money);

            Assert.True(result);
            Assert.Equal(money, bankAccount.GetBalance());

        }

        [Theory]
        [InlineData(100)]
        public void BankDeposit_Input100Mocking_ReturnTrue(int money)
        {
            var mocking = new Mock<IGeneralLogger>();
            BankAccount bankAccount = new BankAccount(mocking.Object);
            var result = bankAccount.BankDeposit(money);

            Assert.True(result);
            Assert.Equal(money, bankAccount.GetBalance());
            Assert.IsType<bool>(result);

        }

        [Theory]
        [InlineData(200,100)]
        public void WithDraw_Input100WithBalance200_ReturnTrue(int money, int withdraw)
        {
            var loggerMocking = new Mock<IGeneralLogger>();

            loggerMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);

            loggerMocking.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerMocking.Object);
            
            bankAccount.BankDeposit(money);

            var result = bankAccount.BankWithdrawal(withdraw);

            Assert.True(result);
            Assert.Equal(money - withdraw, bankAccount.GetBalance());
            Assert.IsType<bool>(result);

        }

        [Theory]
        [InlineData(200, 400)]
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

            Assert.False(result);
            Assert.IsType<bool>(result);
        }


        [Theory]
        [InlineData("HELLO I'M MIGUEL")]
        [InlineData("Example With Interfaces Mocking")]
        public void BankAccountGeneralLogger_InputStrLogMocking_ReturnTrue(string message)
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            loggerGeneralMocking.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());


            var result = loggerGeneralMocking.Object.MessageWithReturnString(message);
            Assert.Equal(message.ToLower(), result);
            Assert.IsType<string>(result);
        }

        [Theory]
        [InlineData("MIGUEL")]
        [InlineData("ANGEL")]
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
                Assert.True(result);
                Assert.IsType<bool>(result);
            });
        }

        [Fact]
        public void BankAccountGeneralLogger_LogMockingObjectRef_ReturnTrue()
        {
            var loggerGeneralMocking = new Mock<IGeneralLogger>();

            Client client = new Client();
            Client clientNotUsed = new Client();

            loggerGeneralMocking.Setup(u => u.MessageWithRefObjectReturnBool(ref client)).Returns(true);

            Assert.Multiple(() =>
            {
                Assert.True(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client));
                Assert.False(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref clientNotUsed));
                Assert.IsType<bool>(loggerGeneralMocking.Object.MessageWithRefObjectReturnBool(ref client));
            });
        }


        [Theory]
        [InlineData("warning",1)]
        [InlineData("success",2)]
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
                Assert.Equal(typeLogger, loggerGeneralMocking.Object.TypeLogger);
                Assert.Equal(priorityType, loggerGeneralMocking.Object.PriorityLogger);
                Assert.IsType<string>(loggerGeneralMocking.Object.TypeLogger);
                Assert.IsType<int>(loggerGeneralMocking.Object.PriorityLogger);
            });

            //Callbacks
            
            string tempTxt = "callbck";
            string bdTxt = "key_database";
            string expectedResult = string.Concat(tempTxt, bdTxt);

            loggerGeneralMocking.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true).Callback((string parameter) => tempTxt += parameter);

            loggerGeneralMocking.Object.LogDatabase(bdTxt);

            Assert.Equal(expectedResult, tempTxt);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(100)]
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
                Assert.IsType<int>(bankAccount.GetBalance());
                Assert.Equal(money, bankAccount.GetBalance());
            });
        }
    }
}