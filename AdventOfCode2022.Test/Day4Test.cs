namespace AdventOfCode2022.Test;

using FluentAssertions;
using Xunit.Abstractions;

public class Day4Test
{
    private static readonly string[] Teststring = """
                        2-4,6-8
                        2-3,4-5
                        5-7,7-9
                        2-8,3-7
                        6-6,4-6
                        2-6,4-8
                        """.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    private readonly ITestOutputHelper _testOutputHelper;

    public Day4Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var sum = Day4.PartOne(Teststring);

        sum.Should().Be(2);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var sum = Day4.PartTwo(Teststring);

        sum.Should().Be(4);
    }

    [Fact]
    private void CalculatesSolutionForDayOnePartOne()
    {
        var input = File.ReadAllLines("./puzzledata/day4.txt");
        var result = Day4.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
    }
    
    [Fact]
    private void CalculatesSolutionForDayOnePartTwo()
    {
        var input = File.ReadAllLines("./puzzledata/day4.txt");
        var result = Day4.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
    }
}