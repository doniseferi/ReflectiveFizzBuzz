namespace ReflectiveFizzBuzz.E2ETests.Extensions;

internal static class PathExtensions
{
    public static string GetConsoleAppExePath(this AppDomain appDomain)
    {
        var consoleApplicationName = "ReflectiveFizzBuzz.Infrastructure.Console";
        var currentDirectory = appDomain.BaseDirectory;
        var testFolder = @"\test";
        return currentDirectory.Contains(testFolder)
            ? Path.Combine(
                path1: currentDirectory[..currentDirectory.IndexOf(testFolder, StringComparison.Ordinal)],
                path2: $@"src\{consoleApplicationName}\bin\Debug\net8.0\{consoleApplicationName}.exe")
            : throw new DirectoryNotFoundException("Cannot find the applications base directory.");
    }
}