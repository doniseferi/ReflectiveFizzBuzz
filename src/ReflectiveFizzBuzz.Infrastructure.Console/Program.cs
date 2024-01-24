// See https://aka.ms/new-console-template for more information

using ReflectiveFizzBuzz.Domain.Repositories;
using ReflectiveFizzBuzz.Domain.Services;
using ReflectiveFizzBuzz.Domain.ValueTypes;

var fizzBuzzService = new FizzBuzzService(new RuleRepository(new IRule[] { new BuzzRule(), new FizzRule(), new FizzBuzzRule() }));
Enumerable.Range(1, 100)
    .Select(x => fizzBuzzService.Classify(new PositiveInteger(x)))
    .ToList()
    .ForEach(Console.WriteLine);
