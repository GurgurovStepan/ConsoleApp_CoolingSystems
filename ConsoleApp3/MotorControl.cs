using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private void MotorControl_SwitchedOn()
        {
            Console.WriteLine("Мотро включился");
        }

        /// <summary>
        /// Мотор отключился
        /// </summary>
        private void MotorControl_SwitchedOff()
        {
            Console.WriteLine("Мотро включился");
        }

        #endregion

        #region Поля

        /// <summary>
        /// Моторы
        /// </summary>
        private Motor[] motor;

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
                motor[i] = new Motor();
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
