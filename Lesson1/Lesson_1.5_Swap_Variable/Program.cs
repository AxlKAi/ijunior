using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Даны две переменные. Поменять местами значения двух переменных. 
            Вывести на экран значения переменных до перестановки и после. 
            */
            string name = "Пестропалов";
            string surname = "Эдуард";
            string cashe;

            Console.WriteLine($"name={name}; surname={surname};");
            Console.WriteLine("Меняем местами");
            cashe = name;
            name = surname;
            surname = cashe;
            Console.WriteLine($"Теперь name={name}; surname={surname};");
        }
    }
}
