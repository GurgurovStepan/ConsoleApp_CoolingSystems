using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Test
    {
        #region Поля

        /// <summary>
        /// начальная температура (гр. Цельсия)
        /// </summary>
        private sbyte iterator = 50;

        /// <summary>
        /// интенсивность (мс)
        /// </summary>
        private int intensity = 100;

        /// <summary>
        /// максимальная температура для выполнения условия (true) цикла for метода "IncreaseTemp"
        /// </summary>
        private sbyte incMaxTemp = 100;

        /// <summary>
        /// максимальная температура для выполнения условия (true) цикла for метода "LowerTemp"
        /// </summary>
        private sbyte lowMaxTemp = 50;


        #endregion

        #region Методы

        /// <summary>
        /// Увеличить температуру
        /// </summary>
        /// <param name="mC">объект класса "Управление моторами холодильной камерой"</param>
        /// <param name="iter">начальная температура (температура начала отсчета), градусы Цельсия</param>
        /// <param name="inten">интенсивность выполнения итераций, время остановки программы (мс)</param>
        public void IncreaseTemp(MainControl mC, ref sbyte iter, int inten)
        {
            for (; iter < incMaxTemp; iter++)
            {
                if (iter < incMaxTemp)
                {
                    mC.SetCurrentTemp(iter);
                    System.Threading.Thread.Sleep(inten);
                }
            }
        }

        /// <summary>
        /// Увеличить температуру
        /// </summary>
        /// <param name="mC">объект класса "Управление моторами холодильной камерой"</param>
        public void IncreaseTemp(MainControl mC)
        {
            for (; iterator < incMaxTemp; iterator++)
            {
                if (iterator < incMaxTemp)
                {
                    mC.SetCurrentTemp(iterator);
                    System.Threading.Thread.Sleep(intensity);
                }
            }
        }

        /// <summary>
        /// Уменьшить температуру
        /// </summary>
        /// <param name="mC">объект класса "Управление моторами холодильной камерой"</param>
        /// <param name="iter">начальная температура (температура начала отсчета), градусы Цельсия</param>
        /// <param name="inten">интенсивность выполнения итераций, время остановки программы (мс)</param>
        public void LowerTemp(MainControl mC, ref sbyte iter, int inten)
        {
            for (; iter > lowMaxTemp; iter--)
            {
                if (iter > lowMaxTemp)
                {
                    mC.SetCurrentTemp(iter);
                    System.Threading.Thread.Sleep(inten);
                }
            }
        }

        /// <summary>
        /// Уменьшить температуру
        /// </summary>
        /// <param name="mC">объект класса "Управление моторами холодильной камерой"</param>
        public void LowerTemp(MainControl mC)
        {
            for (; iterator > lowMaxTemp; iterator--)
            {
                if (iterator > lowMaxTemp)
                {
                    mC.SetCurrentTemp(iterator);
                    System.Threading.Thread.Sleep(intensity);
                }
            }
        }

        #endregion
    }
}
