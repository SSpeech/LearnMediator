namespace LearnMediator.Abstractions.Errors;

public record Error(string Code, string Message)
{
    public static Error NullValue = new("Error.NullValue", "Null value was provided");

    public static Error None = new(string.Empty, string.Empty);

}
