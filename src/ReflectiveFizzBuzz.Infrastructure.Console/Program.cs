// See https://aka.ms/new-console-template for more information

using ReflectiveFizzBuzz.Domain.Services;
using ReflectiveFizzBuzz.Domain.ValueTypes;

var fizzBuzzService = new FizzBuzzService();
Enumerable.Range(1, 100)
    .Select(x => fizzBuzzService.Classify(new PositiveInteger(x)))
    .ToList()
    .ForEach(Console.WriteLine);
