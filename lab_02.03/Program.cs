using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._03._23_LAB
{
    class Program
    {
        #region Зад 1
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            return true;
        }
        public static bool FibNum(int n)
        {
            return FSqrt(5 * n * n + 4) || FSqrt(5 * n * n - 4);
        }
        public static bool FSqrt(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }
        #endregion
        static void Main(string[] args)
        {
            #region 1
            string primeFilePath = "../../prost.txt";
            string fibonacciFilePath = "../../fibonacci.txt";
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                bool isPrime = IsPrime(i);
                if (isPrime)
                    using (StreamWriter writer = new StreamWriter(primeFilePath, true)) { writer.Write($"{i}, "); }
                using (StreamWriter writer = new StreamWriter(fibonacciFilePath, true))
                {
                    if (FibNum(i))
                        writer.Write($"{i}, ");
                }
            }
            #endregion

            #region Зад 2
            string filePath = "../../Zad_2.txt";
            Console.WriteLine("Введите слово которое ищите: ");
            string search = Console.ReadLine();
            Console.WriteLine("Введите слово для замены: ");
            string replace = Console.ReadLine();
            string fileContent = File.ReadAllText(filePath);
            string newContent = fileContent.Replace(search, replace);
            File.WriteAllText(filePath, newContent);
            #endregion

            #region Зад 3
            string filePathMod = "../../Zad3_except.txt";
            string filePathUser = "../../Zad_3.txt";
            string[] words = File.ReadAllLines(filePathMod);
            string text = File.ReadAllText(filePathUser);
            foreach (string word in words)
                text = text.Replace(word, new string('*', word.Length));
            File.WriteAllText(filePathUser, text);
            #endregion
        }
    }
}