using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Project.TestExercise
{
    public class GeneralLogger : IGeneralLogger
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class LoggerFake : IGeneralLogger
    {
        public void Message(string message)
        {
          
        }
    }
}
