using ReflectiveFizzBuzz.E2ETests.Records;
using System.Diagnostics;
using System.Text;

namespace ReflectiveFizzBuzz.E2ETests.Handler;

internal class SystemUnderTestExecutionHandler
{
    private readonly string _applicationExePath;

    public SystemUnderTestExecutionHandler(string applicationPath)
    {
        _applicationExePath = !string.IsNullOrWhiteSpace(applicationPath)
            ? applicationPath
            : throw new ArgumentNullException(nameof(applicationPath));
    }

    public async Task<ConsoleApplicationExecutionResult> ExecuteAsync()
    {
        var process = CreateExecutionProcess();

        var consoleOutput = new StringBuilder();

        process.OutputDataReceived += (_, e) =>
        {
            consoleOutput.Append(string.IsNullOrWhiteSpace(e?.Data)
                ? string.Empty
                : e.Data + Environment.NewLine);
        };

        process.Start();
        process.BeginOutputReadLine();
        await process.WaitForExitAsync();
        return new(process.ExitCode, consoleOutput.ToString());
    }

    private Process CreateExecutionProcess() =>
        new()
        {
            StartInfo = new()
            {
                FileName = _applicationExePath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
}