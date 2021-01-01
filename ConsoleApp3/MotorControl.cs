using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp3
{
    /// <summary>
    /// Управление мотором
    /// </summary>
    class MotorControl
    {

        #region Обработчики событий

        /// <summary>
        /// Мотор включился
        /// </summary>
        private void MotorControl_SwitchedOn(object sender, EventArgs e)
        {
            Motor mot = (Motor)sender;
            startTime = DateTime.UtcNow;
            Console.WriteLine("Мотор {0} включился, время включения {1}. Наработка равна - {2}", mot.Number, startTime, mot.WorkTime);
        }

        /// <summary>
        /// Мотор отключился
        /// </summary>
        private void MotorControl_SwitchedOff(object sender, EventArgs e)
        {
            Motor mot = (Motor)sender;
            mot.SetWorkTime(DateTime.UtcNow - startTime);
            Console.WriteLine("Мотор {0} отключился, время отключения {1}. Наработка равна - {2}", mot.Number, DateTime.UtcNow, mot.WorkTime);
        }

        #endregion

        #region Поля

        /// <summary>
        /// Моторы
        /// </summary>
        private Motor[] motor;

        /// <summary>
        /// время включения мотора 
        /// </summary>
        private DateTime startTime;  Необходимо для каждого мотора отдельно!!!

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создать моторы
        /// </summary>
        /// <param name="numb">число моторов</param>
        public MotorControl(byte numb)
        {
            motor = new Motor[numb];
            for (int i = 0; i < motor.Length; i++)
            {
                motor[i] = new Motor((sbyte)i);
                motor[i].SwitchedOn += MotorControl_SwitchedOn;
                motor[i].SwitchedOff += MotorControl_SwitchedOff;
            }

        }

        #endregion

        #region Методы

        #region Изменить состояние мотора

        /// <summary>
        /// Включить мотор с минимальной наработкой
        /// </summary>
        public void TurnOnMotor()
        {
            Motor temp = GetMotorWithMinWorkTime();
            temp.TurnOn();
        }

        /// <summary>
        /// Отключить мотор с максимальной наработкой
        /// </summary>
        public void TurnOffMotor()
        {
            Motor temp = GetMotorWithMaxWorkTime();
            temp.TurnOff();
        }

        #endregion

        #region Определить наработку мотора

        /// <summary>
        /// Определить мотор (отключенный) с минимальной наработкой 
        /// </summary>
        /// <returns></returns>
        private Motor GetMotorWithMinWorkTime()
        {
            int temp = 0;
            for (int i = 0; i < motor.Length - 1; i++)
            {
                if (motor[i].WorkTime < motor[i + 1].WorkTime)
                {
                    if (motor[i].Off) temp = i;
                }
            }
            return motor[temp];
        }

        /// <summary>
        /// Определить мотор (включенный) с максимальной наработкой
        /// </summary>
        /// <returns></returns>
        private Motor GetMotorWithMaxWorkTime()
        {
            int temp = 0;
            for (int i = 0; i < motor.Length - 1; i++)
            {
                if (motor[i].WorkTime > motor[i + 1].WorkTime)
                {
                    if (motor[i].On) temp = i;
                }
            }
            return motor[temp];
        }

        #endregion

        #endregion
    }
}
