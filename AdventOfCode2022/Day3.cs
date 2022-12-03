namespace AdventOfCode2022;

public class Day3
{
    public static int PartOne(IEnumerable<string> rucksacks) =>
        rucksacks.Select(rucksack =>
                (rucksack[..(rucksack.Length / 2)],
                    rucksack[(rucksack.Length / 2)..]))
            .Select((compartments) => compartments.Item1.Intersect(compartments.Item2))
            .Aggregate(0, (sum, badge) => sum += GetPriority(badge.First()));

    public static int PartTwo(IEnumerable<string> rucksacks) =>
        rucksacks.Chunk(3)
            .Select(groups => groups[0].Intersect(groups[1]).Intersect(groups[2]))
            .Aggregate(0, (sum, badge) => sum += GetPriority(badge.First()));

    private static int GetPriority(char item)
    {
        return item - 'a' >= 0 // Is the item a lowercase character?
            ? item - 'a' + 1  // Priorities 1-26
            : item - 'A' + 27; // Priorities 27-52 (basically just a flipped version of ASCII
    }
}