namespace LearnMediator.Abstractions.Errors;

public record ErrorType(string Type)
{
    public static ErrorType BadRequest = new("https://tools.ietf.org/html/rfc7231#section-6.5.1");
    public static ErrorType InternalError = new("https://tools.ietf.org/html/rfc7231#section-6.6.1");
}