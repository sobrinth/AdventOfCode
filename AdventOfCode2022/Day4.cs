namespace AdventOfCode2022;

public class Day4
{
    public static int PartOne(IEnumerable<string> pairs) =>
        pairs.Select(pair =>
                pair.Split(',', '-')
                    .Select(int.Parse)
                    .ToArray())
            .Count(x =>
                (x[0] >= x[2] && x[1] <= x[3])
                || (x[2] >= x[0] && x[3] <= x[1]));

    public static int PartTwo(IEnumerable<string> pairs) =>
        pairs.Select(pair =>
                pair.Split(',', '-')
                    .Select(int.Parse)
                    .ToArray())
            .Count(x =>
                (x[0] < x[2] && x[1] >= x[2])
                || (x[0] >= x[2] && x[0] <= x[3]));
}