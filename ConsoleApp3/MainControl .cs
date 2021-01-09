using System;

namespace ConsoleApp3
{
    /// <summary>
    /// Управление моторами системы охлаждения
    /// </summary>
    class MainControl
    {
        #region Поля

        /// <summary>
        /// система охлаждения
        /// </summary>
        private Chiller chiller;

        /// <summary>
        /// управление мотором
        /// </summary>
        private MotorControl motorControl;

        /// <summary>
        /// число включенных моторов
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

        public MainControl()
        {
            chiller = new Chiller();
            SetTempsOnOff();

            Console.WriteLine("  Параметры системы охлаждения:\n" + 
                              "- количество мотор-вентиляторов равно: {0}", chiller.NumberOfMotors);
            Console.Write("- температурные уставки ОЖ на вкл.  МВ равно: ");
            foreach (var item in tempsOn)
            {
                Console.Write(" {0} ", item);
            }
            Console.WriteLine("");
            Console.Write("- температурные уставки ОЖ на откл. МВ равно: ");
            foreach (var item in tempsOff)
            {
                Console.Write(" {0} ", item);
            }
            Console.WriteLine("\n");

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

        public void GetStatistics() 
        {
            motorControl.DisplayStatistics();
        }

        /// <summary>
        /// Получить температурные уставки от СО
        /// </summary>
        private void SetTempsOnOff() 
        {
            int rows = chiller.tempsOnOff.GetUpperBound(0) + 1;
            int columns = chiller.tempsOnOff.Length / rows;

            tempsOn = new sbyte[columns];
            tempsOff = new sbyte[columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        tempsOn[j] = chiller.tempsOnOff[i, j];
                    }
                    if (i == 1)
                    {
                        tempsOff[j] = chiller.tempsOnOff[i, j];
                    }
                }
            }
        }

        #endregion
    }
}
