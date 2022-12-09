namespace AdventOfCode2022;

public class Day9
{
    public static object PartOne(string input)
    {
        var steps = input.Split(Environment.NewLine);

        var head = (0, 0);
        var tail = (0, 0);
        (int, int) prevHead;
        var visitedSpaces = new HashSet<(int, int)>(10000) { tail };

        foreach (var step in steps)
        {
            var movement = step[0] switch
            {
                'U' => (0, 1),
                'D' => (0, -1),
                'L' => (-1, 0),
                _ => (1, 0)
            };

            var numSteps = int.Parse(step.Split(' ')[^1]);
            for (var i = 0; i < numSteps; i++)
            {
                prevHead = head;
                head = (head.Item1 + movement.Item1, head.Item2 + movement.Item2);
                if (GetDistance(head, tail) == 2 && (tail.Item1 == head.Item1 || tail.Item2 == head.Item2))
                {
                    tail = (tail.Item1 + movement.Item1, tail.Item2 + movement.Item2);
                }
                else if (GetDistance(head, tail) == 3)
                {
                    tail = prevHead;
                }

                visitedSpaces.Add(tail);
            }
        }

        return visitedSpaces.Count;
    }

    public static object PartTwo(string input)
    {
        var steps = input.Split(Environment.NewLine);
        (int x, int y)[] rope = Enumerable.Repeat((0, 0), 10).ToArray();
        var visitedSpaces = new HashSet<(int, int)>(7500) { rope.Last() };


        foreach (var step in steps)
        {
            (int x, int y) movement = step[0] switch
            {
                'U' => (0, 1),
                'D' => (0, -1),
                'L' => (-1, 0),
                _ => (1, 0)
            };

            var numSteps = int.Parse(step.Split(' ')[^1]);
            for (var curStep = 0; curStep < numSteps; curStep++)
            {
                // move Head;
                rope[0] = (rope[0].x + movement.x, rope[0].y + movement.y);
                for (var nodeIdx = 1; nodeIdx < 10; nodeIdx++)
                {
                    if (GetDistance(rope[nodeIdx - 1], rope[nodeIdx]) == 2 &&
                        (rope[nodeIdx].x == rope[nodeIdx - 1].x || rope[nodeIdx].y == rope[nodeIdx - 1].y))
                    {
                        rope[nodeIdx] = GetNeighbours(rope[nodeIdx]).FirstOrDefault(n => GetDistance(rope[nodeIdx - 1], n) == 1);
                    }
                    else if (GetDistance(rope[nodeIdx - 1], rope[nodeIdx]) >= 3)
                    {
                        if (rope[nodeIdx - 1].x > rope[nodeIdx].x)
                        {
                            rope[nodeIdx] = (rope[nodeIdx].x + 1, rope[nodeIdx].y); // move right
                        }
                        else
                        {
                            rope[nodeIdx] = (rope[nodeIdx].x - 1, rope[nodeIdx].y); // move left
                        }

                        if (rope[nodeIdx - 1].y > rope[nodeIdx].y)
                        {
                            rope[nodeIdx] = (rope[nodeIdx].x, rope[nodeIdx].y + 1); // move up
                        }
                        else
                        {
                            rope[nodeIdx] = (rope[nodeIdx].x, rope[nodeIdx].y - 1); // move down
                        }
                    }
                }

                visitedSpaces.Add(rope[9]);
            }
        }

        return visitedSpaces.Count;
    }

    private static int GetDistance((int x, int y) head, (int x, int y) tail)
    {
        var x = Math.Abs(tail.x - head.x);
        var y = Math.Abs(tail.y - head.y);
        return x + y;
    }

    private static IEnumerable<(int, int)> GetNeighbours((int x, int y) node)
    {
        var neighbours = new List<(int, int)>
        {
            new(node.x - 1, node.y),
            new(node.x + 1, node.y),
            new(node.x, node.y - 1),
            new(node.x, node.y + 1),
        };

        return neighbours;
    }
}