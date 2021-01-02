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
        /// управление холодилькой
        /// </summary>
        private ChillerControl chillerControl;

        /// <summary>
        /// управление мотором
        /// </summary>
        private MotorControl motorControl;      

        #endregion

        #region Конструкторы

        public MainControl() 
        {                              
            chillerControl = new ChillerControl();              
            motorControl = new MotorControl(chillerControl.NumberOfMotors);     
        }

        #endregion

        #region Методы

        /// <summary>
        /// Установить температуру ОЖ
        /// </summary>
        /// <param name="temp">температура ОЖ</param>
        public void SetCurrentTemp(sbyte temp) 
        {
            var numbMotorTurnOn = chillerControl.FindNumberMotorTurnOn(temp);
            for (int i = 0; i < numbMotorTurnOn; i++)
            {
                motorControl.TurnOnMotor();
            }
        }

        #endregion
    }
}
