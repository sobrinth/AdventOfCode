namespace AdventOfCode2022.Test;

using FluentAssertions;
using Xunit.Abstractions;

public class Day3Test
{
    private static readonly string[] Teststring = """
                        vJrwpWtwJgWrhcsFMMfFFhFp
                        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                        PmmdzqPrVvPwwTWBwg
                        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                        ttgJtRGJQctTZtZT
                        CrZsJsPPZsGzwwsLwLmpwMDw
                        """.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    private readonly ITestOutputHelper _testOutputHelper;

    public Day3Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesPrioritySumExampleListPartOne()
    {
        var sum = Day3.PartOne(Teststring);

        sum.Should().Be(157);
    }
    
    [Fact]
    private void CalculatesPrioritySumExampleListPartTwo()
    {
        var sum = Day3.PartTwo(Teststring);

        sum.Should().Be(70);
    }

    [Fact]
    private void CalculatesSolutionForDayOnePartOne()
    {
        var rucksacks = File.ReadAllLines("./puzzledata/day3.txt");
        var result = Day3.PartOne(rucksacks);
        _testOutputHelper.WriteLine(result.ToString());
    }
    
    [Fact]
    private void CalculatesSolutionForDayOnePartTwo()
    {
        var rucksacks = File.ReadAllLines("./puzzledata/day3.txt");
        var result = Day3.PartTwo(rucksacks);
        _testOutputHelper.WriteLine(result.ToString());
    }
}