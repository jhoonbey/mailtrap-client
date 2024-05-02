using System.Net;
using MailSender.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MailSender.Controllers;

public class BaseApiController : ControllerBase
{
    /// <summary>
    /// MapResponse
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    protected ActionResult MapResponse(BaseResponse response)
    {
        if (response.Success)
        {
            return Ok(response);
        }

        var problemDetails = new ValidationProblemDetails
        {
            Type = "string",
            Title = response.StatusCode.ToString(),
            Status = (int)response.StatusCode,
            Errors = new Dictionary<string, string[]> { { "Message", [response.Message] } },
            Instance = $"{HttpContext.Request.Method} {HttpContext.Request.Path}"
        };

        ActionResult result = response.StatusCode switch
        {
            HttpStatusCode.NotFound => NotFound(problemDetails),
            HttpStatusCode.BadRequest => BadRequest(problemDetails),
            HttpStatusCode.Unauthorized => Unauthorized(problemDetails),
            HttpStatusCode.Forbidden => Forbid(),
            _ => StatusCode((int)HttpStatusCode.InternalServerError),
        };

        return result;
    }
}