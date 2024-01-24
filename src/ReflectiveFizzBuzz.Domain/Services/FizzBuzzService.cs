using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Services;

internal class FizzBuzzService : IFizzBuzzService
{
    public string Classify(PositiveInteger number) =>
        number .Value switch
        {
            var value when value % 15 == 0 => "FizzBuzz",
            var value when value % 3 == 0 => "Fizz",
            var value when value % 5 == 0 => "Buzz",
            _ => number.Value.ToString()
        };
}