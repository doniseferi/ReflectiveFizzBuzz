using ReflectiveFizzBuzz.Domain;

namespace ReflectiveFizzBuzz.E2ETests.Hooks;

using BoDi;
using Extensions;
using Handler;
using TechTalk.SpecFlow;

[Binding]
public class Ioc
{
    private readonly IObjectContainer _objectContainer;

    public Ioc(IObjectContainer objectContainer) => _objectContainer = objectContainer;

    [BeforeScenario]
    public void RegisterComponents()
    {
        _objectContainer.RegisterInstanceAs(
            new SystemUnderTestExecutionHandler(
                AppDomain.CurrentDomain.GetConsoleAppExePath()));

        _objectContainer.RegisterTypeAs<FizzBuzzService, IFizzBuzzService>();
    }
}