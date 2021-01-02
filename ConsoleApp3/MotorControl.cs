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
            Console.WriteLine("Мотор {0} включился, время включения {1}. Наработка равна - {2}", mot.Number, mot.StartTime, mot.WorkTime);
        }

        /// <summary>
        /// Мотор отключился
        /// </summary>
        private void MotorControl_SwitchedOff(object sender, EventArgs e)
        {
            Motor mot = (Motor)sender;
            mot.SetWorkTime(mot.StopTime - mot.StartTime); // подсчитать наработку за период вкл./откл.
            Console.WriteLine("Мотор {0} отключился, время отключения {1}. Наработка равна - {2}", mot.Number, mot.StopTime, mot.WorkTime);
        }

        #endregion

        #region Поля

        /// <summary>
        /// Моторы
        /// </summary>
        private Motor[] motor;

        #endregion

        #region Конструкторы

        public MotorControl() { }

        /// <summary>
        /// Создать моторы
        /// </summary>
        /// <param name="numb">число моторов</param>
        public MotorControl(sbyte numb)
        {
            motor = new Motor[numb];
            for (sbyte i = 0; i < motor.Length; i++)
            {
                motor[i] = new Motor(i);
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
            var off = false; // наличие хотя бы одного отключенного мотора

            for (int i = 0; i < motor.Length; i++)
            {
                if (motor[i].Off)
                {
                    off = true;
                    break;
                }
            }

            if (off)
            {
                Motor temp = GetMotorWithMinWorkTime();
                temp.TurnOn();
            }
        }

        /// <summary>
        /// Отключить мотор с максимальной наработкой
        /// </summary>
        public void TurnOffMotor()
        {
            var on = false; // наличие хотя бы одного включенного мотора

            for (int i = 0; i < motor.Length; i++)
            {
                if (motor[i].On)
                {
                    on = true;
                    break;
                }
            }

            if (on)
            {
                Motor temp = GetMotorWithMaxWorkTime();
                temp.TurnOff();
            }
        }

        #endregion

        #region Определить мотор с максимальной и минимальной наработкой

        /// <summary>
        /// Определить мотор (отключенный) с минимальной наработкой 
        /// </summary>
        /// <returns></returns>
        private Motor GetMotorWithMinWorkTime()
        {
            int temp = 0;

            for (int i = 0; i < motor.Length - 1; i++)
            {
                if (motor[i].On)
                {
                    temp++;
                }
                else if (motor[i].WorkTime < motor[i + 1].WorkTime)
                {
                    temp = i;
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
            int index = 0;
            uint max = uint.MinValue;

            for (int i = 0; i < motor.Length; i++)
            {
                if (motor[i].On)
                {
                    if (motor[i].WorkTime > max)
                    {
                        max = motor[i].WorkTime;
                        index = i;
                    }
                }
                else
                {
                    if (i < motor.Length - 1) index++;
                }
            }

            return motor[index];
        }

        #endregion

        #endregion
    }
}
