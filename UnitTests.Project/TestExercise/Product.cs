using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.InitialProject.TestExercise
{
    public class Product
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public double Price { get; set; }

        public double GetPrice(Client client)
        {
            return client.IsPremium ? Price * .8 : Price;
        }

        public double GetPrice(IClient client)
        {
            return client.IsPremium ? Price * .8 : Price;
        }
    }
}
