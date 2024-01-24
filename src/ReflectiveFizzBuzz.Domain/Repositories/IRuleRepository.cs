using LanguageExt;
using ReflectiveFizzBuzz.Domain.Rules;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Repositories;

internal interface IRuleRepository
{
    Option<IRule> Get(PositiveInteger number);
}