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
            Console.WriteLine("-----------------------------------------------------------------------------------\n" +
                              "--- Программа для тестирования алгоритма ------------------------------------------\n" +
                              "--- поддержания установленой температуры системы охлаждения с одним охладителем ---\n" +
                              "--- и с возможностью обеспечения равной наработки мотор-вентиляторов --------------\n" +
                              "--- вне зависимости от значений температур охладителя -----------------------------\n" +
                              "-----------------------------------------------------------------------------------\n");

            MainControl control = new MainControl();
            var exitButton = ConsoleKey.Escape;
            ConsoleKeyInfo cki;

            do
            {
                int iterator = 50;      // начальная температура
                int intensity = 200;    // интенсивность

                for (int i = 0; i < 5; i++)
                {
                    IncreaseTemp(control, ref iterator, intensity);
                    LowerTemp(control, ref iterator, intensity);
                }

                Console.WriteLine("\nДля выхода нажмите клавишу Esc");
                cki = Console.ReadKey(true);

            } while (cki.Key != exitButton);
        }

        /// <summary>
        /// Увеличить температуру
        /// </summary>
        /// <param name="mC"></param>
        /// <param name="iter"></param>
        /// <param name="inten"></param>
        static void IncreaseTemp(MainControl mC, ref int iter, int inten) 
        {
            for (; iter < 100; iter++)
            {
                if (iter < 100)
                {
                    mC.SetCurrentTemp((sbyte)iter);
                    System.Threading.Thread.Sleep(inten);
                }
            }
        }

        /// <summary>
        /// Уменьшить температуру
        /// </summary>
        /// <param name="mC"></param>
        /// <param name="iter"></param>
        static void LowerTemp(MainControl mC, ref int iter, int inten)
        {
            for (; iter > 50; iter--)
            {
                if (iter > 50)
                {
                    mC.SetCurrentTemp((sbyte)iter);
                    System.Threading.Thread.Sleep(inten);
                }
            }
        }

    }
}
