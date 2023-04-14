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
            string parenthesisExpression;
            bool isWrongParenthesisExpression = false;

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

                if (parenthesisNestingDegree < 0)
                {
                    isWrongParenthesisExpression = true;
                    break;
                }
            }

            if (parenthesisNestingDegree > 0)
            {
                isWrongParenthesisExpression = true;
            }

            if (isWrongParenthesisExpression)
            {
                Console.WriteLine("Ошибочное выражение");
            }
            else
            {
                Console.WriteLine("Правильное выражение");
            }
            Console.WriteLine("Нажмите ENTER для завершения программы.");
            Console.ReadLine();
        }
    }
}
