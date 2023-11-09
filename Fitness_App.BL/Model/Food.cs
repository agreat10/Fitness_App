using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get;  }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get;}

        //   /// <summary>
        /// Калории на 1 грам продукта
        /// </summary>
        //private double CaloriesOneGramm { get { return Calories / 100.0; }  }

        //private double ProteinsOneGramm { get { return Proteins / 100.0; } }

        //private double FatsOneGramm { get { return Fats / 100.0; } }

        //private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
       
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: проверка
            Name = name;
            Calories = calories / 100.0d;
            Proteins = proteins / 100.0d;
            Fats = fats / 100.0d;
            Carbohydrates = carbohydrates / 100.0d;     
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
