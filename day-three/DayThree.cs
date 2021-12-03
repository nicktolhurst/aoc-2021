
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class DayThree
{
    private static readonly string[] Report = File.ReadAllLines(@"C:\Local\Personal\Advent\day-three\input");

    public static int PartOne()
    {
        List<char> gammaRateBinary = new();

        for (var position = 0; position < 12; position++)
        {
            gammaRateBinary.Add(Report
                .Select(data => data[position])
                .GroupBy(value => value)
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
        var oxy = Report.Filter('1');
        var co2 = Report.Filter('0', true);

        return oxy * co2;
    }
}

static class Helpers
{
    // IEnumerable<char> c to binary integer representative converter.
    public static int ToBinaryIntValues(this IEnumerable<char> c) => Convert.ToInt32(new string(c.ToArray()), 2);

    // Epsilon converter delegate.
    public static readonly Func<char, char> InvertChars = c => c == '1' ? '0' : '1';

    public static int Filter(this string[] report, char tieBreaker, bool invertFilter = false)
    {
        for (var position = 0; position < 12 && report.Length > 1; position++)
        {
            var group = report
                .Select(data => data[position])
                .GroupBy(value => value)
                .OrderByDescending(group => group.Count())
                .ToList();

            var most = group[0].ToList();
            var least = group[1].ToList();

            var keep = most.Count == least.Count ? tieBreaker : !invertFilter ? most[0] : least[0];
            report = report.Where(data => data[position] == keep).ToArray();
        }

        return Convert.ToInt32(report[0], 2);
    }
}
