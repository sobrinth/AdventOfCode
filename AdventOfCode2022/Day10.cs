namespace AdventOfCode2022;

public class Day10
{
    public static int PartOne(IEnumerable<string> input)
    {
        var cycle = 0;
        var regX = 1;
        var signalStrengths = new List<int>(240);
        foreach (var command in input)
        {
            cycle++;
            if ((cycle - 20) % 40 == 0)
            {
                signalStrengths.Add(cycle * regX);
            }

            if (command.StartsWith("addx"))
            {
                var number = int.Parse(command.Split(' ')[^1]);
                cycle++;
                if ((cycle - 20) % 40 == 0)
                {
                    signalStrengths.Add(cycle * regX);
                }

                regX += number;
            }
        }

        return signalStrengths.Sum();
    }
    
    public static int PartOneV2(string[] input)
    {
        var cycle = 0;
        var regX = 1;
        var signalStrength = 0;
        foreach (var command in input)
        {
            var cmd = command.AsSpan();
            cycle++;
            if ((cycle - 20) % 40 == 0)
            {
                signalStrength += cycle * regX;
            }

            if (cmd[0] == 'a')
            {
                var number = int.Parse(cmd[4..]);
                cycle++;
                if ((cycle - 20) % 40 == 0)
                {
                    signalStrength += cycle * regX;
                }

                regX += number;
            }
        }

        return signalStrength;
    }

    public static string PartTwo(IEnumerable<string> input)
    {
        var cycle = 0;
        var regX = 1;
        var crtOutput = new List<char>(240);
        foreach (var command in input)
        {
            cycle++;

            crtOutput.Add(GetCrtOutput(cycle, regX));

            if (command.StartsWith("addx"))
            {
                var number = int.Parse(command.Split(' ')[^1]);
                cycle++;

                crtOutput.Add(GetCrtOutput(cycle, regX));

                regX += number;
            }
        }

        return string.Join("", crtOutput);
    }
    
    
    public static string PartTwoV2(string[] input)
    {
        var cycle = 0;
        var regX = 1;
        Span<char> crtOutput = stackalloc char[240];
        foreach (var command in input)
        {
            var cmd = command.AsSpan();
            cycle++;

            crtOutput[cycle-1] = GetCrtOutput(cycle, regX);

            if (cmd[0] == 'a')
            {
                var number = int.Parse(cmd[4..]);
                cycle++;

                crtOutput[cycle-1] = GetCrtOutput(cycle, regX);

                regX += number;
            }
        }

        return crtOutput.ToString();
    }

    private static char GetCrtOutput(int cycle, int regX)
    {
        return (cycle - 1) % 40 >= regX - 1 && (cycle - 1) % 40 <= regX + 1 ? '#' : '.';
    }
}