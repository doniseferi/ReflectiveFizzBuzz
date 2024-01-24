using ReflectiveFizzBuzz.Domain.Repositories;

namespace ReflectiveFizzBuzz.E2ETests.Hooks;

using BoDi;
using Extensions;
using Handler;
using Domain.Rules;
using Domain.Services;
using TechTalk.SpecFlow;

[Binding]
public class Ioc(IObjectContainer objectContainer)
{
    [BeforeScenario]
    public void RegisterComponents()
    {
        objectContainer.RegisterInstanceAs(
            new SystemUnderTestExecutionHandler(
                AppDomain.CurrentDomain.GetConsoleAppExePath()));

        objectContainer.RegisterInstanceAs<IFizzBuzzService>(new FizzBuzzService(new RuleRepository(new IRule[]{new BuzzRule(), new FizzRule(), new FizzBuzzRule() })));
    }
}