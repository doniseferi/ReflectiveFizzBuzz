using ReflectiveFizzBuzz.Domain;
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
    }

    [Given(@"the application is started")]
    public void GivenTheApplicationIsStarted()
    {
    }

    [When(@"I run the console application")]
    public async Task WhenIRunTheConsoleApplication() => _resultFromConsole = await _systemUnderTestExecutionHandler.ExecuteAsync();

    [When(@"the application calculates the FizzBuzz sequence for numbers from 1 to 100")]
    public void WhenTheApplicationCalculatesTheFizzBuzzSequences()
    {
    }

    [Then(@"I should see the correct FizzBuzz sequence in the console")]
    public void ThenIShouldSeeTheCorrectFizzBuzzSequenceInTheConsole() =>
        Enumerable.Range(1, 100)
            .Select(x => x)
            .ToList()
            .ForEach(number => Assert.Contains(
                _fizzBuzzService.Classify(
                    new PositiveInteger(number)), 
                _resultFromConsole.ConsoleOutput));
}
