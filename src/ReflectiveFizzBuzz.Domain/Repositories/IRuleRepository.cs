using LanguageExt;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Repositories;

internal interface IRuleRepository
{
    Option<IRule> Get(PositiveInteger number);
}

internal class RuleRepository : IRuleRepository
{
    private readonly IEnumerable<IRule> _rules;

    public RuleRepository(IEnumerable<IRule> rules)
    {
        ArgumentNullException.ThrowIfNull(rules);

        _rules = rules;
    }

    public Option<IRule> Get(PositiveInteger number)
    {
        var rule = _rules.FirstOrDefault(x => x.IsApplicable(number));
        return rule == null ? Option<IRule>.None : Option<IRule>.Some(rule);
    }
}

internal interface IRule
{
    bool IsApplicable(PositiveInteger number);
    string Apply(PositiveInteger number);
}


internal class FizzBuzzRule : IRule
{
    public bool IsApplicable(PositiveInteger number) => number.Value % 3 == 0 && number.Value % 5 == 0;
    public string Apply(PositiveInteger number) => "FizzBuzz";
}

internal class FizzRule : IRule
{
    public bool IsApplicable(PositiveInteger number) => number.Value % 3 == 0 && number.Value % 5 != 0;
    public string Apply(PositiveInteger number) => "Fizz";
}

internal class BuzzRule : IRule
{
    public bool IsApplicable(PositiveInteger number) => number.Value % 5 == 0 && number.Value % 3 != 0;
    public string Apply(PositiveInteger number) => "Buzz";
}

