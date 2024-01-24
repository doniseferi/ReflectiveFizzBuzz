using ReflectiveFizzBuzz.Domain.Exception;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Rules;

internal class BuzzRule : IRule
{
    public bool IsApplicable(PositiveInteger number) => number.Value % 5 == 0 && number.Value % 3 != 0;
    public string Apply(PositiveInteger number) => 
        IsApplicable(number) 
            ? "Buzz" 
            : throw new ApplicationOfIncorrectRuleException(number, nameof(BuzzRule));
}