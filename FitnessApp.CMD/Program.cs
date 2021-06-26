using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitnessApp");
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();



            UserController userController = new UserController(name);
            var eatingController = new FoodEatingController(userController.CurrentUser);


            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                string gender = Console.ReadLine();
                DateTime birthDate;
                birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
            Console.WriteLine();
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var e in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{e.Key} - {e.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("ВВедите имя продукта: ");
            string foodName = Console.ReadLine();


            double weight = ParseDouble("вес");


            double callories = ParseDouble("каллории");


            double proteins = ParseDouble("белки");

            double fats = ParseDouble("жиры");

            double carbohydrates = ParseDouble("углеводы");

            return (new Food(foodName, callories, fats, proteins, carbohydrates), weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения в формате (дд.мм.гггг)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                }

            }

            return birthDate;
        }

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
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}
