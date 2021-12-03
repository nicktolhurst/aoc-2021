
static class DayThree
{
    private static readonly string[] report = File.ReadAllLines(@"C:\Local\Personal\Advent\day-three\input");

    public static int PartOne()
    {
        List<char> gammaRateBinary = new();

        for (int x = 0; x < 12; x++)
        {
            gammaRateBinary.Add(report
                .Select(dat => dat[x])
                .GroupBy(val => val)
                .OrderByDescending(group => group.Count())
                .First()
                .First());
        }

        var gamma = gammaRateBinary.ToBinaryIntValues();
        var epsilon = gammaRateBinary.Select(Helpers.InvertChars).ToBinaryIntValues();

        return gamma * epsilon;
    }

    public static int PartTwo()
    {
        var oxy = report.Filter(tieBreaker: '1');
        var co2 = report.Filter(tieBreaker: '0', invertFilter: true);

        return oxy * co2;
    }
}

static class Helpers
{
    // IEnumerable<char> c to binary integer representative converter.
    public static int ToBinaryIntValues(this IEnumerable<char> c) => Convert.ToInt32(new string(c.ToArray()), 2);

    // Epsilion converter delegate.
    public static Func<char, char> InvertChars = c => c == '1' ? '0' : '1';

    public static int Filter(this string[] dataset, char tieBreaker, bool invertFilter = false)
    {
        for (int x = 0; x < 12 && dataset.Count() > 1; x++)
        {
            // if (dataset.Count() == 1) break;
            var group = dataset
                .Select(dat => dat[x])
                .GroupBy(val => val)
                .OrderByDescending(group => group.Count());

            var most = group.First();
            var least = group.Last();

            char keep = most.Count() == least.Count() ? tieBreaker : !invertFilter ? most.First() : least.First();
            dataset = dataset.Where(dat => dat[x] == keep).ToArray();
        }

        return Convert.ToInt32(dataset[0], 2);
    }
}
