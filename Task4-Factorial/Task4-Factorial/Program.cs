using System;
using System.Numerics;

namespace Task4_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxValue = 1000;
            Console.WriteLine("Введите n от нуля до " + maxValue.ToString());

            string userNumber = Console.ReadLine();
            if (IsNumber(userNumber, maxValue, out int n))
            {
                //выводим факториал числа
                Console.WriteLine("Факториал " + userNumber + " равен " + Factorial(n).ToString());
            }
        }

        static BigInteger Factorial(int n)
        {
            /*if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }*/

            //сокращенная запись тернарным оператором
            return n == 0 ? 1 : n * Factorial(n - 1);
        }

        static bool IsNumber(string userString, int maxValue, out int n)
        {
            //проверка на числовой тип вводимого значения
            bool isNumber;
            do
            {
                isNumber = int.TryParse(userString, out n);
                if (!isNumber)
                {
                    Console.WriteLine("Введите число!");
                    IsNumber(Console.ReadLine(), maxValue, out n);
                }
                else
                {
                    //проверка на отрицательное и максимальное число
                    if (n < 0 || n > maxValue)
                    {
                        while (n < 0 || n > maxValue)
                        {
                            Console.WriteLine("Введите число от нуля до " + maxValue.ToString());
                            IsNumber(Console.ReadLine(), maxValue, out n);
                        }
                    }
                }
            }
            while (isNumber == false);

            return isNumber;
        }
    }
}
