using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task3_WriteSingleWordsFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод строки с клавиатуры
            Console.WriteLine("Введите строку. Максимальная длина строки - 254 символа");
            StringBuilder sb = new StringBuilder(Console.ReadLine());

            //удаление знаков препинания функцией Replace()
            sb = RemoveAllPunctuationMarks(sb);

            //удаление знаков препинания с помощью регулярного выражения (работает медленно)
            //string sb = Regex.Replace(defaultString, "[-.?!)(,:\"«»<>]", "");

            Console.WriteLine();
            Console.WriteLine("Слова, которые встречаются только один раз:");

            //вывод слов, которые встречаются только один раз, используя Linq
            /*string[] wordsArray = sb.ToString().Split(" ");
            foreach (string el in wordsArray)
            { if (!string.IsNullOrEmpty(el) && wordsArray.Count(x => x == el) == 1) { Console.WriteLine(el); } }*/

            //вывод слов, которые встречаются только один раз, без Linq
            WriteSingleWords(GetSingleWords(sb.ToString().Split(' ')));
        }

        static StringBuilder RemoveAllPunctuationMarks(StringBuilder sb)
        {
            string[] punctuationMarks = { ".", ",", ":", ";", "!", "?", "'", "-", "—", "{", "}", "[", "]", "(", ")", "«", "»", "<", ">", "\"" };
            for (int i = 0; i <= punctuationMarks.Length - 1; i++)
            {
                sb.Replace(punctuationMarks[i], "");
            }

            return sb;
        }

        static List<string> GetSingleWords(string[] wordsArray)
        {
            List<string> resultList = new List<string>();
            for (int i = 0; i <= wordsArray.Length - 1; i++)
            {
                if (wordsArray[i] == string.Empty || resultList.Contains(wordsArray[i]))
                {
                    continue;
                }
                else
                {
                    int counter = 0;
                    for (int j = 0; j <= wordsArray.Length - 1; j++)
                    {
                        if (wordsArray[i] == wordsArray[j])
                        {
                            if (counter > 1) { break; } else { counter++; }
                        }
                    }
                    if (counter == 1) resultList.Add(wordsArray[i]);
                }
            }
            return resultList;
        }

        static void WriteSingleWords(List<string> resultList)
        {
            foreach (string el in resultList)
            {
                Console.WriteLine(el);
            }
        }
    }
}
