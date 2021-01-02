using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class ChillerControl
    {
        #region Поля
        
        /// <summary>
        /// холодилка
        /// </summary>
        private Chiller chiller;

        #endregion

        #region Свойства
        
        /// <summary>
        /// Число моторов необходимых холодилке
        /// </summary>
        public sbyte NumberOfMotors { get; private set; }

        #endregion

        #region Конструкторы

        public ChillerControl() 
        {
            chiller = new Chiller();
            NumberOfMotors = chiller.motorNumber;
        }

        #endregion

        #region Методы

        public sbyte FindNumberMotorTurnOn(sbyte curTemp) 
        {
            if (curTemp >= 70 && curTemp < 80) return 1;
            else if (curTemp >= 80 && curTemp < 90) return 2;
            else if (curTemp >= 80 && curTemp < 90) return 3;
            else return 0;
        }

        #endregion
    }
}
