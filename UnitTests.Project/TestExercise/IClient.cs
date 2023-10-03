using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.InitialProject.TestExercise
{
    public interface IClient
    {
        string ClientName { get; set; }

        int Discount {get; set; }

        int TotalOrder { get; set; }

        bool IsPremium { get; set; }

    }
}
