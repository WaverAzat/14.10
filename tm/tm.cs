using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace tm
{
    internal class Program
    {
        static int[] Zadanie31(Dictionary<string, int[]> t)
        {
            string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int[] tt = new int[12];
            for (int i = 0; i < month.Length; i++)
            {
                tt[i] = t[month[i]].Sum() / 30;
            }

            foreach (int i in tt)
            {
                Console.Write(" " + i);
            }
            return tt;
        }
        static void Zadanie1(char[] str, out int n1, out int n2)
        {
            n1 = 0;
            n2 = 0;
            char[] c = { 'o', 'i', 'a', 'e', 'u', 'y' };
            foreach (char c2 in str)
            {
                if (c.Contains(c2))
                    n1++;
                else
                    n2++;
            }
            Console.WriteLine("гласные: " + n1);
            Console.WriteLine("согласные: " + n2);
        }
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить"); //throw.То есть с помощью этого оператора мы сами можем создать исключение и вызвать его в процессе выполнения.
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        static LinkedList<LinkedList<int>> Multiply(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
        {
            LinkedList<LinkedList<int>> r = new LinkedList<LinkedList<int>>();
            return r;
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Print1(LinkedList<LinkedList<int>> Mtrx)
        {
            foreach (LinkedList<int> subline in Mtrx)
            {
                Console.WriteLine(string.Join(" ", subline.ToArray()));
            }
        }
        static int[] Zadanie3(int[,] t)
        {
            int[] sr = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int cnt = 0;
                for (int j = 0; j < 30; j++)
                {
                    cnt += t[i, j];
                }
                sr[i] = cnt / 30;
            }
            sr = sr.OrderBy(x => x).ToArray();
            return sr;
        }
        static void Main(string[] args)
        {
            char[] smth = File.ReadAllText("/Users/azatsaifullin/Projects/14.10/tm/azatproga14.10.rtf").ToArray<char>();
            Zadanie1(smth, out _, out _);


            Console.WriteLine("Задание 2.Умножение матриц.");
            Console.WriteLine("Введите размерность первой матрицы: ");
            int[,] A = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Введите размерность второй матрицы: ");
            int[,] B = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write("B[{0},{1}] = ", i, j);
                    B[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("\nМатрица A:");
            Print(A);
            Console.WriteLine("\nМатрица B:");
            Print(B);
            Console.WriteLine("\nМатрица C = A * B:");
            int[,] C = Multiplication(A, B);
            Print(C);



            Console.WriteLine("Задание 3.Средняя температура");
            int[,] temp = new int[12, 30];
            Random r = new Random();
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = r.Next(-10, 30);
                }
            }
            Console.WriteLine(string.Join(",", Zadanie3(temp)));

            Console.WriteLine("Задание домашка 1.1.Файл букв.");
            List<char[]> syms = new List<char[]>();
            syms.Add(smth);
            Zadanie1(syms[0], out _, out _);
            Console.WriteLine("Задание домашка 3.1.Ср температура");
            var rng = new Random();
            Dictionary<string, int[]> Temp = new Dictionary<string, int[]>
            {
                ["Jan"] = Enumerable.Range(-10, 30).OrderBy(a => rng.Next()).ToArray(),
                ["Feb"] = Enumerable.Range(-10, 30).OrderBy(b => rng.Next()).ToArray(),
                ["Mar"] = Enumerable.Range(-10, 30).OrderBy(c => rng.Next()).ToArray(),
                ["Apr"] = Enumerable.Range(-10, 30).OrderBy(d => rng.Next()).ToArray(),
                ["May"] = Enumerable.Range(-10, 30).OrderBy(e => rng.Next()).ToArray(),
                ["Jun"] = Enumerable.Range(-10, 30).OrderBy(f => rng.Next()).ToArray(),
                ["Jul"] = Enumerable.Range(-10, 30).OrderBy(g => rng.Next()).ToArray(),
                ["Aug"] = Enumerable.Range(-10, 30).OrderBy(h => rng.Next()).ToArray(),
                ["Sep"] = Enumerable.Range(-10, 30).OrderBy(i => rng.Next()).ToArray(),
                ["Oct"] = Enumerable.Range(-10, 30).OrderBy(j => rng.Next()).ToArray(),
                ["Nov"] = Enumerable.Range(-10, 30).OrderBy(k => rng.Next()).ToArray(),
                ["Dec"] = Enumerable.Range(-10, 30).OrderBy(l => rng.Next()).ToArray()
            };
            Console.WriteLine(string.Join(",", Zadanie31(Temp)));
            Console.ReadKey();
        }
    }
}