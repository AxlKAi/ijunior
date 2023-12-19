using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string city;
            int age;

            Console.WriteLine("День добрый, мессир! Разрешите поинтересоваться...");
            Console.Write("Как к Вам обращаться ? Ваше имя? :");
            name = Console.ReadLine();

            Console.Write($"В каком городе Вы родились {name} ? :"); ;
            city = Console.ReadLine();                 
            Console.WriteLine($"Замечательный город {city} !");

            Console.Write("Сколько Вам лет ? :");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{name}!!! {age} - это замечательный возраст, а {city} велеколепное место, что бы стать Геймдевом ! ");
        }
    }
}
