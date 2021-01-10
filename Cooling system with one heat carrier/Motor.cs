using System;

namespace CoolingSystem.OneCoolant
{
    /// <summary>
    /// Мотор-вентилятор(МВ)
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
        /// Создать МВ с указаным порядковым номером
        /// </summary>
        /// <param name="numb">порядковый номер МВ</param>
        public Motor(byte numb)
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
        /// Номер
        /// </summary>
        private byte number;

        #endregion

        #region Свойства

        /// <summary>
        /// Состояние включен
        /// </summary>
        public bool On { get; private set; }

        /// <summary>
        /// Состояние отключен
        /// </summary>
        public bool Off { get; private set; }

        /// <summary>
        /// Нарабока
        /// </summary>
        public uint WorkTime { get => workTime; private set => workTime = value; }

        /// <summary>
        /// Номер
        /// </summary>
        public byte Number { get => number; private set => number = value; }

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

        #region Изменить состояние МВ

        /// <summary>
        /// Включить МВ
        /// </summary>
        public void TurnOn()
        {
            On = true;
            Off = false;
            StartTime = DateTime.UtcNow;
            OnSwitchedOn(this, new EventArgs());
        }

        /// <summary>
        /// Отключить МВ
        /// </summary>
        public void TurnOff()
        {
            On = false;
            Off = true;
            StopTime = DateTime.UtcNow;
            if (StopTime>StartTime) SetWorkTime(StopTime - StartTime);  // подсчитать наработку за период вкл./откл.
            OnSwitchedOff(this, new EventArgs());
        }

        #endregion

        #region Изменить значение наработки

        /// <summary>
        /// Подсчитать наработку
        /// </summary>
        /// <param name="time">время работы МВ</param>
        private void SetWorkTime(TimeSpan time)
        {
            WorkTime += (uint)time.TotalSeconds;
        }

        #endregion

        #endregion
    }
}
