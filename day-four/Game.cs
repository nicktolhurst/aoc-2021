internal class Game 
{
    internal Game(string[] data)
    {
        NumbersCalled = new List<string>();

        (NumbersToCall, Boards) = Setup(data);

        InProgress = true;
    }

    internal string[] NumbersToCall { get; }
    internal List<string> NumbersCalled { get; }
    internal List<Board>  Boards { get; }
    internal bool InProgress { get; set; }

    private static (string[], List<Board>) Setup(string[] data)
    {
        var numbers = data
            .First()
            .Split(',')
            .ToArray();

        var boards = data
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ChunkBy(5)
            .Select(board => new Board(board))
            .ToList();

        return (numbers, boards);
    }
}