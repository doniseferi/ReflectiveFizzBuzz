using LanguageExt;
using ReflectiveFizzBuzz.Domain.Rules;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Repositories;

/* in ddd the repo is in the domain and the implementation is in the infrastructure or data layer
 * but for the sake of simplicity it's here as there is no io operations
*/
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