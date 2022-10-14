using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace hm
{
    struct Resident
    {
        public string Name;
        public int Id;
        public string Problem;
        public byte Temp;
        public byte Intellegence;

        public Resident(string Name, int Id, string Problem, byte Temp, byte Intellegence)
        {
            this.Name = Name;
            this.Id = Id;
            this.Problem = Problem;
            this.Temp = Temp;
            this.Intellegence = Intellegence;
        }
    }
    internal class Student
    {
        public string secondName { get; set; }//В блоке get выполняются действия по получению значения свойства.
        public string firstName { get; set; }//В блоке set устанавливается значение свойства.
        public int birthYear { get; set; }
        public string exam { get; set; }
        public int points { get; set; }
    }
    internal class Program
    {
        static void Zadanie1()
        {
            Console.WriteLine("Задание 1.Сортировка студентов.");
            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                [0] = new Student { secondName = "Зиагншин", firstName = "Халиль", birthYear = 2003, exam = "inf", points = 245 },
                [1] = new Student { secondName = "Романов", firstName = "Илья", birthYear = 2004, exam = "inf", points = 253 },
                [2] = new Student { secondName = "Романов", firstName = "Илья", birthYear = 2003, exam = "inf", points = 253 },
                [3] = new Student { secondName = "Ахметов", firstName = "Ильдар", birthYear = 2003, exam = "inf", points = 249 },
                [4] = new Student { secondName = "Братухин", firstName = "Илья", birthYear = 2003, exam = "phis", points = 254 },
                [5] = new Student { secondName = "Калашников", firstName = "Андрей", birthYear = 2005, exam = "inf", points = 251 },
                [6] = new Student { secondName = "Залялетдинов", firstName = "Азат", birthYear = 2004, exam = "inf", points = 245 },
                [7] = new Student { secondName = "Ахметзянов", firstName = "Камиль", birthYear = 2004, exam = "eng", points = 241 },
                [8] = new Student { secondName = "Мошкина", firstName = "Мария", birthYear = 2004, exam = "inf", points = 249 },
                [9] = new Student { secondName = "Хузина", firstName = "Карина", birthYear = 2003, exam = "eng", points = 252 }
            };
            Console.WriteLine("Напишите действие: Новый студент / Удалить / Сортировать");
            string s = Console.ReadLine();
            switch (s)
            {
                case "Новый студент":
                    Console.WriteLine("Введите фамилию студента");
                    string sn = Console.ReadLine();
                    Console.WriteLine("Введите имя студента");
                    string fn = Console.ReadLine();
                    Console.WriteLine("Введите год рождения");
                    int yr = int.Parse(Console.ReadLine());
                    Console.WriteLine(" Введите экзамен");
                    string ex = Console.ReadLine();
                    Console.WriteLine("Введите баллы за экзамен");
                    int pnts = int.Parse(Console.ReadLine());
                    students.Add(10, new Student { secondName = sn, firstName = fn, birthYear = yr, exam = ex, points = pnts });
                    break;
                case "Удалить":
                    Console.WriteLine("Введите имя (Ф.И)");
                    string[] name = Console.ReadLine().Split(' ');
                    var item = students.First(x => x.Value.secondName == name[0]);
                    students.Remove(item.Key);//remove удаляет
                    foreach (var p in students)
                    {
                        Console.WriteLine($" Имя: {p.Value.secondName} {p.Value.firstName}, Год рождения: {p.Value.birthYear}, Экзамен: {p.Value.exam}, Баллы: {p.Value.points} ");
                    }
                    break;
                case "Сортировать":
                    Console.WriteLine("Отсортированный список: \n");
                    var sortedStud = students.OrderBy(x => x.Value.points);//По умолчанию оператор orderby и метод OrderBy производят сортировку по возрастанию.
                    foreach (var p in sortedStud)
                    {
                        Console.WriteLine($" Имя: {p.Value.secondName} {p.Value.firstName}, Год рождения: {p.Value.birthYear}, Экзамен: {p.Value.exam}, Баллы: {p.Value.points}  ");
                    }
                    break;
            }
        }
        static string Zadanie2(List<string[]> t)
        {
            string ph1 = "Drinks All Round! Free Beers on Bjorg!";
            string ph2 = "Ой, Бьорг - пончик! Ни для кого пива!";
            int c1 = 0;
            for (int i = 0; i < t[0].Length; i++)
            {
                if (t[0][i] == "5")
                    c1+=1;
            }
            int c2 = 0;
            for (int i = 0; i < t[1].Length; i++)
            {
                if (t[1][i] == "5")
                    c2+=1;
            }


            return c1 == c2 ? ph1 : ph2;
        }
        public static void Zadanie3()
        {
            Resident resident1 = new Resident("Илья", 312204, "Проблема с оплатой", 3, 1);
            Resident resident2 = new Resident("Азат", 950076, "Другое", 10, 0);
            Resident resident3 = new Resident("Илназ", 694200, "Проблема с отоплением", 4, 1);
            Resident resident4 = new Resident("Халиль", 987700, "Проблема с оплатой", 6, 0);
            Stack<Resident> zhek = new Stack<Resident>();
            LinkedList<string> window1 = new LinkedList<string>();
            LinkedList<string> window2 = new LinkedList<string>();
            LinkedList<string> window3 = new LinkedList<string>();
            zhek.Push(resident1);//Push: добавляет элемент в стек в верхушку стека
            zhek.Push(resident2);
            zhek.Push(resident3);
            zhek.Push(resident4);
            int i = zhek.Count;//кол-во
            while (i > 0)
            {
                var elem1 = zhek.Pop();//Pop: извлекает и возвращает первый элемент из стека
                if (elem1.Problem == "Проблема с оплатой")
                {
                    string name = elem1.Name;
                    byte scandal = elem1.Temp;
                    byte mind = elem1.Intellegence;
                    Console.WriteLine(name + " ,Вставайте в первое окно");
                    if (mind == 1)
                    {
                        if (scandal < 5)
                        {
                            window2.AddLast(name); // addlast вставляет новый узел в конец списка
                        }
                        else
                        {
                            if (window2.Count > 0)
                            {
                                Console.WriteLine(name + $", перед вами {window2.Count} людей. Сколько хотите обогнать?");
                                byte obgon = Convert.ToByte(Console.ReadLine());
                                if (obgon < window2.Count)
                                {
                                    window2.AddBefore(window2.Last, name);
                                }
                                else
                                {
                                    window2.AddLast(name);
                                }

                            }
                        }
                    }
                    else
                    {
                        Random r = new Random();
                        int rndWin = r.Next(0, 2);
                        if (rndWin == 0)
                        {
                            if (scandal < 5)
                            {
                                window1.AddLast(name);
                            }
                            else
                            {
                                if (window2.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window1.Count} человек. Сколько хотите обогнать? ");
                                    byte obgon = Convert.ToByte(Console.ReadLine());
                                    if (obgon < window1.Count)
                                    {
                                        window1.AddBefore(window1.Last, name);
                                    }
                                    else
                                    {
                                        window1.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window1.AddLast(name);
                                }
                            }
                        }
                        else
                        {
                            if (scandal < 5)
                            {
                                window3.AddLast(name);
                            }
                            else
                            {
                                if (window3.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window3.Count} человек. Сколько человек вы хотите обогнать? ");
                                    byte temp = Convert.ToByte(Console.ReadLine());
                                    if (temp < window3.Count)
                                    {
                                        window1.AddBefore(window3.Last, name);
                                    }
                                    else
                                    {
                                        window3.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window3.AddLast(name);
                                }
                            }
                        }

                    }
                }
                else if (elem1.Problem == "Проблема с отоплением")
                {
                    string name = elem1.Name;
                    byte scandal = elem1.Temp;
                    byte mind = elem1.Intellegence;
                    Console.WriteLine(name + " ,Вставайте в первое окно");
                    if (mind == 1)
                    {
                        if (scandal < 5)
                        {
                            window2.AddLast(name);
                        }
                        else
                        {
                            if (window2.Count > 0)
                            {
                                Console.WriteLine(name + $", перед вами {window2.Count} людей. Сколько хотите обогнать?");
                                byte obgon = Convert.ToByte(Console.ReadLine());
                                if (obgon < window2.Count)
                                {
                                    window2.AddBefore(window2.Last, name);
                                }
                                else
                                {
                                    window2.AddLast(name);
                                }

                            }
                        }
                    }
                    else
                    {
                        Random r = new Random();
                        int rndWin = r.Next(0, 2);
                        if (rndWin == 0)
                        {
                            if (scandal < 5)
                            {
                                window1.AddLast(name);
                            }
                            else
                            {
                                if (window2.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window1.Count} человек. Сколько хотите обогнать? ");
                                    byte obgon = Convert.ToByte(Console.ReadLine());
                                    if (obgon < window1.Count)
                                    {
                                        window1.AddBefore(window1.Last, name);
                                    }
                                    else
                                    {
                                        window1.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window1.AddLast(name);
                                }
                            }
                        }
                        else
                        {
                            if (scandal < 5)
                            {
                                window3.AddLast(name);
                            }
                            else
                            {
                                if (window3.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window3.Count} человек. Сколько человек вы хотите обогнать? ");
                                    byte temp = Convert.ToByte(Console.ReadLine());
                                    if (temp < window3.Count)
                                    {
                                        window1.AddBefore(window3.Last, name);
                                    }
                                    else
                                    {
                                        window3.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window3.AddLast(name);
                                }
                            }
                        }

                    }
                }
                else
                {
                    string name = elem1.Name;
                    byte scandal = elem1.Temp;
                    byte mind = elem1.Intellegence;
                    Console.WriteLine(name + " ,Вставайте в первое окно");
                    if (mind == 1)
                    {
                        if (scandal < 5)
                        {
                            window2.AddLast(name);
                        }
                        else
                        {
                            if (window2.Count > 0)
                            {
                                Console.WriteLine(name + $", перед вами {window2.Count} людей. Сколько хотите обогнать?");
                                byte obgon = Convert.ToByte(Console.ReadLine());
                                if (obgon < window2.Count)
                                {
                                    window2.AddBefore(window2.Last, name);
                                }
                                else
                                {
                                    window2.AddLast(name);
                                }

                            }
                        }
                    }
                    else
                    {
                        Random r = new Random();// объявление переменной для генерации чисел
                        int rndWin = r.Next(0, 2);
                        if (rndWin == 0)
                        {
                            if (scandal < 5)
                            {
                                window1.AddLast(name);
                            }
                            else
                            {
                                if (window2.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window1.Count} человек. Сколько хотите обогнать? ");
                                    byte obgon = Convert.ToByte(Console.ReadLine());
                                    if (obgon < window1.Count)
                                    {
                                        window1.AddBefore(window1.Last, name);
                                    }
                                    else
                                    {
                                        window1.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window1.AddLast(name);
                                }
                            }
                        }
                        else
                        {
                            if (scandal < 5)
                            {
                                window3.AddLast(name);
                            }
                            else
                            {
                                if (window3.Count > 0)
                                {
                                    Console.Write(name + $", перед вами {window3.Count} человек. Сколько человек вы хотите обогнать? ");
                                    byte temp = Convert.ToByte(Console.ReadLine());
                                    if (temp < window3.Count)
                                    {
                                        window1.AddBefore(window3.Last, name);
                                    }
                                    else
                                    {
                                        window3.AddFirst(name);
                                    }
                                }
                                else
                                {
                                    window3.AddLast(name);
                                }
                            }
                        }

                    }
                }
                i--;
            }
            Console.WriteLine("Очередь в первое окно:");
            foreach (string name in window1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Очередь во второе окно:");
            foreach (string name in window2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Очередь в третье окно окно:");
            foreach (string name in window3)
            {
                Console.WriteLine(name);
            }
        }
        static void Main(string[] args)
        {
            Zadanie1();

            Console.WriteLine("Задание 2.Пиво викингов");
            List<string[]> lst = new List<string[]>();
            Console.WriteLine("Введите массив чисел первого клана (0..9)");
            string[] arr1 = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите массив чисел второго клана (0..9)");
            string[] arr2 = Console.ReadLine().Split(' ');
            lst.Add(arr1);
            lst.Add(arr2);
            Console.WriteLine(Zadanie2(lst));

            Console.WriteLine("Задание 3.Жэк");
            Zadanie3();

            Console.WriteLine("Задание 4.Обход графа");
            clsGraph graph = new clsGraph(7);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 6);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 2);
            graph.AddEdge(4, 3);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 4);
            graph.AddEdge(6, 1);
            graph.PrintAdjacecnyMatrix();

            Console.WriteLine("BFS стартует с 0:");
            graph.BFS(0);
            Console.WriteLine("DFS стартует с 0:");
            graph.DFS(0);


            Console.ReadKey();

        }
        class clsGraph
        {
            private int Vertices; // количество узлов
            private List<Int32>[] adj; // смежность узлов

            public clsGraph(int v) // вывод матрицы смежности
            {
                Vertices = v;
                adj = new List<Int32>[v];
                for (int i = 0; i < v; i++)
                {
                    adj[i] = new List<Int32>();
                }

            }


            public void AddEdge(int v, int w) // добавляем грань от узла до узла
            {
                adj[v].Add(w);
            }


            public void BFS(int s)
            {
                bool[] visited = new bool[Vertices]; // флаг посещения


                Queue<int> queue = new Queue<int>(); //
                visited[s] = true;
                queue.Enqueue(s);


                while (queue.Count != 0)
                {

                    s = queue.Dequeue();
                    Console.WriteLine("next->" + s);


                    foreach (Int32 next in adj[s])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }

                }
            }


            public void DFS(int s)
            {
                bool[] visited = new bool[Vertices]; //проверка на посещение узла


                Stack<int> stack = new Stack<int>();
                visited[s] = true;
                stack.Push(s);

                while (stack.Count != 0)
                {
                    s = stack.Pop();
                    Console.WriteLine("next->" + s);
                    foreach (int i in adj[s])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                    }
                }
            }

            public void PrintAdjacecnyMatrix()
            {
                for (int i = 0; i < Vertices; i++)
                {
                    Console.Write(i + ":[");
                    string s = "";
                    foreach (var k in adj[i])
                    {
                        s = s + (k + ",");
                    }
                    s = s.Substring(0, s.Length - 1);
                    s = s + "]";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
        }




    }
}
