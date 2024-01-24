using ReflectiveFizzBuzz.Domain.Repositories;
using ReflectiveFizzBuzz.Domain.Services;
using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.UnitTests;

public class FizzBuzzTests
{
    private readonly IFizzBuzzService _fizzBuzzService = new FizzBuzzService(new RuleRepository(new IRule[] {new BuzzRule(), new FizzRule(), new FizzBuzzRule()}));


    [Fact]
    public void ReturnsFizzForMultiplesOfThree()
    {
        var multiplesOfThree = GetMultiplesOf3();
        Assert.All(multiplesOfThree, number => Assert.Equal("Fizz", _fizzBuzzService.Classify(number)));
    }

    [Fact]
    public void ReturnsBuzzForMultiplesOfFive()
    {
        var multiplesOfFive = GetMultiplesOf5();
        Assert.All(multiplesOfFive, number => Assert.Equal("Buzz", _fizzBuzzService.Classify(number)));
    }

    [Fact]
    public void ReturnsFizzBuzzForMultiplesOfThreeAndFive()
    {
        var multiplesOfThreeAndFive = Enumerable.Range(1, 100).Where(x => x % 15 == 0).ToList();
        Assert.All(multiplesOfThreeAndFive, number => Assert.Equal(
            "FizzBuzz", 
            _fizzBuzzService
                .Classify(
                    new PositiveInteger(number))));
    }

    [Fact]
    public void ReturnsNumberForNonMultiplesOfThreeOrFive()
    {
        var nonMultiplesOfThreeOrFive = Enumerable.Range(1, 100).Where(x => x % 3 != 0 && x % 5 != 0).ToList();
        Assert.All(
            nonMultiplesOfThreeOrFive, 
            number => Assert.Equal(
                number.ToString(), 
                _fizzBuzzService.Classify(
                    new PositiveInteger(number))));
    }


    private IReadOnlyList<PositiveInteger> GetMultiplesOf3() => 
        GetMultiplesOf(3)
            .Where(x => x.Value % 5 != 0)
        .ToList();

    private IReadOnlyList<PositiveInteger> GetMultiplesOf5() =>
        GetMultiplesOf(5)
            .Where(x => x.Value % 3 != 0)
            .ToList();


    private IReadOnlyList<PositiveInteger> GetMultiplesOf(int divisor) =>
        Enumerable.Range(1, 100)
            .Select(x => x) 
            .Where(x => x % divisor == 0)
            .Select(x => new PositiveInteger(x)) 
            .ToList();
}