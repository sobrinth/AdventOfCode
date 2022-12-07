namespace AdventOfCode2022.Test;

public class Day7Test
{
    private static readonly string Teststring = """
                        $ cd /
                        $ ls
                        dir a
                        14848514 b.txt
                        8504156 c.dat
                        dir d
                        $ cd a
                        $ ls
                        dir e
                        29116 f
                        2557 g
                        62596 h.lst
                        $ cd e
                        $ ls
                        584 i
                        $ cd ..
                        $ cd ..
                        $ cd d
                        $ ls
                        4060174 j
                        8033020 d.log
                        5626152 d.ext
                        7214296 k
                        """;

    private readonly ITestOutputHelper _testOutputHelper;

    public Day7Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var sum = Day7.PartOne(Teststring);

        sum.Should().Be(95437);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var sum = Day7.PartTwo(Teststring);

        sum.Should().Be(24933642);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllText("./puzzledata/day7.txt");
        var result = Day7.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(1367870);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllText("./puzzledata/day7.txt");
        var result = Day7.PartTwo(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(549173);
    }
}