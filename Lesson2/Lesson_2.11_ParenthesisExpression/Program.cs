﻿using System;

namespace ParenthesisExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            int parenthesisNestingDegree = 0;
            int maximumParenthesisNestingDegree = 0;
            int normalNestingLevel = 0;
            bool isWrongParenthesisExpression = false;
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

                if (parenthesisNestingDegree < normalNestingLevel)
                {
                    isWrongParenthesisExpression = true;
                    break;
                }
            }

            if (parenthesisNestingDegree > normalNestingLevel)
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
                Console.WriteLine($"Максимальная глубина вложенности {maximumParenthesisNestingDegree}");
            }

            Console.WriteLine("Нажмите ENTER для завершения программы.");
            Console.ReadLine();
        }
    }
}
