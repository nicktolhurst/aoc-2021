internal static class PartOne
{
    private static readonly string[] Input = File.ReadAllLines(@".\Data\day4");
    private static readonly string[] InputSample = File.ReadAllLines(@".\Data\day4_sample");

    internal static void Process(bool useSampleData = false)
    {
        var game = new Game(useSampleData ? InputSample : Input);

        for (var round = 0; round < game.NumbersToCall.Length && game.InProgress; round++)
        {
            game.NumbersCalled.Add(game.NumbersToCall[round]);

            for (var player = 0; player < game.Boards.Count && game.InProgress; player++)
            {
                game.Boards[player].UpdateProgress(game.NumbersCalled);

                if (!game.Boards[player].IsWinner) break;

                // Finish the game
                game.InProgress = false;

                // Add up all the remaining numbers on the winning board.
                var sumOfAllRemainingBoardValues = game.Boards[player].PathsToVictory
                    .SelectMany(all => all)
                    .Except(game.NumbersCalled)
                    .Select(remaining => Convert.ToInt32(remaining))
                    .Sum();

                Console.WriteLine($"PART 1 ANSWER: {sumOfAllRemainingBoardValues * Convert.ToInt32(game.NumbersToCall[round])}");
            }
        }
    }
}