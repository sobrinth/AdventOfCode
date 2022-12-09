namespace AdventOfCode2022.Test;

public class Day9Test
{
    private static readonly string Teststring = """
                        R 4
                        U 4
                        L 3
                        D 1
                        R 4
                        D 1
                        L 5
                        R 2
                        """;    
    private static readonly string Teststring2 = """
                        R 5
                        U 8
                        L 8
                        D 3
                        R 17
                        D 10
                        L 25
                        U 20
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public Day9Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var sum = Day9.PartOne(Teststring);

        sum.Should().Be(13);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var sum = Day9.PartTwo(Teststring2);

        sum.Should().Be(36);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day9.txt");
        var result = Day9.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(6332);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day9.txt");
        var result = Day9.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(2511);
    }
}