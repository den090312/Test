using System;
using System.Linq;

namespace Task1_2_SortArrayFindValue
{
    class Program
    {
        static void Main(string[] args)
        {
            //определение размерности массива
            Console.WriteLine("Введите количество чисел в массиве");

            int arrayLenth = GetArrayLenth(Console.ReadLine());
            int[] arrayNumbers = new int[arrayLenth];

            //заполнение массива с клавиатуры
            Console.WriteLine("Введите числа в столбик");

            for (int i = 0; i <= arrayLenth - 1; i++)
            { if (IsNumber(Console.ReadLine(), out int userNumber)) { arrayNumbers[i] = userNumber; } }
            Console.WriteLine();

            //сортировка и вывод на экран элементов массива
            Console.WriteLine("Отсортированный массив:");

            WriteArray(SortArray(arrayNumbers));

            Console.WriteLine("Введите искомое число");

            //проверка на числовой тип
            if (IsNumber(Console.ReadLine(), out int soughtValue))
            {
                //поиск заданного числа в массиве 
                if (IsInArray(soughtValue, arrayNumbers))
                { Console.WriteLine("Число найдено в массиве"); }
                else
                { Console.WriteLine("Число НЕ найдено в массиве"); }
            }
        }

        static int GetArrayLenth(string userString)
        {
            if (IsNumber(userString, out int arrayLenth)) { return arrayLenth; }
            return 0;
        }

        static void WriteArray(int[] arr)
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            { Console.WriteLine(arr[i]); }
        }

        static int[] SortArray(int[] arr)
        {
            //пузырьковая сортировка
            int buffer;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        buffer = arr[i];
                        arr[i] = arr[j];
                        arr[j] = buffer;
                    }
                }
            }

            //функция Sort
            //Array.Sort(arr); 

            //сортировка с помощью Linq 
            //arr = arr.OrderBy(x => x).ToArray();

            //сортировка анонимным методом
            //Array.Sort(arr, (x, y) => x - y);

            //использование CompareTo() 
            //Array.Sort<int>(arr, new Comparison<int>((x, y) => x.CompareTo(y)));

            return arr;
        }

        static bool IsInArray(int soughtValue, int[] arr)
        {
            bool isInArray = false;

            //поиск значения в массиве, используя цикл
            foreach (int el in arr) { if (el == soughtValue) return true; }

            //поиск с помощью функции Exists()
            //isInArray = Array.Exists(arr, el => el == soughtValue);

            //поиск с помощью функции Contains() 
            //if (arr.Contains(soughtValue)) { return true; }

            return isInArray;
        }

        static bool IsNumber(string userString, out int soughtValue)
        {
            bool isNumber = int.TryParse(userString, out soughtValue);
            do
            {
                if (!isNumber)
                {
                    Console.WriteLine("Введите число!");
                    isNumber = int.TryParse(Console.ReadLine(), out soughtValue);
                }
            }
            while (isNumber == false);

            return isNumber;
        }
    }
}
