namespace AdventOfCode2022.Test;

public class Day5Test
{
    private static readonly string Teststring = """
                            [D]    
                        [N] [C]    
                        [Z] [M] [P]
                         1   2   3 
                        
                        move 1 from 2 to 1
                        move 3 from 1 to 3
                        move 2 from 2 to 1
                        move 1 from 1 to 2
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public Day5Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var sum = Day5.PartOne(Teststring);

        sum.Should().Be("CMZ");
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var sum = Day5.PartTwo(Teststring);

        sum.Should().Be("MCD");
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day5.txt");
        var result = Day5.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be("NTWZZWHFV");
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day5.txt");
        var result = Day5.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be("BRZGFVBTJ");
    }
}