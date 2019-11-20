using System;

namespace MRSTF
{
    class Tests
    {
        public static void ShowKeysId()
        {
            ConsoleKeyInfo cki;
            Console.Write("==================================\n");

            while (true)
            {
                cki = Console.ReadKey(true);
                Console.WriteLine("Hash code: {0}", cki.GetHashCode());
                Console.WriteLine("Modifiers: {0}", cki.Modifiers);
                Console.WriteLine("Key char: {0}", cki.KeyChar);
                Console.WriteLine("Key: {0}", cki.Key);

                Console.Write("==================================\n");
            }
        }
    }
}