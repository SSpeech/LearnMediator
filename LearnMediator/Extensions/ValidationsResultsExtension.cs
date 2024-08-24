using LearnMediator.Abstractions.Errors;
using LearnMediator.Abstractions.Shared.Results;
using LearnMediator.Abstractions.Shared.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LearnMediator.Extensions
{
    public static class ValidationsResultsExtension
    {


        public static IActionResult HandleFailure(this Result result)
        {
            return result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),

                IValidationResult validationResult =>
                new BadRequestObjectResult(
                    CreateProblemDetails(
                        "Validation Error",
                        StatusCodes.Status400BadRequest,
                        result.Error,
                        ErrorType.BadRequest.Type,
                        validationResult.Errors)),

                _ => new BadRequestObjectResult(CreateProblemDetails(
                        "Validation Error",
                        StatusCodes.Status400BadRequest,
                        result.Error,
                        ErrorType.BadRequest.Type
                       ))
            };
        }

        private static ProblemDetails CreateProblemDetails(string title, int status, Error error, string type, Error[]? errors = null)
        {
            return new()
            {
                Title = title,
                Type = type,
                Detail = error.Message,
                Status = status,
                Extensions = { { nameof(errors), errors } }

            };
        }
    }
}
