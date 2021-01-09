using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------\n" +
                              "--- Программа для тестирования алгоритма ------------------------------------------\n" +
                              "--- поддержания установленой температуры системы охлаждения с одним охладителем ---\n" +
                              "--- и с возможностью обеспечения равной наработки мотор-вентиляторов --------------\n" +
                              "--- вне зависимости от значений температур охладителя -----------------------------\n" +
                              "-----------------------------------------------------------------------------------\n");

            MainControl control = new MainControl();
            Test test = new Test();

            var exitButton = ConsoleKey.Escape;
            ConsoleKeyInfo cki;

            do
            {
                for (int i = 0; i < 5; i++)
                {
                    test.IncreaseTemp(control);
                    test.LowerTemp(control);
                }

                Console.WriteLine("\nДля выхода нажмите клавишу Esc\n");
                cki = Console.ReadKey(true);
                Console.WriteLine("\n");

            } while (cki.Key != exitButton);
        }
    }
}
