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

        #endregion

        #region Конструкторы

        public MainControl()
        {
            chiller = new Chiller();
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
            sbyte[] t0Level = new sbyte[] { 70, 80, 90 };

            for (int i = exceed; i < t0Level.Length; i++)
            {
                if (curTemp > t0Level[i])
                {
                    Console.WriteLine("Температура включения МВ равна {0}", curTemp);
                    motorControl.TurnOnMotor();
                    exceed++;
                }
            }

            sbyte[] t1Level = new sbyte[] { 60, 70, 80 };

            if (exceed >= 0)
            {
                var numbIter = exceed;

                for (int i = 0; i < numbIter; i++)
                {
                    if (curTemp < t1Level[i])
                    {
                        Console.WriteLine("Температура отключения МВ равна {0}", curTemp);
                        motorControl.TurnOffMotor();
                        exceed--;
                    }
                }
            }

        }

        #endregion
    }
}
