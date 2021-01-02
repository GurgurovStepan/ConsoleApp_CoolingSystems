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
            MainControl control = new MainControl();

            UInt32 i = 0;

            while (i<1000000)
            {
                i++;

                if (i == 10) 
                {
                    control.SetCurrentTemp(75);
                    System.Threading.Thread.Sleep(2000);

                    control.SetCurrentTemp(85);
                    System.Threading.Thread.Sleep(2000);

                    control.SetCurrentTemp(95);
                    System.Threading.Thread.Sleep(2000);

                    control.SetCurrentTemp(85);
                    System.Threading.Thread.Sleep(2000);

                    control.SetCurrentTemp(75);
                    System.Threading.Thread.Sleep(2000);

                    control.SetCurrentTemp(65);
                    System.Threading.Thread.Sleep(2000);
                }


                if (i == 100000) System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
