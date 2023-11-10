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
            var exercisesController = new ExerciseController(userController.CurrentUser);
            
            if(userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("Enter_Gender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения");
                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост"); 

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var el in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{el.Key} - {el.Value} ");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        //var exercise = new Exercise(exe.Begin, exe.End, exe.Activity, userController.CurrentUser);
                        exercisesController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exercisesController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                if (key.Key == ConsoleKey.E)
                {
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);
                    foreach (var el in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"{el.Key} - {el.Value} ");
                    }
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");
            var activity = new Activity(name,energy);
            return (begin, end, activity);
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
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }
            return birthDate;
        }
    }
}
