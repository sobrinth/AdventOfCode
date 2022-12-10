namespace AdventOfCode2022.Test;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser]
public class Day10Benchmark
{
    private string[]? _inputData;
    
    [GlobalSetup]
    public void Setup()
    {
        _inputData = File.ReadAllLines("./puzzledata/day10.txt");
    }

    [Benchmark] 
    public int PartOneV1() => Day10.PartOne(_inputData!);
    
    [Benchmark] 
    public int PartOneV2() => Day10.PartOneV2(_inputData);
    
    [Benchmark] 
    public string PartTwoV1() => Day10.PartTwo(_inputData!);
    
    [Benchmark] 
    public string PartTwoV2() => Day10.PartTwoV2(_inputData);
}