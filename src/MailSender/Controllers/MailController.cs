using MailSender.DTOs.Requests;
using MailSender.DTOs.Responses;
using MailSender.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MailSender.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MailController(IEmailService emailService) : BaseApiController
{
    /// <summary>
    ///  Send mail via MailTrap
    /// </summary>
    [HttpPost]
    [SwaggerResponse(200, "", Type = typeof(SendMailResponse))]
    [SwaggerResponse(400, "", Type = typeof(ValidationProblemDetails))]
    [SwaggerResponse(401, "", Type = typeof(ValidationProblemDetails))]
    [SwaggerResponse(403, "", Type = typeof(ValidationProblemDetails))]
    [SwaggerResponse(500, "", Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> SendAsync([FromHeader] string token, [FromForm] MailSendRequest request)
    {
        var response = await emailService.SendAsync(token, request);
        return MapResponse(response);
    }
}