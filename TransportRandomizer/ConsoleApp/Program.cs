using System;
using System.Collections.Generic;  // Для List'ов.
using System.IO;  // Для записи результатов в файлы.
using System.Text;  // Для StringBuilder'a.
using EKRLib;  // Подключение библиотеки классов.

/// <summary>
/// Пространство имён консольного приложения.
/// </summary>
namespace ConsoleApp
{
    /// <summary>
    /// Класс программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Рандомайзер.
        /// </summary>
        private static Random s_random = new();

        /// <summary>
        /// Точка входа программы.
        /// </summary>
        static void Main()
        {
            do
            {
                var transports = new Transport[s_random.Next(6, 10)];

                for (int i = 0; i < transports.Length; i++)
                {
                    bool exTracker;
                    do
                    {
                        try
                        {
                            if (s_random.Next(2) == 0)
                                transports[i] = new Car(RandomName(), (uint)s_random.Next(10, 100));
                            else
                                transports[i] = new MotorBoat(RandomName(), (uint)s_random.Next(10, 100));
                            Console.WriteLine(transports[i].StartEngine());
                            exTracker = false;
                        }
                        catch (TransportException ex)
                        {
                            Console.WriteLine(ex.Message);
                            exTracker = true;
                        }
                    } while (exTracker);
                }

                // Разбиение массива Transport на массивы Car и MotorBoat.
                (Car[] cars, MotorBoat[] boats) = Sorting(transports);

                FileWriting(cars, boats);
                Console.WriteLine("\nДля повтора нажмите ЛЮБУЮ клавишу, для выхода - ESC\n");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Генерация корректного случайного имени длиной 5.
        /// </summary>
        /// <returns> Сгенерированное имя. </returns>
        private static string RandomName()
        {
            var sb = new StringBuilder(5);

            for (int i = 0; i < 5; i++)
            {
                if (s_random.Next(2) == 0)
                {
                    sb.Append((char)s_random.Next('A', 'Z' + 1));
                }
                else
                {
                    sb.Append((char)s_random.Next('0', '9' + 1));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Запись данных в файлы "Cars.txt" и "MotorBoats.txt".
        /// </summary>
        /// <param name="dataCars"> Массив данных о машинах. </param>
        /// <param name="dataBoats"> Массив данных о моторных лодках. </param>
        private static void FileWriting(Car[] dataCars, MotorBoat[] dataBoats)
        {
            string pathToCar = $"..{Path.DirectorySeparatorChar}" +
                               $"..{Path.DirectorySeparatorChar}" +
                               $"..{Path.DirectorySeparatorChar}.." +
                               $"{Path.DirectorySeparatorChar}Cars.txt";
            try
            {
                using (StreamWriter sw = new(pathToCar, false, Encoding.Unicode))
                {
                    foreach (Car car in dataCars)
                        sw.WriteLine(car.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при записи данных dataCars.");
            }

            string pathToBoat = $"..{Path.DirectorySeparatorChar}" +
                                $"..{Path.DirectorySeparatorChar}" +
                                $"..{Path.DirectorySeparatorChar}" +
                                $"..{Path.DirectorySeparatorChar}MotorBoats.txt";
            try
            {
                using (StreamWriter sw = new(pathToBoat, false, Encoding.Unicode))
                {
                    foreach (MotorBoat boat in dataBoats)
                        sw.WriteLine(boat.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при записи данных dataBoats.");
            }
        }

        /// <summary>
        /// Фильтрация массива Transport.
        /// </summary>
        /// <param name="transports"> Фильтруемый массив. </param>
        /// <returns> Кортеж двух новых массивов Car и MotorBoat. </returns>
        private static (Car[], MotorBoat[]) Sorting(Transport[] transports)
        {
            List<Car> cars = new();
            List<MotorBoat> boats = new();

            foreach (Transport transport in transports)
            {
                if (transport is Car)
                    cars.Add((Car)transport);
                else
                    boats.Add((MotorBoat)transport);
            }

            return (cars.ToArray(), boats.ToArray());
        }
    }
}
