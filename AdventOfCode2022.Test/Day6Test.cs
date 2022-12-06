namespace AdventOfCode2022.Test;

public class Day6Test
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day6Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    private void CalculatesExampleDataPartOne(string data, int startIndex)
    {
        var sum = Day6.PartOne(data);

        sum.Should().Be(startIndex);
    }
    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    private void CalculatesExampleDataPartTwo(string data, int startIndex)
    {
        var sum = Day6.PartTwo(data);

        sum.Should().Be(startIndex);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day6.txt");
        var result = Day6.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(1920);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day6.txt");
        var result = Day6.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(2334);
    }
}