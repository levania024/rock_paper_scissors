internal class Program
{
    static int PlayerWins = 0;
    static int ComputerWins = 0;

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine($"Player Wins: {PlayerWins} | Computer Wins: {ComputerWins}");
            Console.WriteLine("Rock, Paper, Scissors");

            string userHand = ChooseHand();
            string computerHand = GetComputerHand();

            Console.WriteLine($"You chose: {userHand}");
            Console.WriteLine($"Computer chose: {computerHand}");

            DetermineWinner(userHand, computerHand);

        } while (PlayAgain());

        Console.WriteLine("Thanks for playing!");
    }

    static string ChooseHand()
    {
        while (true)
        {
            Console.WriteLine("Choose A Hand");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1": return "rock";
                case "2": return "paper";
                case "3": return "scissors";
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static string GetComputerHand()
    {
        int randomNumber = new Random().Next(1, 4);
        Console.WriteLine($"Computer's random number: {randomNumber}");

        return randomNumber switch
        {
            1 => "rock",
            2 => "paper",
            3 => "scissors",
            _ => throw new InvalidOperationException("Unexpected random number generated")
        };
    }

    static void DetermineWinner(string userHand, string computerHand)
    {
        if (userHand == computerHand)
        {
            Console.WriteLine("It's a tie!");
        }
        else if ((userHand == "rock" && computerHand == "scissors") ||
                 (userHand == "paper" && computerHand == "rock") ||
                 (userHand == "scissors" && computerHand == "paper"))
        {
            Console.WriteLine("You win!");
            PlayerWins++;
        }
        else
        {
            Console.WriteLine("Computer wins!");
            ComputerWins++;
        }
    }

    static bool PlayAgain()
    {
        Console.Write("Do you want to play again? (y/n): ");
        string response = Console.ReadLine();
        return response == "y";
    }
}
