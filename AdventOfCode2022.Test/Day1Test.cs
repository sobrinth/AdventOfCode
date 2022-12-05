namespace AdventOfCode2022.Test;

public class Day1Test
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

    public Day1Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleListPartOne()
    {
        var maxCalories = Day1.GetMaxCalories(Teststring);

        maxCalories.Should().Be(24000);
    }
    
    [Fact]
    private void CalculatesExampleListPartTwo()
    {
        var maxCalories = Day1.GetMaxCalories(Teststring, 3);

        maxCalories.Should().Be(45000);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var elfList = File.ReadAllText("./puzzledata/day1.txt");
        var maxCalories = Day1.GetMaxCalories(elfList);
        _testOutputHelper.WriteLine(maxCalories.ToString());
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var elfList = File.ReadAllText("./puzzledata/day1.txt");
        var maxCalories = Day1.GetMaxCalories(elfList, 3);
        _testOutputHelper.WriteLine(maxCalories.ToString());
    }
}