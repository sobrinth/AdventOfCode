namespace AdventOfCode2022.Test.Day01;

using AdventOfCode2022.Day01;
using FluentAssertions;
using Xunit.Abstractions;

public class DayOneTest
{
    private const string Teststring = """
                        1000
                        2000
                        3000
                        
                        4000
                        
                        5000
                        6000
                        
                        7000
                        8000
                        9000
                        
                        10000
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public DayOneTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleListPartOne()
    {
        var maxCalories = DayOne.GetMaxCalories(Teststring);

        maxCalories.Should().Be(24000);
    }
    
    [Fact]
    private void CalculatesExampleListPartTwo()
    {
        var maxCalories = DayOne.GetMaxCalories(Teststring, 3);

        maxCalories.Should().Be(45000);
    }

    [Fact]
    private void CalculatesSolutionForDayOnePartOne()
    {
        var elfList = File.ReadAllText("./puzzledata/day01.txt");
        var maxCalories = DayOne.GetMaxCalories(elfList);
        _testOutputHelper.WriteLine(maxCalories.ToString());
    }
    
    [Fact]
    private void CalculatesSolutionForDayOnePartTwo()
    {
        var elfList = File.ReadAllText("./puzzledata/day01.txt");
        var maxCalories = DayOne.GetMaxCalories(elfList, 3);
        _testOutputHelper.WriteLine(maxCalories.ToString());
    }
}