namespace ReflectiveFizzBuzz.Domain.ValueTypes;

public class PositiveInteger
{
    public PositiveInteger(int value)
    {
        if (value == 0)
            throw new ArgumentException("Value must be greater than zero.", nameof(value));

        Value = value;
    }

    public int Value { get; } 
}