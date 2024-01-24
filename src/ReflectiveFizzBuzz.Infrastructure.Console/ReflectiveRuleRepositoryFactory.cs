using System.Reflection;
using ReflectiveFizzBuzz.Domain.Repositories;
using ReflectiveFizzBuzz.Domain.Rules;

namespace ReflectiveFizzBuzz.Infrastructure.Console;

internal class ReflectiveRuleRepositoryFactory
{
    public static IRuleRepository Create()
    {
        var rulesAssembly = Assembly.Load("ReflectiveFizzBuzz.Domain");

        var allRules = rulesAssembly.GetTypes()
            .Where(t => typeof(IRule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Where(t => t.IsClass && t.IsNotPublic) 
            .Where(t => t.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null) != null) // Default constructor
            .ToList();

        var rules = allRules
            .Select(type => (IRule)Activator.CreateInstance(
                type: type,
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                binder: null,
                args: Array.Empty<object>(),
                culture: null)).ToList();

        return new RuleRepository(rules);
    }
}