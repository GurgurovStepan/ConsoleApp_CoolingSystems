namespace ConsoleApp3
{
    /// <summary>
    /// Система охлаждения (СО)
    /// </summary>
    class Chiller
    {
        #region Поля

        /// <summary>
        /// Значения температурных уставок охлаждающей жидкости (ОЖ) на вкл./откл. МВ
        /// </summary>
        public readonly sbyte[,] tempsOnOff = new sbyte[,] { { 70, 80, 90 },   /* вкл. */
                                                             { 60, 70, 80 } }; /* откл. */
        #endregion

        #region Свойства

        /// <summary>
        /// Число мотор-вентиляторов (МВ) необходимое для работы СО
        /// </summary>
        public sbyte NumberOfMotors { get; } = 3;

        #endregion
    }
}
