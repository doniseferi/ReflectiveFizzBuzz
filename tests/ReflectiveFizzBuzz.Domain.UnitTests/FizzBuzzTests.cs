namespace ReflectiveFizzBuzz.Domain.UnitTests;

public class FizzBuzzTests
{
    private readonly IFizzBuzzService _fizzBuzzService = new FizzBuzzService();


    [Fact]
    public void ReturnsFizzForMultiplesOfThree()
    {
        var multiplesOfThree = GetMultiplesOf(3);
        Assert.All(multiplesOfThree, number => Assert.Equal("Fizz", _fizzBuzzService.Classify(number)));
    }

    [Fact]
    public void ReturnsBuzzForMultiplesOfFive()
    {
        var multiplesOfFive = GetMultiplesOf(5);
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

    private List<PositiveInteger> GetMultiplesOf(uint divisor) =>
        Enumerable.Range(1, 100)
            .Select(x => x) 
            .Where(x => x % divisor == 0)
            .Select(x => new PositiveInteger(x)) 
            .ToList();
}