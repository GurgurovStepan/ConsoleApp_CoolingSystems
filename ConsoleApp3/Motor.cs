using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// Мотор
    /// </summary>
    class Motor
    {
        #region События

        public delegate void EvHand();

        /// <summary>
        /// Включился
        /// </summary>
        public event EvHand SwitchedOn = delegate { };
        public void OnSwitchedOn()
        {
            EvHand switchedOn = SwitchedOn;
            if (switchedOn != null)
                switchedOn();
        }

        /// <summary>
        /// Отключился
        /// </summary>
        public event EvHand SwitchedOff = delegate { };
        public void OnSwitchedOff()
        {
            EvHand switchedOff = SwitchedOff;
            if (switchedOff != null)
                switchedOff();
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        public Motor() 
        {
            WorkTime = 0;
            On = false;
            Off = true;
        }

        #endregion

        #region Поля

        /// <summary>
        /// Наработка
        /// </summary>
        private UInt32 workTime;

        /// <summary>
        /// Состояние: включен - true
        /// </summary>
        private bool on;

        /// <summary>
        /// Состояние: отключен - true
        /// </summary>
        private bool off;

        #endregion

        #region Свойства

        /// <summary>
        /// Состояние включен
        /// </summary>
        public bool On { get => on; private set => on = value; }
        
        /// <summary>
        /// Состояние отключен
        /// </summary>
        public bool Off { get => off; private set => off = value; }

        /// <summary>
        /// Нарабока
        /// </summary>
        public uint WorkTime { get => workTime; private set => workTime = value; }

        #endregion

        #region Методы

        #region Изменить состояние мотора

        /// <summary>
        /// Включить мотор
        /// </summary>
        public void TurnOn() 
        {
            On = true;
            Off = false;
            OnSwitchedOn();
        }

        /// <summary>
        /// Отключить мотор
        /// </summary>
        public void TurnOff() 
        {
            On = false;
            Off = true;
            OnSwitchedOff();
        }

        #endregion

        #region Изменить наработку

        public void SetWorkTime() 
        {
            WorkTime++;
        }

        #endregion

        #endregion
    }
}
