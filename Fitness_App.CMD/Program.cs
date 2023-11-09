using Fitness_App.BL.Controller;
using Fitness_App.BL.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Runtime.Remoting.Lifetime;

namespace Fitness_App.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness_App.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("Enter_Name", culture));
            var name = Console.ReadLine();           

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if(userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("Enter_Gender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост"); 

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var foods =  EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach(var el in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{el.Key} - {el.Value} ");
                }
            }
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите название продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность: ");
            var proteins = ParseDouble("протеины: ");
            var fats = ParseDouble("жиры: ");
            var carbohydrates = ParseDouble("углеводы: ");

            var weight = ParseDouble("вес порции: ");
            var product = new Food(food);
            return (Food: product,Weight: weight);

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
