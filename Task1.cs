using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delagates
{
    class Task1
    {
        public delegate int getSum(int x, int y, int z);
        public getSum getArifmeticSum = delegate (int x,int y,int z) {
            return (x + y + z) / 3;
        }; 
    }
}
