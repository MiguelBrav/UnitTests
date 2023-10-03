using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.InitialProject.TestExercise
{
    public class Client : IClient
    {
        public string ClientName { get; set; }

        public int Discount { get; set; }

        public int TotalOrder { get; set; }

        public bool IsPremium { get; set; }

        public Client()
        {
            IsPremium = false;
            Discount = 10;
        }

    }
}
