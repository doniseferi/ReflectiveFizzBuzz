using ReflectiveFizzBuzz.Domain.ValueTypes;

namespace ReflectiveFizzBuzz.Domain.Exception;

internal class ApplicationOfIncorrectRuleException(PositiveInteger number, string ruleName)
    : System.Exception(message: $"Cannot apply {ruleName} to number: {number.Value}");