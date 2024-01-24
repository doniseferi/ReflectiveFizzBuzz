// See https://aka.ms/new-console-template for more information

using ReflectiveFizzBuzz.Domain.Services;
using ReflectiveFizzBuzz.Domain.ValueTypes;
using ReflectiveFizzBuzz.Infrastructure.Console;

var fizzBuzzService = new FizzBuzzService(ReflectiveRuleRepositoryFactory.Create());
Enumerable.Range(1, 100)
    .Select(x => fizzBuzzService.Classify(new PositiveInteger(x)))
    .ToList()
    .ForEach(Console.WriteLine);
