using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.Project.TestExercise
{
    public interface IGeneralLogger
    {
        public int PriorityLogger { get; set; }

        public string TypeLogger { get; set; }

        void Message(string message);

        bool LogDatabase(string message);

        bool LogBalanceAfterWithdraw(int balance);

        string MessageWithReturnString(string message);

        bool MessageWithOutParameterReturnsBool(string str, out string outStr);

        bool MessageWithRefObjectReturnBool(ref Client client);
    }
}
