namespace AdventOfCode2022;

public class Day6
{
    public static int PartOne(string teststring, int sequenceLength = 4)
    {

        var charWindow = new Queue<char>(sequenceLength + 1);
        for (var i = 0; i < teststring.Length; i++)
        {
            charWindow.Enqueue(teststring[i]);
            if (charWindow.Count > sequenceLength)
            {
                charWindow.Dequeue();
            }

            if (charWindow.Distinct().Count() == sequenceLength)
            {
                return i + 1;
            }
        }

        return -1;
    }

    public static int PartTwo(string teststring)
    {
        return PartOne(teststring, 14);
    }
}