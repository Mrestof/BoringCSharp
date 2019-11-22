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

        public static string AskStrInput(string prompt = "Enter text: ",
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

        public static int[] AskIntInput(string prompt = "Enter an int array: ")
        {
            ConsoleKeyInfo key;
            string msg_arr = "";
            int limit = 0, length = 1000;
            int[] arr = new int[length];
            Console.Write(prompt);

            while (true)
            {
                // Drawing array
                if (limit == 0) msg_arr = "[]";
                else if (limit <= length)
                {
                    msg_arr = "[";
                    for (int i = 0; i < limit; i++)
                    {
                        msg_arr += arr[i];
                        if (i != limit - 1) msg_arr += ", ";
                    }
                    msg_arr += "]";
                }

                Console.Clear();
                Console.Write(prompt + msg_arr);

                // Detect what key is pressed, and choose what to do
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter) 
                {
                    int[] arr_output = new int[limit];
                    for (int i = 0; i < limit; i++)
                    {
                        arr_output[i] = arr[i];
                    }
                    return arr_output;
                }

                else if (key.Key == ConsoleKey.Backspace & limit > 0)
                    arr[--limit] = 0;

                else if (limit < length)
                {
                    // This part is disgusting... (need to redo it)
                    switch (key.Key)
                    {
                        default: break;

                        // Checking for nums
                        case ConsoleKey.D0: arr[limit++] = 0; break;
                        case ConsoleKey.D1: arr[limit++] = 1; break;
                        case ConsoleKey.D2: arr[limit++] = 2; break;
                        case ConsoleKey.D3: arr[limit++] = 3; break;
                        case ConsoleKey.D4: arr[limit++] = 4; break;
                        case ConsoleKey.D5: arr[limit++] = 5; break;
                        case ConsoleKey.D6: arr[limit++] = 6; break;
                        case ConsoleKey.D7: arr[limit++] = 7; break;
                        case ConsoleKey.D8: arr[limit++] = 8; break;
                        case ConsoleKey.D9: arr[limit++] = 9; break;
                    }
                }
            }
        }
    }
}