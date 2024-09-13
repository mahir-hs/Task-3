using Task_3;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Error: You need to provide an odd number of moves (≥ 3).");
            return;
        }

        if (args.Distinct().Count() != args.Length)
        {
            Console.WriteLine("Error: Moves must be unique. Duplicate move detected.");
            return;
        }

        var moves = args;
        var rules = new GameRules(moves);
        var hmacGen = new HmacGenerator();

        var random = new Random();
        int computerMoveIndex = random.Next(moves.Length);
        var (hmac, key) = hmacGen.GenerateHmac(moves[computerMoveIndex]);
        var helpTable = new HelpTable(moves);

        Console.WriteLine($"HMAC: {hmac}");
        Console.WriteLine("Available moves:");
        for (int i = 0; i < moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");

        string input;
        while ((input = Console.ReadLine()) != "0")
        {
            if (input == "?")
            {
                helpTable.PrintTable();
                continue;
            }

            if (int.TryParse(input, out int playerMove) && playerMove >= 1 && playerMove <= moves.Length)
            {
                int playerMoveIndex = playerMove - 1;

                Console.WriteLine($"Your move: {moves[playerMoveIndex]}");
                Console.WriteLine($"Computer move: {moves[computerMoveIndex]}");

                bool playerWins = rules.IsWin(playerMoveIndex, computerMoveIndex);
                Console.WriteLine(playerWins ? "You win!" : "You lose!");
                Console.WriteLine($"HMAC key: {key}");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

}
