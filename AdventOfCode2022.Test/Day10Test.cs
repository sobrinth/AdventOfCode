﻿namespace AdventOfCode2022.Test;

public class Day10Test
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day10Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    private void CalculatesExampleDataPartOne()
    {
        var input = File.ReadAllLines("./exampledata/day10_1.txt");

        var sum = Day10.PartOne(input);

        sum.Should().Be(13140);
    }
    
    [Fact]
    private void CalculatesExampleDataPartTwo()
    {
        var input = File.ReadAllLines("./exampledata/day10_1.txt");

        var result = Day10.PartTwo(input);
        _testOutputHelper.WriteLine(result);
    }

    [Fact]
    private void CalculatesSolutionForPartOne()
    {
        var input = File.ReadAllLines("./puzzledata/day10.txt");
        var result = Day10.PartOne(input);
        _testOutputHelper.WriteLine(result.ToString());
        result.Should().Be(13860);
    }
    
    [Fact]
    private void CalculatesSolutionForPartTwo()
    {
        var input = File.ReadAllLines("./puzzledata/day10.txt");
        var result = Day10.PartTwo(input);
        _testOutputHelper.WriteLine(result);
    }
}