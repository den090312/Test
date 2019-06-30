using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5_CorrectBracketSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод строки с клавиатуры
            Console.WriteLine("Введите строку. Максимальная длина строки - 254 символа");

            if (IsCorrectBracketSequence(Console.ReadLine().ToCharArray()))
            { Console.WriteLine("Правильная скобочная последовательность"); }
            else
            { Console.WriteLine("Неправильная скобочная последовательность"); }
        }

        static bool IsCorrectBracketSequence(char[] charArray)
        {
            var stackOpenBrackets = new Stack<char>();
            foreach (char el in charArray)
            {
                if (IsBracket(el))
                {
                    if (IsOpenBracket(el)) { stackOpenBrackets.Push(el); }
                    else
                    {
                        char openBracket = GetOpenBracket(el);
                        if (!stackOpenBrackets.TryPeek(out var openBracketInStack)) { return false; }
                        else { if (openBracket != openBracketInStack) { return false; } }
                        if (stackOpenBrackets.Peek() == openBracket) { stackOpenBrackets.Pop(); }
                    }
                }
            }
            if (stackOpenBrackets.Count == 0) { return true; } else { return false; }
        }

        static bool IsBracket(char ch)
        {
            bool isBracket = false;

            char[] bracketsArray = { '(', ')', '[', ']', '{', '}' };
            if (bracketsArray.Contains(ch)) { return true; }

            return isBracket;
        }

        static char GetOpenBracket(char closeBracket)
        {
            char openBracket = '\0';

            if (closeBracket == ')') { return '('; }
            if (closeBracket == ']') { return '['; }
            if (closeBracket == '}') { return '{'; }

            return openBracket;
        }

        static bool IsOpenBracket(char ch)
        {
            bool isOpenBracket = false;

            char[] openBracketsArray = { '(', '[', '{' };
            if (openBracketsArray.Contains(ch)) { return true; }

            return isOpenBracket;
        }
    }
}
