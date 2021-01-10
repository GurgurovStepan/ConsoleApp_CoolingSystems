namespace CoolingSystem.OneCoolant
{
    /// <summary>
    /// Система охлаждения (СО)
    /// </summary>
    class Chiller
    {
        #region Поля

        /// <summary>
        /// Значения температурных уставок охлаждающей жидкости (ОЖ) на вкл./откл. мотор-вентиляторов (МВ)
        /// </summary>
        public readonly sbyte[,] tempsOnOff = new sbyte[,] { { 70, 80, 90 },   /* вкл. */
                                                             { 60, 70, 80 } }; /* откл. */
        #endregion

        #region Свойства

        /// <summary>
        /// Число МВ требуемое для штатной работы СО
        /// </summary>
        public byte NumberOfMotors { get; } = 3;

        #endregion
    }
}
