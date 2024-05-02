using System.Net;
using MailSender.Constants;
using MailSender.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MailSender.Middleware;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError("Exception occurred: {@exception}", exception.GetOriginalException().Message);

        var problemDetails = new ValidationProblemDetails
        {
            Type = exception.GetType().Name,
            Title = ValidationMessages.ErrorOccurred,
            Status = (int)HttpStatusCode.InternalServerError,
            Errors = new Dictionary<string, string[]> { { "Message", [exception.Message] } },
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}