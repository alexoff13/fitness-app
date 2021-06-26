using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    #region Свойства
    {/// <summary>
     /// Имя
     /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// рост
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// возраст
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым");
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Имя пола не может быть пустым",nameof(gender));
            }

            if(birthDate<DateTime.Parse("01.01.1900") || birthDate>=DateTime.Now)
            {
                throw new ArgumentException("невозможная дата рождения",nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть <= 0",nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("рост не может быть <=0",nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым",nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name +" Возраст: "+ Age;
        }
    }
}
