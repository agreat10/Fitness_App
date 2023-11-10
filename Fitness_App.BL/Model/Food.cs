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
        public int Id { get; set; }
        
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set;  }

        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; set; }
        public Food()
        {
            
        }


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
