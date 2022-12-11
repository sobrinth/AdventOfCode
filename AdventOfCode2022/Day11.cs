namespace AdventOfCode2022;

public class Day11
{
    public static long PartOne(string input, bool useMonkeyMod = false, int rounds = 20)
    {
        var monkeys = InitMonkeys(input);
        Func<long, long> worryFunction;
        if (useMonkeyMod)
        {
            // MATH-MOMENT
            // We can take the modulo of the item with the multiple of all the "throwTests" any time we
            // like due to the fact that we only add and multiply. The result will always be congruent.
            // @see: Modular Arithmetic (Congruence)
            var commonModulo = monkeys.Aggregate(1, (mod, monkey) => mod * monkey.ThrowTest);
            worryFunction = l => l % commonModulo;
        }
        else
        {
            worryFunction = l => l / 3;
        }

        // Run rounds
        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    monkey.InspectionCount++;

                    var item = monkey.Items.Dequeue();
                    item = monkey.Operation(item);
                    item = worryFunction(item);

                    var targetMonkey = item % monkey.ThrowTest == 0 ? monkey.SuccessMonkey : monkey.FailMonkey;
                    monkeys[targetMonkey].Items.Enqueue(item);
                }
            }
        }

        var monkeyBusiness = monkeys.OrderByDescending(x => x.InspectionCount)
            .Take(2)
            .Aggregate(1L, (acc, monkey) => acc * monkey.InspectionCount);
        
        return monkeyBusiness;
    }

    public static long PartTwo(string input)
    {
        return PartOne(input, true, 10000);
    }



    private static Monkey[] InitMonkeys(string input)
    {
        var monkeyEntries = input.Split($"{Environment.NewLine}{Environment.NewLine}").ToArray();
        var monkeys = new List<Monkey>();

        foreach (var monkeyEntry in monkeyEntries)
        {
            var monkeyLines = monkeyEntry.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            
            var startingItems = new Queue<long>(monkeyLines[1][16..].Split(",").Select(long.Parse));

            Func<long, long> operation;
            // Operation 
            if (monkeyLines[2][21] == '+')
            {
                var add = int.Parse(monkeyLines[2][23..]);
                operation = (i => i + add);
            }
            else if (monkeyLines[2][23] == 'o')
            {
                operation = i => i * i;
            }
            else
            {
                var mul = int.Parse(monkeyLines[2][23..]);
                operation = i => i * mul;
            }
            
            var throwTest = int.Parse(monkeyLines[3][19..]);
            var successMonkey = int.Parse(monkeyLines[4][25..]);
            var failMonkey = int.Parse(monkeyLines[5][26..]);

            var monkey = new Monkey
            {
                Items = startingItems,
                Operation = operation,
                InspectionCount = 0,
                ThrowTest = throwTest,
                SuccessMonkey = successMonkey,
                FailMonkey = failMonkey
            };
            monkeys.Add(monkey);
        }

        return monkeys.ToArray();
    }
    
    
    private record Monkey
    {
        public required Queue<long> Items;
        public required Func<long, long> Operation;
        public required int InspectionCount;
        public required int ThrowTest;
        public required int FailMonkey;
        public required int SuccessMonkey;
    }
}