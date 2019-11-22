using System;

namespace MRSTF
{
    class Games
    {
        public static void GuessTheWord()
        {
            bool found = false;
            string secret_word =
                Useful.AskStrInput("Enter secret word: ", "password").ToLower();
            string display_text = "";
            string guessed = "";
            char[] tmp = {};

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
            Console.Write(
                "Congrtulations!\nYou solve it!\n\nPress (ESC) to exit.");
        }

        public static void BullsNCows()
        {
            // UNDONE!
        }
    }
}