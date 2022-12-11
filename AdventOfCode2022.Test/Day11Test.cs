namespace AdventOfCode2022.Test;

public class Day11Test
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day11Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var input = File.ReadAllText("./exampledata/day11_1.txt");

        var sum = Day11.PartOne(input);

        sum.Should().Be(10605);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var input = File.ReadAllText("./exampledata/day11_1.txt");

        var result = Day11.PartTwo(input);
        result.Should().Be(2713310158);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day11.txt");
        var result = Day11.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(61005);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day11.txt");
        var result = Day11.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(20567144694L);
    }
}