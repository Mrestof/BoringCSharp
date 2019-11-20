using System;
using System.Threading;
using System.Collections.Generic;

namespace MRSTF
{
    class Trash
    {
        public static bool IsMagickSquare(int[,] square)
        {
            int length = square.GetLength(0);
            int[] DiagonalSum = new int[2];
            int[] ColSum = new int[length];
            int[] RowSum = new int[length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j) DiagonalSum[0] += square[i, j];
                    if (i + j == length - 1) DiagonalSum[1] += square[i, j];
                    RowSum[i] += square[i, j];
                    ColSum[j] += square[i, j];
                }
            }

            int ExampleNum = DiagonalSum[0];

            foreach (int num in DiagonalSum)
                if (num != ExampleNum) return false;

            foreach (int num in ColSum)
                if (num != ExampleNum) return false;

            foreach (int num in RowSum)
                if (num != ExampleNum) return false;

            return true;
        }

        public static void DrawDiagonals()
        {
            ConsoleColor
                bg = Console.BackgroundColor,
                fg = Console.ForegroundColor;

            int[,] matrix = new int[7, 7];

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == j && i + j == 6)
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    else if (i + j == 6)
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    else if (i != j)
                        Console.BackgroundColor = ConsoleColor.White;
                    else if (i == j)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;

                    Console.Write("  ");
                }

                Console.Write('\n');
            }

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
        }

        public static void SwapTwoNums(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        public static int[] SortByFirstNum(int[] arr)
        {
            int pos_min, temp, l, r;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    l = Convert.ToString(arr[j])[0];
                    r = Convert.ToString(arr[pos_min])[0];

                    if (l < r) pos_min = j;
                }

                temp = arr[i];
                arr[i] = arr[pos_min];
                arr[pos_min] = temp;
            }

            return arr;
        }

        public static int[] SortByLastNum(int[] arr)
        {
            int pos_min, temp, l, r;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    l = arr[j] % 10;
                    r = arr[pos_min] % 10;

                    if (l < r) pos_min = j;
                }

                temp = arr[i];
                arr[i] = arr[pos_min];
                arr[pos_min] = temp;
            }

            return arr;
        }

        public static int[] RandomIntArrayGeneratorNoRepeat(int len)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < len; i++) list.Add(i);

            int[] arr = new int[len];
            Random rand = new Random();

            for (int i = 0; i < len; i++)
            {
                int randint = rand.Next(list.Count);
                arr[i] = list[randint];
                list.Remove(arr[i]);
            }

            Console.Write("Random array: " + Useful.IntArrayToString(arr));

            return arr;
        }

        public static int[] RandomIntArrayGenerator(int len = 10,
                                                    int maxNum = 50,
                                                    int minNum = 0)
        {
            int[] arr = new int[len];
            Random rand = new Random();

            for (int i = 0; i < len; i++)
            {
                int randint = rand.Next(minNum, maxNum);
                arr[i] = randint;
            }

            return arr;
        }

        public static void MiddleReverse()
        {
            int temp, r;
            int[] arr = { 43, 76, 12, 65, 4, 7, 5, 3 };

            foreach (var i in arr) Console.Write("{0} ", i);

            for (int i = 0; i < arr.Length / 2 / 2; i++)
            {
                temp = arr[i];
                arr[i] = arr[arr.Length / 2 - i - 1];
                arr[arr.Length / 2 - i - 1] = temp;
            }

            Console.Write("\n");
            foreach (var i in arr) Console.Write("{0} ", i);

            for (int i = arr.Length / 2; i < arr.Length * .75; i++)
            {
                temp = arr[i];
                r = i - arr.Length / 2;
                arr[i] = arr[arr.Length - r - 1];
                arr[arr.Length - r - 1] = temp;
            }

            Console.Write("\n");
            foreach (var i in arr) Console.Write("{0} ", i);
        }

        public static int[] ReverseIntArray(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }

            return arr;
        }

        public static void QuadroString()
        {
            Console.Write("Enter ur name: ");
            string name = Console.ReadLine();
            int len = name.Length;

            Console.Clear();

            for (int i = 0; i < len; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(name[i]);
                Console.SetCursorPosition(i * 2, 0);
                Console.Write(name[i]);
            }

            for (int i = 0; i < len; i++)
            {
                Console.SetCursorPosition((len - 1) * 2, len - i - 1);
                Console.Write(name[i]);
                Console.SetCursorPosition((len - 1) * 2 - i * 2, len - 1);
                Console.Write(name[i]);
            }
        }

        public static void RunningSharp(int len,
                                        int distance,
                                        int speed,
                                        int x = 0,
                                        bool turn = false)
        {
            while (true)
            {
                for (int i = 0; i < len; i++)
                {
                    Console.SetCursorPosition(x + i, 5);
                    Console.Write("#");
                }
                Thread.Sleep(speed);

                for (int i = 0; i < len; i++)
                {
                    Console.SetCursorPosition(x + i, 5);
                    Console.Write(" ");
                }

                if (x + len == distance) turn = true;
                else if (x == 0) turn = false;

                if (turn) x--;
                else x++;
            }
        }

        public static void NameStackOverflow()
        {
            Console.Write("Enter ur name: ");
            string name = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(i * name.Length, i);
                Console.Write(name);
            }
        }

        public static void LuckyTicket()
        {
            int num, frst, scnd, summ1, summ2;
            Console.Write("Enter num: ");
            num = Convert.ToInt32(Console.ReadLine());
            frst = num / 1000;
            scnd = num % 1000;
            summ1 = 0;
            summ2 = 0;

            while (frst > 0)
            {
                summ1 += frst % 10;
                frst = frst / 10;
            }
            while (scnd > 0)
            {
                summ2 += scnd % 10;
                scnd = scnd / 10;
            }

            if (summ1 == summ2)
            {
                Console.WriteLine("Ur ticket is lucky ;)");
            }
            else
            {
                Console.WriteLine("Ur ticket isn't lucky ;(");
            }
        }

        public static void SumOfDigits()
        {
            Console.Write("Enter num: ");
            int num = Convert.ToInt32(Console.ReadLine());

            int summ = 0;

            while (num > 0)
            {
                summ += num % 10;
                num = num / 10;
                Console.WriteLine("\n====\nnum: " + num);
                Console.WriteLine("last digit: " + num % 10 + "\n====\n");
            }
            Console.WriteLine("summ: " + summ);
        }

        public static void Papuga()
        {
            Console.Write("Enter N: ");
            int hair = Convert.ToInt32(Console.ReadLine());
            int days = 0;
            int ps = 1;

            while (hair > 0)
            {
                days++;

                if (ps > hair)
                {
                    hair = 0;
                }
                else
                {
                    hair -= ps;
                }
                Console.WriteLine("{0} hairs left ({1} day)", hair, days);
                ps *= 2;
            }
            Console.WriteLine("for {0} days", days);
        }

        public static void Granes()
        {
            ulong granes = 1;
            ulong granes_per_cell = 1;
            for (int i = 0; i < 64; i++)
            {
                Console.WriteLine("{0} - я клеточка {1} зернышек",
                    i + 1, granes_per_cell);
                granes_per_cell *= 2;
                granes += granes_per_cell;
            }
            Console.WriteLine("\nВсего {0} зернышек", granes);
            Console.WriteLine("Все они весят {0} тонн", granes * 0.0000006);
        }

        public static void KuraEggs()
        {
            Console.Write("Enter K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int popped = 1;
            int eggs = 0;

            for (int i = 0; i < n; i++)
            {
                eggs += popped;
                popped += k;

                Console.WriteLine("from {0} eggs {1} times", eggs, i + 1);
            }
        }

        public static string Weather(int temp)
        {
            string state = "ZHARA";
            if (temp < 30)
            {
                state = "2";
            }
            return state;
        }

        public static bool Conditioner(int temp)
        {
            if (temp < 15 || temp > 30)
            {
                return true;
            }

            return false;
        }

        public static string CountCats(long cats,
                                       string s1,
                                       string s2,
                                       string s3)
        {
            cats = Math.Abs(cats);
            int cLTD = (int)cats % 100;
            int cLOD = (int)cats % 10;
            if (cLTD < 11 || cLTD > 14)
            {
                if (cLOD > 1 && cLOD < 5)
                    return s2;
                else
                    if (cLOD == 1)
                        return s1;
            }
            return s3;
        }
    }
}