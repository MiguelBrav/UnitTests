﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.Project.TestExercise
{
    public class GeneralLogger : IGeneralLogger
    {
        public int PriorityLogger { get; set; }
        public string TypeLogger { get; set; }

        public bool LogBalanceAfterWithdraw(int balance)
        {
            if(balance >= 0)
            {
                Console.WriteLine("Success withdraw");

                return true;
            }
            Console.WriteLine("Error - Bad request");

            return true;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);

            return true;

        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageWithOutParameterReturnsBool(string str, out string outStr)
        {
            outStr = "Hello " + str;

            return true;
        }

        public bool MessageWithRefObjectReturnBool(ref Client client)
        {
            return true;
        }

        public string MessageWithReturnString(string message)
        {
            Console.WriteLine(message);

            return message.ToLower();
        }
    }

    public class LoggerFake : IGeneralLogger
    {
        public int PriorityLogger { get; set; }
        public string TypeLogger { get; set; }

        public bool LogBalanceAfterWithdraw(int balance)
        {
            return false;
        }

        public bool LogDatabase(string message)
        {
            return false; 
        }

        public void Message(string message)
        {
          
        }

        public bool MessageWithOutParameterReturnsBool(string str, out string outStr)
        {
            outStr = "";
            return true;
        }

        public bool MessageWithRefObjectReturnBool(ref Client client)
        {
            return true;
        }

        public string MessageWithReturnString(string message)
        {
            return message.ToLower();
        }
    }
}
