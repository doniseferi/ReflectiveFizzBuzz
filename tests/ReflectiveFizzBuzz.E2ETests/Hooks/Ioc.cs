using ReflectiveFizzBuzz.Domain.Repositories;

namespace ReflectiveFizzBuzz.E2ETests.Hooks;

using BoDi;
using Extensions;
using Handler;
using ReflectiveFizzBuzz.Domain.Services;
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

        _objectContainer.RegisterInstanceAs<IFizzBuzzService>(new FizzBuzzService(new RuleRepository(new IRule[]{new BuzzRule(), new FizzRule(), new FizzBuzzRule() })));
    }
}