using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delagates
{
    class Task3
    {
        public delegate double Method(double x,double y);
        double Add(double x, double y) => x + y;
        double Sub(double x, double y) => x - y;
        double Mul(double x, double y) => x * y;
        double Div(double x, double y) => y == double.PositiveInfinity ? 0 : x / y;
        public Task3(string str)
        {
            try
            {
                if (!IsValid(str))
                {
                    Console.WriteLine("invalid input");
                    return;
                }
                var separatedMass = Separate(str);
                Console.WriteLine(Calculate(separatedMass));
            }
            catch
            {
                Console.WriteLine("invalid input");
            }
        }
        public bool IsValid(string str)
        {
            var mass = str.Split('+', '-', '*', '/');
            if (mass.Length == 1) return false;
            foreach (var item in mass)
            {
                double number;
                if (!double.TryParse(item, out number)) return false;
            }
            return true;
        }
        public List<dynamic> Separate(string str)
        {
            var allChapters = new List<dynamic>();
            string result = str.Trim();
            var chapters = new string[] { "+", "-", "*", "/" };
            foreach (var item in chapters)
            {
                result = result.Replace(item, "#"+item+"#");
            }
            var stringMass = result.Split('#');
            foreach (var item in stringMass)
            {
                double number;
                if (double.TryParse(item, out number)) allChapters.Add(number);
                else allChapters.Add(item);
            }
            return allChapters;
        }
        public double Calculate(List <dynamic> separatedMass)
        {
            void FastCalculate(string sign1,string sign2, Method method1,Method method2)
            {
                for (var i = 0; i < separatedMass.Count(); i++)
                {
                    if ("" + separatedMass[i] ==sign1 || "" + separatedMass[i] ==sign2)
                    {
                        double first = separatedMass[i - 1];
                        double second = separatedMass[i + 1];
                        double result = ("" + separatedMass[i] ==sign1) ? method1(first, second) : method2(first, second);
                        separatedMass.RemoveRange(i - 1, 3);
                        separatedMass.Insert(i - 1, result);
                        i = 0;
                    }
                }
            }
            Method method1 = Mul;
            Method method2 = Div;
            FastCalculate("*", "/",method1,method2);
            Method method3 = Add;
            Method method4 = Sub;
            FastCalculate("+", "-", method3, method4);
            return separatedMass[0];
        }
    }
}
