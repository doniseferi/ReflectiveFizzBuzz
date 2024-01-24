using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Repositories;

internal interface IRuleRepository
{
    IRule Get(PositiveInteger number);
}

public interface IRule
{
    bool IsApplicable(PositiveInteger number);
    string Apply(PositiveInteger number);
}
