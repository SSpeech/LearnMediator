using FluentValidation;
using LearnMediator.Abstractions.Errors;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Abstractions.Shared.Validations;
using MediatR;
using ValidationResult = LearnMediator.Abstractions.Shared.Validations.ValidationResult;

namespace LearnMediator.Abstractions.Shared.Behaviors;

public class ValidationPipeLineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipeLineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        Error[] errors = await GenerateErrorArray(request);

        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }
        return await next();
    }

    private async Task<Error[]> GenerateErrorArray(TRequest request)
    {
        var validationResults = await Task.WhenAll(_validators
            .Select(validator => validator.ValidateAsync(request)));

           return validationResults
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(
                failure.PropertyName,
                failure.ErrorMessage))
            .Distinct()
            .ToArray();
    }


    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        // reflection
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        object validationResult = CreateGenericValidationResultObject<TResult>(errors);

        return (TResult)validationResult;
    }

    private static object CreateGenericValidationResultObject<TResult>(Error[] errors) where TResult : Result
    {
        return typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])!
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, [errors])!;
    }
}
