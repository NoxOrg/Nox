namespace Nox.Solution.Tests;

public static class TestHelpers
{
    public static void RenameFilesInFolder(string path, string searchPattern, string targetExtension)
    {
        var files = Directory.GetFiles(path, searchPattern);
        foreach (var file in files)
        {
            var fullPath = Path.GetFullPath(file);
            var directory = Path.GetDirectoryName(fullPath);
            var name = Path.GetFileNameWithoutExtension(fullPath);
            File.Move(fullPath, Path.Combine(directory!, $"{name}.{targetExtension}"));
        }
    }
}