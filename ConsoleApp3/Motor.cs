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
  
        /// <summary>
        /// Включился
        /// </summary>
        public event EventHandler SwitchedOn = delegate { };
        public void OnSwitchedOn(object sender, EventArgs e)
        {
            EventHandler switchedOn = SwitchedOn;
            if (switchedOn != null)
                switchedOn(this, e);
        }

        /// <summary>
        /// Отключился
        /// </summary>
        public event EventHandler SwitchedOff = delegate { };
        public void OnSwitchedOff(object sender, EventArgs e)
        {
            EventHandler switchedOff = SwitchedOff;
            if (switchedOff != null)
                switchedOff(this, e);
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        public Motor(sbyte numb) 
        {
            WorkTime = 0;
            On = false;
            Off = true;
            Number = numb;
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

        /// <summary>
        /// Номер
        /// </summary>
        private sbyte number;

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
        
        /// <summary>
        /// Номер
        /// </summary>
        public sbyte Number { get => number; private set => number = value; }

        /// <summary>
        /// Время включения
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Время отключения
        /// </summary>
        public DateTime StopTime { get; private set; }

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
            StartTime = DateTime.UtcNow;
            OnSwitchedOn(this, new EventArgs());
        }

        /// <summary>
        /// Отключить мотор
        /// </summary>
        public void TurnOff() 
        {
            On = false;
            Off = true;
            StopTime = DateTime.UtcNow;
            OnSwitchedOff(this, new EventArgs());
        }

        #endregion

        #region Изменить значение наработки

        /// <summary>
        /// Подсчитать наработку
        /// </summary>
        /// <param name="time">время работы мотора</param>
        public void SetWorkTime(TimeSpan time) 
        {
            WorkTime += (uint)time.TotalSeconds;
        }

        #endregion

        #endregion
    }
}
