using System;

namespace CoolingSystem.OneCoolant
{
    /// <summary>
    /// Управление мотор-вентиляторами (УМВ)
    /// </summary>
    class MotorControl
    {

        #region Обработчики событий

        /// <summary>
        /// МВ включился
        /// </summary>
        private void MotorControl_SwitchedOn(object sender, EventArgs e)
        {
            if (sender is Motor mot)
            {
                Console.WriteLine("Мотор-вентилятор {0} включился, время включения {1}. Наработка равна - {2}",
                    mot.Number, mot.StartTime, mot.WorkTime);
            }
        }

        /// <summary>
        /// МВ отключился
        /// </summary>
        private void MotorControl_SwitchedOff(object sender, EventArgs e)
        {
            if (sender is Motor mot)
            {
                Console.WriteLine("Мотор-вентилятор {0} отключился, время отключения {1}. Наработка равна - {2}",
                    mot.Number, mot.StopTime, mot.WorkTime);
            }
        }

        #endregion

        #region Поля

        /// <summary>
        /// Группа МВ СО 
        /// </summary>
        private readonly Motor[] motor;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создать 1 МВ с №0
        /// </summary>
        public MotorControl() : this(1)
        {
        }

        /// <summary>
        /// Создать группу МВ
        /// </summary>
        /// <param name="numb">число МВ (не ноль)</param>
        public MotorControl(byte numb)
        {
            if (numb == 0) numb = 1; // создать хотя бы 1 МВ

            motor = new Motor[numb]; // создать массив МВ

            for (byte i = 0; i < motor.Length; i++)
            {
                motor[i] = new Motor(i); // создать МВ
                motor[i].SwitchedOn += MotorControl_SwitchedOn;   // подписаться на событие включения МВ
                motor[i].SwitchedOff += MotorControl_SwitchedOff; // подписаться на событие отключения МВ
            }
        }

        #endregion

        #region Методы

        #region Изменить состояние МВ

        /// <summary>
        /// Включить МВ с минимальной наработкой
        /// </summary>
        public void TurnOnMotor()
        {
            var off = false; // наличие хотя бы одного отключенного МВ

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
                if (temp != null) temp.TurnOn();
            }
        }

        /// <summary>
        /// Отключить МВ с максимальной наработкой
        /// </summary>
        public void TurnOffMotor()
        {
            var on = false; // наличие хотя бы одного включенного МВ

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
                if (temp != null) temp.TurnOff();
            }
        }

        #endregion

        #region Определить МВ с максимальной и минимальной наработкой

        /// <summary>
        /// Определить МВ (отключенный) с минимальной наработкой 
        /// </summary>
        /// <returns>МВ с мин. наработкой</returns>
        private Motor GetMotorWithMinWorkTime()
        {
            int minIndex = 0;
            uint min = uint.MaxValue;

            for (int i = 0; i < motor.Length; i++)
            {
                if (motor[i].Off)
                {
                    if (min > motor[i].WorkTime)
                    {
                        min = motor[i].WorkTime;
                        minIndex = i;
                    }
                }
            }

            return motor[minIndex];
        }

        /// <summary>
        /// Определить МВ (включенный) с максимальной наработкой
        /// </summary>
        /// <returns>МВ с макс. наработкой</returns>
        private Motor GetMotorWithMaxWorkTime()
        {
            int maxIndex = 0;
            UInt32 max = 0;

            for (int i = 0; i < motor.Length; i++)
            {
                if (motor[i].WorkTime == 0) return motor[i];
                if (motor[i].On)
                {
                    if (motor[i].WorkTime > max)
                    {
                        max = motor[i].WorkTime;
                        maxIndex = i;
                    }
                }
            }

            return motor[maxIndex];
        }

        #endregion

        #region Вывод статистики в консоль
        
        /// <summary>
        /// Вывод статистики
        /// </summary>
        public void DisplayStatistics()
        {
            Console.WriteLine("\nСтатистика:");

            if (motor != null)
            {
                for (int i = 0; i < motor.Length; i++)
                {
                    Console.WriteLine("Мотор-вентилятор номер {0} наработал {1} секунд", motor[i].Number, motor[i].WorkTime);
                }
            }
            else
            {
                Console.WriteLine("Мотор-вентиляторы не созданы");
            }
        }

        #endregion

        #endregion
    }
}
