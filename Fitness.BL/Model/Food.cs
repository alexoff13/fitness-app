using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
        {/// <summary>
        /// название продукта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// калории за 1г продукта
        /// </summary>
        public double Calories { get; }

        public Food (string name): this(name, 0, 0, 0, 0) { }
            
        public Food(string name, double calories, double fats, double proteins, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Fats = fats / 100.0;
            Proteins = proteins / 100.0;
            Carbohydrates = carbohydrates/100;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
