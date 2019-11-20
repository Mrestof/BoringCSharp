using System;

namespace MRSTF
{
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

        public static string AskInput(string prompt = "Enter text: ",
                                      string type = "text")
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
                    ConsoleKeyInfo c = Console.ReadKey(true);

                    if (c.Key == ConsoleKey.Enter) break;

                    if (c.Key != ConsoleKey.Backspace)
                    {
                        pass += c.KeyChar;
                        Console.Write("*");
                    }

                    else
                    {
                        if (pass.Length != 0)
                        {
                            pass = pass.Remove(pass.Length - 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1,
                                Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1,
                                Console.CursorTop);
                        }
                    }
                }

                return pass;
            }

            else
            {
                return "NO SUCH TYPE!";
            }
        }

        public static int[] AskIntInput(string prompt = "Enter an array: ")
        {
            char key;
            int[] arr = new int[1000];
            Console.Write(prompt);

            while (true)
            {
                key = Console.ReadKey().KeyChar;

                if (true)
                {
                    break;
                }
            }

            return arr;
        }
    }
}