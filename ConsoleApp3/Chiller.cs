using System;

namespace ConsoleApp3
{
    /// <summary>
    /// Холодильная камера (ХК)
    /// </summary>
    class Chiller
    {
        #region Поля

        /// <summary>
        /// общее число мотор-вентиляторов (МВ) необходимое для работы ХК
        /// </summary>
        public readonly sbyte motorNumber = 3;

        /// <summary>
        /// Значения температурных уставок охлаждающей жидкости (ОЖ) на вкл./откл. МВ
        /// </summary>
        public readonly sbyte[,] tempsOnOff = new sbyte[,] { { 70, 80, 90 }, 
                                                             { 60, 70, 80 } };

        #endregion

        #region Свойства

        #endregion

        #region Конструкторы 
        public Chiller()
        {

        }

        #endregion

        #region Методы

        #endregion


    }
}
