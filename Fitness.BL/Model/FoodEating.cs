using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{   /// <summary>
/// прием пищи
/// </summary>
    [Serializable]
    public class FoodEating
    {
        public DateTime Moment { get; }

        public Dictionary<Food, double> Foods { get; }

        public User User { get; }

        public FoodEating(User user)
        {
            User = user ?? throw new ArgumentNullException();
            Moment = DateTime.Now;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food,double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
