namespace AdventOfCode2022;

public class Day8
{
    private static List<int[]> ParseData(List<string> input)
    {
        List<int[]> data = new(50);
        foreach (var s in input)
        {
            var arr = new int[s.Length];
            for (var i = 0; i < s.Length; i++) arr[i] = s[i] - '0' + 1;
            data.Add(arr);
        }

        return data;
    }

    public static int PartOne(string input)
    {
        var treeGrid = ParseData(input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList());
        var dim = treeGrid.Count - 1;
        var visible = treeGrid.Select(s => new int[treeGrid[0].Length]).ToList();
        var length = treeGrid.Count;
        var visibleTrees = 0;
        for (var i = 0; i < length; i++)
        {
            var maxLeftRight = 0;
            var maxRightLeft = 0;
            var maxTopBot = 0;
            var maxBotTop = 0;
            for (var j = 0; j < length; j++)
            {
                if (treeGrid[i][j] > maxLeftRight)
                {
                    maxLeftRight = treeGrid[i][j];
                    visible[i][j] = 1;
                }

                if (treeGrid[i][dim - j] > maxRightLeft)
                {
                    maxRightLeft = treeGrid[i][dim - j];
                    visible[i][dim - j] = 1;
                }

                if (treeGrid[j][i] > maxTopBot)
                {
                    maxTopBot = treeGrid[j][i];
                    visible[j][i] = 1;
                }

                if (treeGrid[dim - j][i] > maxBotTop)
                {
                    maxBotTop = treeGrid[dim - j][i];
                    visible[dim - j][i] = 1;
                }
            }
        }

        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < length; j++)
            {
                visibleTrees += visible[i][j];

            }
        }
        return visibleTrees;
    }

    public static int PartTwo(string input)
    {
        var treeGrid = ParseData(input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList());
        var maxScenicScore = 0;
        var len = treeGrid.Count;
        for (var x = 0; x < len; x++)
        {
            for (var y = 0; y < len; y++)
            {
                var tmp = 0;
                var scenicScore = 1;
                for (var i = x - 1; i >= 0; i--)
                {
                    tmp++;
                    if (treeGrid[i][y] >= treeGrid[x][y]) break;
                }

                scenicScore *= tmp;
                tmp = 0;
                for (var i = x + 1; i < len; i++)
                {
                    tmp++;
                    if (treeGrid[i][y] >= treeGrid[x][y]) break;
                }

                scenicScore *= tmp;
                tmp = 0;
                for (var i = y - 1; i >= 0; i--)
                {
                    tmp++;
                    if (treeGrid[x][i] >= treeGrid[x][y]) break;
                }

                scenicScore *= tmp;
                tmp = 0;
                for (var i = y + 1; i < len; i++)
                {
                    tmp++;
                    if (treeGrid[x][i] >= treeGrid[x][y]) break;
                }

                scenicScore *= tmp;
                if (scenicScore > maxScenicScore)
                {
                    maxScenicScore = scenicScore;
                }
            }
        }

        return maxScenicScore;
    }
}