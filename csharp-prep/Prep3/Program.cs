using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic number? ");
        //string textNumber = Console.ReadLine(); // get the user's magic number as text
        //int magic = int.Parse(textNumber); // convert to integer
        //above code ^^ prompts for the magic number instead...
        Random randomizer = new Random();
        int magic = randomizer.Next(1, 100); // random number from 1 to 100
        int guess;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine()); // sinlge line input integer guess
            if( guess < magic)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magic)
            {
                Console.WriteLine("Lower");
            }
            else if (guess == magic)
            {
                Console.WriteLine("You guessed it!");
            }
            else
            {
                Console.WriteLine("Error: Invalid guess. Terminating game...");
                guess = magic; // end the game if their guess throws some errors or anything like that
            }
        } while (guess != magic); // keep going until they guess the right number
        
    }
}