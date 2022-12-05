namespace AdventOfCode2022;

public class Day2
{
    public static int CalculateScorePartOne(string rounds)
    {
        var games = rounds.Split(Environment.NewLine)
            .Select(x => x.Split(' '))
            .Select(y => (y[0], y[1]))
            .ToList();

        var score = 0;
        foreach (var (opponent, player) in games)
        {
            score += (opponent, player) switch
            {
                ("A", "X") => 4,
                ("A", "Y") => 8,
                ("A", "Z") => 3,
                ("B", "X") => 1,
                ("B", "Y") => 5,
                ("B", "Z") => 9,
                ("C", "X") => 7,
                ("C", "Y") => 2,
                ("C", "Z") => 6,
                _ => 0
            };
        }

        return score;
    }

    public static object CalculateScorePartTwo(string rounds)
    {
        var games = rounds.Split(Environment.NewLine)
            .Select(x => x.Split(' '))
            .Select(y => (y[0], y[1]))
            .ToList();

        var score = 0;
        foreach (var (opponent, player) in games)
        {
            score += (opponent, player) switch
            {
                // Now it is: X=lose, Y=draw, Z=win
                ("A", "X") => 3,
                ("A", "Y") => 4,
                ("A", "Z") => 8,
                ("B", "X") => 1,
                ("B", "Y") => 5,
                ("B", "Z") => 9,
                ("C", "X") => 2,
                ("C", "Y") => 6,
                ("C", "Z") => 7,
                _ => 0
            };
        }

        return score;
    }
}