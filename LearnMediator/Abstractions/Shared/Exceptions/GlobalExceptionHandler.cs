using LearnMediator.Abstractions.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnMediator.Abstractions.Shared.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is ArgumentException)
        {
            await CreateArgumentExceptionResponse(httpContext, exception, cancellationToken);
            return true;
        }

        await CreateOtherExceptionsResponse(httpContext, exception, cancellationToken);
        return true;
    }

    private async Task CreateArgumentExceptionResponse(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "ArgumentException occurred: {0}", exception.Message);

         ProblemDetails problemDetails = CreateProblemDetails("Validation Error",
                                                  StatusCodes.Status400BadRequest,
                                                  exception,
                                                  ErrorType.BadRequest.Type);

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }  
    private async Task CreateOtherExceptionsResponse(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An error occurred: {0}", exception.Message);

      ProblemDetails problemDetails = CreateProblemDetails("Internal Server Error",
                                                  StatusCodes.Status500InternalServerError,
                                                  exception,
                                                  ErrorType.InternalError.Type);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }

    private static ProblemDetails CreateProblemDetails(string title, int status, Exception exception, string type)
    {
        return new()
        {
            Title = title,
            Type = type,
            Detail = exception.Message,
            Status = status,

        };
    }
}
