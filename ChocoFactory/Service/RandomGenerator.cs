using ChocoFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChocoFactory.Services
{
    public  static class DataGenerator
    {
        public  static decimal PricePerKilo()  //create a random Quality indicator with limits[1-20]
        {
            var random = new Random();
            Thread.Sleep(1);
            decimal number = random.Next(1, 21);
            return number;
        }
        public  static Quality Quality()       //Create a random Object Quality
        {
            var rnd = new Random();
            Thread.Sleep(1);
            Array values = Enum.GetValues(typeof(Quality));
            int index = rnd.Next(0, values.Length);
            return (Quality)values.GetValue(index);
        }
        public static int Quantity()       //create a random Quantity number with limitis [300-1000]
        {
            var r = new Random();
            Thread.Sleep(1);
            int num = r.Next(300, 1001);
            return num;
        }

        public static int FakeID()             //Create a random ID number with limits [100-201]
        {
            var x1 = new Random();
            Thread.Sleep(1);
            int x2 = x1.Next(100, 200);
            return x2;
        }

        public static int FakeOrderID()        //Create a random OrderID number with limits [1000-2011]
        {
            var x3 = new Random();
            Thread.Sleep(1);
            int x4 = x3.Next(1000, 2011);
            return x4;
        }


    }
}
