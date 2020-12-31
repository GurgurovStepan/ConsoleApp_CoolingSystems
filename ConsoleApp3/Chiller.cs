using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// Холодилка.
    /// </summary>
    class Chiller
    {
        #region Поля

        /// <summary>
        /// число необходимых моторов
        /// </summary>
        private readonly byte motorNumber = 3;
        
        /// <summary>
        /// уставка на включение моторов
        /// </summary>
        private readonly byte[] tempsOn = new byte[3] {70,80,90};
        
        /// <summary>
        /// уставка на отключение моторов
        /// </summary>
        private readonly byte[] tempsOff = new byte[3] {60,70,80};

        /// <summary>
        /// управление моторами
        /// </summary>
        private MotorControl motorControl;

        /// <summary>
        /// текущая температура
        /// </summary>
        private UInt32 currentTemps;

        #endregion

        #region Свойства

        /// <summary>
        /// Текущая температура
        /// </summary>
        public uint CurrentTemps { get => currentTemps; set => currentTemps = value; }

        #endregion


        #region Конструкторы 
        public Chiller() 
        {
            motorControl = new MotorControl(motorNumber);
            motorControl.TurnOnMotor();
            motorControl.TurnOffMotor();
        }

        #endregion
    }
}
