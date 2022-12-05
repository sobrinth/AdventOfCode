namespace AdventOfCode2022;

using System.Text.RegularExpressions;

public partial class Day5
{
    public static string PartOne(string teststring)
    {
        var strings = teststring.Split($"{Environment.NewLine}{Environment.NewLine}");
        var crateStacks = CreateCrateStacks(strings[0]);

        foreach (var command in strings[1].Split(Environment.NewLine))
        {
            var regexResult = MoveRegex().Match(command);
            var moveCount = int.Parse(regexResult.Groups[1].Value);
            var from = int.Parse(regexResult.Groups[2].Value) - 1;
            var to = int.Parse(regexResult.Groups[3].Value) - 1;
            
            // Move crates
            for (var i = 0; i < moveCount; i++)
            {
                crateStacks[to].Push(crateStacks[from].Pop());
            }
        }

        return string.Join("", crateStacks.Select(stack => stack.Pop()));
    }

    public static object PartTwo(string teststring)
    {
        var strings = teststring.Split($"{Environment.NewLine}{Environment.NewLine}");
        var crateStacks = CreateCrateStacks(strings[0]);

        foreach (var command in strings[1].Split(Environment.NewLine))
        {
            var regexResult = MoveRegex().Match(command);
            var moveCount = int.Parse(regexResult.Groups[1].Value);
            var from = int.Parse(regexResult.Groups[2].Value) - 1;
            var to = int.Parse(regexResult.Groups[3].Value) - 1;
            
            // Move crates
            var carryStack = new Stack<char>(50);
            for (var i = 0; i < moveCount; i++)
            {
                carryStack.Push(crateStacks[from].Pop());
            }            
            for (var i = 0; i < moveCount; i++)
            {
                crateStacks[to].Push(carryStack.Pop());
            }
        }

        return string.Join("", crateStacks.Select(stack => stack.Pop()));
    }

    private static Stack<char>[] CreateCrateStacks(string problemHeader)
    {
        var stackLines = problemHeader.Split(Environment.NewLine).Reverse();
        var stacks = stackLines.First().Chunk(4).Select(i => new Stack<char>(50)).ToArray();

        foreach (var crateLine in stackLines.Skip(1))
        {
            foreach (var (stack, item) in stacks.Zip(crateLine.Chunk(4)))
            {
                if (!char.IsWhiteSpace(item[1]))
                {
                   stack.Push(item[1]); 
                }
            }
        }

        return stacks;
    }

    [GeneratedRegex("move (.*) from (.*) to (.)")]
    private static partial Regex MoveRegex();
}