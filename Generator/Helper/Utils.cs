using System.IO;
using System.Linq;

namespace Generator.Helper;

public static class Utils
{
    public static string GetSolutionDirectory(string currentPath = null)
    {
        var directory = new DirectoryInfo(
            currentPath ?? Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }
        return directory.FullName;
    }
}
