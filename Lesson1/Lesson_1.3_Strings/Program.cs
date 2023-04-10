using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Вы задаете вопросы пользователю, по типу "как вас зовут", 
            "какой ваш знак зодиака" и тд, после чего, по данным, 
            которые он ввел, формируете небольшой текст о пользователе. 
            */

            string name;
            string city;
            int age;

            Console.WriteLine("День добрый, мессир! Разрешите поинтересоваться...");
            Console.Write("Как к Вам обращаться ? Ваше имя? :");
            name = Console.ReadLine();

            Console.Write($"В каком городе Вы родились {name} ? :"); ;
            city = Console.ReadLine();            
            Console.WriteLine($"Замечательный город {city} !");

            Console.WriteLine("Сколько Вам лет ? :");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{age} - это замечательный возраст что бы стать Геймдевом !");
        }
    }
}
