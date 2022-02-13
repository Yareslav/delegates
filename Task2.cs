using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delagates
{
    class Task2
    {
        public delegate int getRandomNumber();
        public delegate int getSum(getRandomNumber [] mass);
        public getSum calculate = delegate (getRandomNumber[] mass)
         {
             int sum = 0;
             for (var i = 0; i <mass.Length; i++)
             {
                 sum += mass[i]();
             }
             return sum/mass.Length;
         };
        public getRandomNumber number1 = delegate ()
        {
              return (new Random()).Next(50);
        };
        public getRandomNumber number2 = delegate ()
        {
            return (new Random()).Next(100);
        };
        public getRandomNumber number3 = delegate ()
        {
            return (new Random()).Next(150);
        };
        public getRandomNumber number4 = delegate ()
        {
            return (new Random()).Next(200);
        };
        public int Start()
        {
            return calculate(new getRandomNumber[] {number1,number2,number3,number4});
        }
    }
}
