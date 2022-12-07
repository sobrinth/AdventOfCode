namespace AdventOfCode2022;

public class Day7
{
    public static int PartOne(string puzzleData)
    {
        return GetDirectories(puzzleData)
            .Where(x => x.Size <= 100000)
            .Sum(x => x.Size);
    }

    public static int PartTwo(string teststring)
    {
        const int total = 70000000;
        const int neededUnused = 30000000;

        var directories = GetDirectories(teststring);

        var minSizeToDelete = neededUnused - (total - directories[0].Size); // Directories[0] is '/'

        return directories
            .Where(x => x.Size > minSizeToDelete)
            .Min(x => x.Size);
    }

    private static List<Directory> GetDirectories(string teststring)
    {
        var lines = teststring.Split(Environment.NewLine);
        var currentPath = new Stack<string>(10);
        var directories = new List<Directory>(200);

        foreach (var line in lines)
        {
            switch (line)
            {
                case "$ cd ..":
                    currentPath.Pop();
                    break;
                case var _ when line.StartsWith("$ cd"):
                    var targetDir = line.Split(' ').Last();
                    currentPath.Push(targetDir);
                    var dirName = string.Join('/', currentPath);
                    if (directories.All(x => x.Path != dirName))
                    {
                        directories.Add(new Directory { Path = dirName });
                    }
                    break;
                case var _ when !line.StartsWith("dir") && !line.StartsWith("$ "):
                    directories.Where(x => string.Join('/', currentPath).Contains(x.Path)).ToList()
                        .ForEach(x => x.Size += int.Parse(line.Split(' ')[0]));
                    break;
            }
        }

        return directories;
    }

    private class Directory
    {
        public required string Path { get; set; }
        public int Size { get; set; }
    }
}