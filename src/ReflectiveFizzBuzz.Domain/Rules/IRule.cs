using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Rules;

internal interface IRule
{
    bool IsApplicable(PositiveInteger number);
    string Apply(PositiveInteger number);
}