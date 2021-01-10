using System;

namespace ConsoleApp3
{
    /// <summary>
    /// Управление мотор-вентиляторами(МВ) системы охлаждения(СО) (УМВСО)
    /// </summary>
    class MainControl
    {
        #region Поля

        /// <summary>
        /// система охлаждения
        /// </summary>
        private Chiller chiller;

        /// <summary>
        /// управление МВ
        /// </summary>
        private MotorControl motorControl;

        /// <summary>
        /// число включенных МВ
        /// </summary>
        private byte exceed = 0;

        /// <summary>
        /// температура включения МВ полученная от СО
        /// </summary>
        private sbyte[] tempsOn;

        /// <summary>
        /// температура отключения МВ полученная от СО
        /// </summary>
        private sbyte[] tempsOff;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создать систему управления МВ СО с установленными параметрами
        /// </summary>
        public MainControl()
        {
            chiller = new Chiller();
            SetTempsOnOff(chiller);
            DisplayDescriptions(chiller);
            motorControl = new MotorControl(chiller.NumberOfMotors);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Установить температуру ОЖ
        /// </summary>
        /// <param name="curTemp">температура ОЖ</param>
        public void SetCurrentTemp(sbyte curTemp)
        {
            for (int i = exceed; i < tempsOn.Length; i++)
            {
                if (curTemp > tempsOn[i])
                {
                    Console.WriteLine("Температура включения МВ равна {0}", curTemp);
                    motorControl.TurnOnMotor();
                    exceed++;
                }
            }

            if (exceed >= 0)
            {
                var numbIter = exceed;

                for (int i = 0; i < numbIter; i++)
                {
                    if (curTemp < tempsOff[i])
                    {
                        Console.WriteLine("Температура отключения МВ равна {0}", curTemp);
                        motorControl.TurnOffMotor();
                        exceed--;
                    }
                }
            }

        }

        /// <summary>
        /// Вывести в консоль наработку по МВ
        /// </summary>
        public void GetStatistics()
        {
            motorControl.DisplayStatistics();
        }

        /// <summary>
        /// Получить температурные уставки от системы охлаждения
        /// </summary>
        /// <param name="ch">система охлаждения</param>
        private void SetTempsOnOff(Chiller ch)
        {
            if (ch != null) 
            {
                int rows = ch.tempsOnOff.GetUpperBound(0) + 1;
                int columns = ch.tempsOnOff.Length / rows;

                tempsOn = new sbyte[columns];
                tempsOff = new sbyte[columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0)
                        {
                            tempsOn[j] = ch.tempsOnOff[i, j];
                        }
                        if (i == 1)
                        {
                            tempsOff[j] = ch.tempsOnOff[i, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Система охлаждения не создана");
            }
        }

        /// <summary>
        /// Вывести в консоль параметры системы охлаждения
        /// </summary>
        /// <param name="ch">система охлаждения</param>
        private void DisplayDescriptions(Chiller ch)
        {
            if (ch != null)
            {
                Console.WriteLine("  Параметры системы охлаждения:\n" +
                                  "- количество мотор-вентиляторов равно: {0}", ch.NumberOfMotors);
                Console.Write(    "- температурные уставки ОЖ на вкл.  МВ равно: ");

                if (tempsOn != null) 
                {
                    foreach (var item in tempsOn)
                    {
                        Console.Write(" {0} ", item);
                    }
                    Console.WriteLine("");
                }
                else 
                {
                    Console.WriteLine("Температурные уставки ОЖ на вкл. МВ отсутствуют");
                }

                Console.Write("- температурные уставки ОЖ на откл. МВ равно: ");

                if (tempsOff != null) 
                {
                    foreach (var item in tempsOff)
                    {
                        Console.Write(" {0} ", item);
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Температурные уставки ОЖ на откл. МВ отсутствуют");
                }

            }
            else 
            {
                Console.WriteLine("Система охлаждения не создана");
            }
        }

        #endregion
    }
}
