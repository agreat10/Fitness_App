using Fitness_App.BL.Controller;
using Fitness_App.BL.Model;
using System;
using System.Globalization;

namespace Fitness_App.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness_App");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();           

            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост"); 

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        /// <summary>
        /// Ввод и проверка роста и веса
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
        /// <summary>
        /// Ввод и проверка даты рождения
        /// </summary>
        /// <returns></returns>
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }
            return birthDate;
        }
    }
}
