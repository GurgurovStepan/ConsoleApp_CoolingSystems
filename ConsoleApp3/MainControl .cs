using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MainControl
    {
        #region Поля

        /// <summary>
        /// холодилка
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
            motorControl = new MotorControl(chiller.NumberOfMotors);
            SetTempsOnOff();
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
        /// Получить температурные уставки от СО
        /// </summary>
        private void SetTempsOnOff() 
        {
            int rank = chiller.tempsOnOff.Rank;
            int rows = chiller.tempsOnOff.GetUpperBound(rank - 1);
            int columns = chiller.tempsOnOff.Length / rows;

            tempsOn = new sbyte[columns];
            tempsOff = new sbyte[columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0) tempsOn[j] = chiller.tempsOnOff[i, j];
                    if (i == 1) tempsOff[j] = chiller.tempsOnOff[i, j];
                }
            }
        }

        #endregion
    }
}
