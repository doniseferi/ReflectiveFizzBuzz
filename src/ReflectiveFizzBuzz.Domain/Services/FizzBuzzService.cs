using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Services;

internal class FizzBuzzService : IFizzBuzzService
{
    private readonly IRuleRepository _ruleRepository;

    public FizzBuzzService(IRuleRepository ruleRepository)
    {
        ArgumentNullException.ThrowIfNull(ruleRepository);

        _ruleRepository = ruleRepository;
    }

    public string Classify(PositiveInteger number) => _ruleRepository.Get(number).Apply(number);
}