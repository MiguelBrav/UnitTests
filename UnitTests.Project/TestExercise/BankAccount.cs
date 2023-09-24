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
            Balance += money;
            return true;
        }

        public bool BankBithdrawal (int money)
        {
            if (money <= Balance)
            {
                Balance -= money;
                return true;
            }

            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}