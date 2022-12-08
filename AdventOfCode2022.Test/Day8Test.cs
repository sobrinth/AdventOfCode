namespace AdventOfCode2022.Test;

public class Day8Test
{
    private static readonly string Teststring = """
                        30373
                        25512
                        65332
                        33549
                        35390
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public Day8Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var sum = Day8.PartOne(Teststring);

        sum.Should().Be(21);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var sum = Day8.PartTwo(Teststring);

        sum.Should().Be(8);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day8.txt");
        var result = Day8.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(1807);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day8.txt");
        var result = Day8.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(480000);
    }
}