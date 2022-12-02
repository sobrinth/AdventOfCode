namespace AdventOfCode2022.Test;

using FluentAssertions;
using Xunit.Abstractions;

public class Day2Test
{

    private const string Teststring = """
                        A Y
                        B X
                        C Z
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public Day2Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    private void CalculatesSolutionForTeststringOnePartOne()
    {
        var score = Day2.CalculateScorePartOne(Teststring);
        score.Should().Be(15);
    }  
    
    [Fact]
    private void CalculatesSolutionForTeststringOnePartTwo()
    {
        var score = Day2.CalculateScorePartTwo(Teststring);
        score.Should().Be(12);
    }
    
    [Fact]
    private void CalculatesSolutionForDayOnePartOne()
    {
        var rounds = File.ReadAllText("./puzzledata/day2.txt");
        var score = Day2.CalculateScorePartOne(rounds);
        _testOutputHelper.WriteLine(score.ToString());
    }

    [Fact]
    private void CalculatesSolutionForDayOnePartTwo()
    {
        var rounds = File.ReadAllText("./puzzledata/day2.txt");
        var score = Day2.CalculateScorePartTwo(rounds);
        _testOutputHelper.WriteLine(score.ToString());
    }
}