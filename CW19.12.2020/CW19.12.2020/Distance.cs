using System;
using System.Collections.Generic;
using System.Text;

namespace CW19._12._2020
{
    /// <summary>
    /// Предоставляет метод для перевода единиц длинны
    /// </summary>
    class Distance
    {
        /// <summary>
        /// Количество километров в 1 миле
        /// </summary>
        private const double kilometersInMile = 1.60934;
        /// <summary>
        /// Переводит километры в мили
        /// </summary>
        /// <param name="kilometers">Расстояние в километрах</param>
        /// <exception cref="ArgumentException">
        /// <code>
        /// int c = Distance.KilometersToMiles(20);
        /// </code>
        /// Если параметр<paramref name="kilometers"/>меньше нуля
        /// </exception>
        /// <returns>расстояние в милях</returns>
        /// Обратная операция <see>MilesToKilometers</see>

        public static double KilometersToMiles(double kilometers)
        {
            if (kilometers < 0)
            {
                throw new ArgumentException("Значение должно быть неотрицательным");
            }
            return kilometers * 1/kilometersInMile;
        }

        /// <summary>
        /// Переводит мили в километры
        /// </summary>
        /// <param name="miles">Расстояние в милях</param>
        /// <exception cref="ArgumentException">Если параметр<paramref name="miles"/>меньше нуля</exception>
        /// <returns>Расстояние в километрах</returns>

        public static double MilesToKilometers(double miles)
        {
            if (miles < 0)
            {
                throw new ArgumentException("Значение должно быть неотрицательным");
            }
            return miles * kilometersInMile;
        }
    }
}
