using System;

namespace SwapVariable
{
    class Program
    {
        static void Main(string[] args)
        {
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
