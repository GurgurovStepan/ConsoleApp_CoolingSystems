using System;

namespace CoolingSystem.OneCoolant
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

            Console.WriteLine("Тестирование алгоритма...\n");

            do
            {
                for (int i = 0; i < 3; i++)
                {
                    test.IncreaseTemp(control);
                    test.LowerTemp(control);
                }

                control.GetStatistics();

                Console.WriteLine("\nДля выхода нажмите клавишу Esc.\n"+"Продолжить тестирование любую клавищу.\n");
                cki = Console.ReadKey(true);
                Console.WriteLine("\n");

            } while (cki.Key != exitButton);
        }
    }
}
