using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesisExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            int parenthesisNestingDegree = 0;
            int maximumParenthesisNestingDegree = 0;
            int normalNestingLevel = 0;
            string parenthesisExpression;

            Console.WriteLine("Программа определит, является ли строка корректным скобочным выражением.");
            Console.WriteLine("Все символы кроме скобок отбрасываются.");
            Console.Write("Введите строку из символов \'(\' и \')\':");
            parenthesisExpression = Console.ReadLine();

            foreach (var parenthesis in parenthesisExpression)
            {
                if(parenthesis == '(')
                {
                    parenthesisNestingDegree++;
                }
                else if(parenthesis == ')')
                {
                    parenthesisNestingDegree--;
                }

                if(maximumParenthesisNestingDegree< parenthesisNestingDegree)
                {
                    maximumParenthesisNestingDegree = parenthesisNestingDegree;
                }
            }

            if (parenthesisNestingDegree == normalNestingLevel)
            {
                Console.WriteLine("Правильное выражение");
                Console.WriteLine($"Максимальная глубина вложенности {maximumParenthesisNestingDegree}");
            }
            else
            {
                Console.WriteLine("Ошибочное выражение");
            }

            Console.WriteLine("Нажмите ENTER для завершения программы.");
            Console.ReadLine();
        }
    }
}
