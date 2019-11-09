// Yes, it is pointless huge
using System;
using System.Collections.Generic;
using System.Threading;

namespace MRSTF
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Useful.SetColors("hacker");
            Console.ReadKey();
        }
    }

    class Useful
    {
        public static void SetColors(string theme = "magenta")
        {
            if (theme == "magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
            }
            else if (theme == "hacker")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Selected wrong theme!");
            }
        }

        public static string IntArrayToString(int[] array)
        {
            string output = "[";
            bool flag = false;

            foreach (var num in array)
            {
                if (flag)
                {
                    output += ", " + num;
                }
                else
                {
                    output += num;
                    flag = true;
                }
            }
            output += "]";

            return output;
        }

        public static string AskInput(string prompt = "Enter text: ", string type = "text")
        {
            if (type == "text")
            {
                Console.Write(prompt);
                string msg = Console.ReadLine();
                return msg;
            }

            else if (type == "password")
            {
                string pass = "";
                Console.Write(prompt);

                while (true)
                {
                    char c = Console.ReadKey(true).KeyChar;

                    if (c == 13)
                        break;

                    if (c != 8)
                    {
                        pass += c;
                        Console.Write("*");
                    }

                    else
                    {
                        if (pass.Length != 0)
                        {
                            pass = pass.Remove(pass.Length - 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                    }
                }

                return pass;
            }
            else if (type == "array")
            {
                string arr = "";
                Console.Write(prompt);
            }

            else
            {
                return "NO SUCH TYPE!";
            }
        }
    }

    class Trash
    {
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

        public static void RandomArrayGenerator()
        {
            List<int> list = new List<int>();
            int len = Convert.ToInt32(Useful.AskInput("Enter length of random array: "));
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

        public static void RunningSharp(int len, int distance, int speed, int x = 0, bool turn = false)
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
                Console.WriteLine("{0} - я клеточка {1} зернышек", i + 1, granes_per_cell);
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

        public static string CountCats(long cats, string s1, string s2, string s3)
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

    class Sort
    {
        public static int[] SelectionSort(int[] arr)
        {
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min]) pos_min = j;
                }

                temp = arr[i];
                arr[i] = arr[pos_min];
                arr[pos_min] = temp;
            }

            return arr;
        }

        public static int[] BubbleSort(int[] arr)
        {
            int tmp = 0;

            for (int i = arr.Length - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }

            return arr;
        }
    }

    class Games
    {
        public static void GuessTheWordGAME()
        {
            bool found = false;
            string secret_word = Useful.AskInput("Enter secret word: ", "password").ToLower();
            string display_text = "";
            string guessed = "";
            char[] tmp = { };
            for (int i = 0; i < secret_word.Length; i++) display_text += "*";

            while (display_text.Contains("*"))
            {
                Console.Clear();
                Console.Write(display_text);

                Console.Write("\nGuessed letters: " + guessed);

                Console.Write("\nChose a letter: ");
                char letter = Console.ReadKey().KeyChar;
                found = false;

                for (int i = 0; i < secret_word.Length; i++)
                {
                    if (letter == secret_word[i])
                    {
                        tmp = display_text.ToCharArray();
                        tmp[i] = letter;
                        display_text = new string(tmp);

                        tmp = secret_word.ToCharArray();
                        tmp[i] = '¿';
                        secret_word = new string(tmp);

                        found = true;
                    }
                }

                if (found) guessed += letter + ", ";
            }

            Console.Clear();
            Console.Write("Congrtulations!\nYou solve it!\n\nPress (ESC) to exit.");
        }

        public static void BullsNCows()
        {

        }
    }
}
