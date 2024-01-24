using ReflectiveFizzBuzz.Domain;
using ReflectiveFizzBuzz.Domain.Services;
using ReflectiveFizzBuzz.Domain.ValueTypes;
using ReflectiveFizzBuzz.E2ETests.Handler;
using ReflectiveFizzBuzz.E2ETests.Records;
using TechTalk.SpecFlow;

namespace ReflectiveFizzBuzz.E2ETests;

[Binding]
class FizzBuzzSteps
{
    private readonly SystemUnderTestExecutionHandler _systemUnderTestExecutionHandler;
    private readonly IFizzBuzzService _fizzBuzzService;
    private ConsoleApplicationExecutionResult _resultFromConsole;

    public FizzBuzzSteps(
        SystemUnderTestExecutionHandler systemUnderTestExecutionHandler, 
        IFizzBuzzService fizzBuzzService)
    {
        ArgumentNullException.ThrowIfNull(systemUnderTestExecutionHandler);
        ArgumentNullException.ThrowIfNull(fizzBuzzService);

        _systemUnderTestExecutionHandler = systemUnderTestExecutionHandler;
        _fizzBuzzService = fizzBuzzService;
    }

    [Given(@"the application is started")]
    public void GivenTheApplicationIsStarted()
    {
    }

    [When(@"the application calculates the FizzBuzz sequence for numbers from 1 to 100")]
    public async Task WhenTheApplicationCalculatesTheFizzBuzzSequences() => _resultFromConsole = await _systemUnderTestExecutionHandler.ExecuteAsync();

    [Then(@"I should see the correct FizzBuzz sequence in the console")]
    public void ThenIShouldSeeTheCorrectFizzBuzzSequenceInTheConsole()
    {
        var fizzBuzzResults =
            Enumerable.Range(1, 100)
                .Select(x => _fizzBuzzService.Classify(new PositiveInteger(x)));

        var expectedConsoleOutput = string.Join(
            Environment.NewLine, 
            fizzBuzzResults) + Environment.NewLine;


        Assert.Equal(expectedConsoleOutput, _resultFromConsole.ConsoleOutput);
    }
}
