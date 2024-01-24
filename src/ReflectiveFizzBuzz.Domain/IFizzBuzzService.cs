using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ReflectiveFizzBuzz.Domain.UnitTests"),
           InternalsVisibleTo("ReflectiveFizzBuzz.E2ETests")]

namespace ReflectiveFizzBuzz.Domain;


internal interface IFizzBuzzService
{
    string Classify(PositiveInteger number);
}

internal class FizzBuzzService : IFizzBuzzService
{
    public string Classify(PositiveInteger number) =>
        number.Value.ToString();
}