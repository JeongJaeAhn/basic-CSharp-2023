using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        public int temp;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler();
            kitturami.temp = 60;

            // ...
            kitturami.temp = 300000; // 보일러 물수온이 30만도?
        }
    }
}
