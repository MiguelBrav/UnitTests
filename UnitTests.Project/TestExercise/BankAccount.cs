using UnitTests.Project.TestExercise;

namespace UnitTests.Project.TestExercise
{
    public class BankAccount
    {
        public int Balance { get; set; }

        private readonly IGeneralLogger _loggerGeneral;

        public BankAccount(IGeneralLogger generalLogger)
        {
            Balance = 0;
            _loggerGeneral = generalLogger; 
        }

        public bool BankDeposit (int money)
        {
            _loggerGeneral.Message("You are depositing the amount of " + money);
            _loggerGeneral.Message("Another text");
            _loggerGeneral.Message("Another example");
            //set method
            _loggerGeneral.PriorityLogger = money;
            //get method
            var priority = _loggerGeneral.PriorityLogger;
            Balance += money;
            return true;
        }

        public bool BankWithdrawal (int money)
        {
            if (money <= Balance)
            {
                _loggerGeneral.LogDatabase("You are Withdrawal the amount of " + money.ToString());
                Balance -= money;
                return _loggerGeneral.LogBalanceAfterWithdraw(Balance);
            }

            return _loggerGeneral.LogBalanceAfterWithdraw(Balance-money);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}