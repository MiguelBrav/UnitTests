using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Project.TestExercise
{
    public interface IGeneralLogger
    {
        void Message(string message);

        bool LogDatabase(string message);

        bool LogBalanceAfterWithdraw(int balance);

        string MessageWithReturnString(string message);

        bool MessageWithOutParameterReturnsBool(string str, out string outStr);
    }
}
