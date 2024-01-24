using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Services;

internal class FizzBuzzService : IFizzBuzzService
{
    public string Classify(PositiveInteger number) => number.Value.ToString();
}