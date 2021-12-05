internal class Board
{
    internal Board(IEnumerable<string> data)
    {
        // Parse rows
        var rows = data
            .Select(x => x
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray())
            .ToList();

        // Create a 2D array to represent both rows an columns.
        var table = rows.To2DArray();

        // Extract all possible paths to victory.
        PathsToVictory = Enumerable.Range(0, table.GetLength(0))
            .Select(row => Enumerable.Range(0, table.GetLength(1))
                .Select(col => table[row, col])
                .ToArray())
            .ToArray();

        IsWinner = false;
    }

    internal string[][] PathsToVictory { get; }
    
    internal bool IsWinner { get; private set; }
    
    internal void UpdateProgress(List<string> numbersCalled)
    {
        IsWinner = PathsToVictory.FirstOrDefault(path => path.All(numbersCalled.Contains)) is not null;
    }
}