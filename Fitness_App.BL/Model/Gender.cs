using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название пола
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name">Имя пола</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name)); 
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    
}
