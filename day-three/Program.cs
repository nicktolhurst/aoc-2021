string[] report = File.ReadAllLines(@"C:\Local\Personal\Advent\day-three\input");

List<char> gammaRateBinary = new();

for (int x = 0; x < 12; x++)
{   
    // Gets most common occurance of 'char' in binary string.
    gammaRateBinary.Add(report
        .Select(dat => dat[x])
        .GroupBy(val => val)
        .OrderByDescending(group => group.Count())
        .First()
        .First());
}

// Convert char arrays to string and flip for epsilon value
var gammaStr = new string(gammaRateBinary.ToArray());
var epsilonStr = new string(gammaStr.Select(c => c == '1' ? '0' : '1').ToArray());

// Convert binary string to int32
var gamma = Convert.ToInt32(gammaStr, 2);
var epsilon = Convert.ToInt32(epsilonStr, 2);

Console.WriteLine($"Part 1: {gamma*epsilon}");