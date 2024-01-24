using ReflectiveFizzBuzz.Domain.Exception;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Rules;

internal class FizzRule : IRule
{
    public bool IsApplicable(PositiveInteger number) => number.Value % 3 == 0 && number.Value % 5 != 0;
    public string Apply(PositiveInteger number) =>
        IsApplicable(number)
            ? "Fizz"
            : throw new ApplicationOfIncorrectRuleException(number, nameof(BuzzRule));
}