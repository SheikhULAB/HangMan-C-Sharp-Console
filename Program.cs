using System;
using System.IO;
using System.Linq;
using System.Text;

namespace HangMan
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PrintMessage("HANGMAN");
            DrawHangman();
          
            PrintMessage("Guess the word");
            Player();


          
        }

        public static void PrintMessage(string message, bool printTop = true, bool printBottom = true)
        {
            if (printTop)
            {
                Console.WriteLine("+---------------------------------+");
                Console.Write("|");
            }
            else
            {
                Console.Write("|");
            }
            bool front = true;
            for (int i = message.Length; i < 33; i++)
            {
                if (front)
                {
                    message = " " + message;
                }
                else
                {
                    message = message + " ";
                }
                front = !front;

            }

            Console.Write(message);

            if (printBottom)
            {
                Console.WriteLine("|");
                Console.WriteLine("+---------------------------------+");
            }
            else
            {
                Console.WriteLine("|");
            }
        }



        public static void DrawHangman(int guessCount = 0)
        {
            if (guessCount >= 1)
                PrintMessage("|", false, false);
            else
                PrintMessage("", false, false);

            if (guessCount >= 2)
                PrintMessage("|", false, false);
            else
                PrintMessage("", false, false);

            if (guessCount >= 3)
                PrintMessage("O", false, false);
            else
                PrintMessage("", false, false);

            if (guessCount == 4)
                PrintMessage("/  ", false, false);

            if (guessCount == 5)
                PrintMessage("/| ", false, false);

            if (guessCount >= 6)
                PrintMessage("/|\\", false, false);
            else
                PrintMessage("", false, false);

            if (guessCount >= 7)
                PrintMessage("|", false, false);
            else
                PrintMessage("", false, false);

            if (guessCount == 8)
                PrintMessage("/", false, false);

            if (guessCount >= 9)
                PrintMessage("/ \\", false, false);
            else
                PrintMessage("", false, false);
        }

        public static void Player()
        {
            string dir = "/Users/yeamin/Projects/HangMan/words.txt";

            string[] listwords = File.ReadLines(dir).ToArray();

            
            Random randGen = new Random();
            var idx = randGen.Next(0, 59);
            string mysteryWord = listwords[idx];
           
            char[] guess = new char[mysteryWord.Length];
            Console.Write("Please enter your guess: ");

            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '*';


            int xy = 0;
            
            bool chk = false;

            while (true)
            {

                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                    {
                        guess[j] = playerGuess;                     
                        chk = true;
                        
                    }

                }

                if (chk != true)
                {
                    xy++;

                    DrawHangman(xy);

                }
                else
                {
                    chk = false;
                }
                if (xy == 9)
                {
                    Console.WriteLine("YOU LOSE. TRY AGAIN");
                    Console.WriteLine("Word is : {0}", mysteryWord);

                    Environment.Exit(0);

                }

                Console.WriteLine(guess);

                string guess2 = new string(guess);

                if (String.Equals(guess2, mysteryWord))
                    {
                        Console.WriteLine("YOU WIN! CONGRATULATIONS");
                        Environment.Exit(0);
                    }
                }             

            }


        }

        }
       
    

