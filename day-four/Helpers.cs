public static class Helpers
{
    public static IEnumerable<IEnumerable<string>> ChunkBy(this IEnumerable<string> source, int chunkSize)
    {
        while (source.Any())
        {
            yield return source.Take(chunkSize);
            source = source.Skip(chunkSize);
        }
    }

    public static string[,] To2DArray(this IList<string[]> arrays)
    {
        var rowsLength = arrays.Count;
        var colsLength = arrays[0].Length;
        
        // Create the 2D array with the correct dimensions.
        string[,] ret = new string[rowsLength, colsLength];

        for (var row = 0; row < rowsLength; row++)
        {
            for (var col = 0; col < colsLength; col++)
            {
                ret[row, col] = arrays[row][col];
            }
        }
        return ret;
    }
}