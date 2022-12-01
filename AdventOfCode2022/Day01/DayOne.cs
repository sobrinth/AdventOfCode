namespace AdventOfCode2022.Day01;

public class DayOne
{
    public static int GetMaxCalories(string inputFile, int numberOfElvesToUse = 1) =>
        inputFile
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => x
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(0, (acc, value) => acc + int.Parse(value)))
            .OrderDescending()
            .Take(numberOfElvesToUse)
            .Sum();
}