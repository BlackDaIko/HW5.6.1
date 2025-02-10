using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет, удели мне пару минут, заполни чуть-чуть информаци) ");
            Console.WriteLine($"{PrintInfo()}");

        }

        static (string Name, string Fam, int Age, bool HavPets, int KolvPets, string[] NamePets, string[] FavColor) EnterUser()
        {
            (string Name, string Fam, int Age, bool HavPets, int KolvPets, string[] NamePets, string[] FavColor) User;

            Console.WriteLine("Введите имя:");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            User.Fam = Console.ReadLine();

            Console.WriteLine("Введите возраст:");

            string age; int intage;
            do
            {
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));
            User.Age = intage;


            Console.WriteLine("У вас есть домашние животные? (Yes/No):");
            string result = Console.ReadLine()?.ToLower();
            User.HavPets = result == "yes";

            string kolvopets = null;
            int intpets = 0;
            if (User.HavPets)
            {
                Console.Write("Введимте количество Ваших питомцев: ");

                do
                {
                    kolvopets = Console.ReadLine();
                } while (CheckNum(kolvopets, out intpets));
                User.KolvPets = intpets;

                User.NamePets = new string[User.KolvPets];
                Console.WriteLine("Введите имена домашних животных:");
                for (int i = 0; i < User.KolvPets; i++)
                {
                    Console.Write($"Имя питомца {i + 1}: ");
                    User.NamePets[i] = Console.ReadLine();
                }
            }
            else
            {
                User.KolvPets = 0;
                User.NamePets = null;
            }

            Console.WriteLine("У вас есть любимые цвета? (Yes/No):");
            string resultcolor = Console.ReadLine()?.ToLower();
            string kolvocolor = null;
            int intcolor = 0;
            if (resultcolor == "yes")
            {
                Console.Write("Введимте количество Ваших любимых цветов: ");
                do
                {
                    kolvocolor = Console.ReadLine();
                } while (CheckNum(kolvocolor, out intcolor));

                User.FavColor = new string[intcolor];
                Console.WriteLine("Введите любимые цвета:");
                for (int i = 0; i < intcolor; i++)
                {
                    Console.Write($"Цвет {i + 1}: ");
                    User.FavColor[i] = Console.ReadLine();
                }
            }
            else
            {
                kolvocolor = null;
                User.FavColor = null;
            }


            return User;
        }


        static bool CheckNum(string num, out int correct)
        {
            if (int.TryParse(num, out int intnum))
            {
                if (intnum > 0)
                {

                    correct = intnum;
                    return false;
                }
                else
                {
                    Console.WriteLine("Введите правильное значение!");
                }
            }
            {
                correct = 0;
                return true;
            }

        }

        public static string PrintInfo()
        {
            return $"Ваша информация: {string.Join(", ", EnterUser())}";
        }


    }
}
