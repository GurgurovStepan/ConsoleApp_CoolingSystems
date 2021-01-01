using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Chiller chiller = new Chiller();

            UInt32 i = 0;

            while (i<1000000)
            {
                i++;

                if (i == 10) System.Threading.Thread.Sleep(5000);

                if (i == 10) chiller.TurnOff();

                if (i == 100000) System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
