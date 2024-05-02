using System.Net;
using AutoMapper;
using MailSender.Constants;
using MailSender.DTOs.Requests;
using MailSender.DTOs.Responses;
using MailTrapClient.DTOs.Requests;
using MailTrapClient.Services;

namespace MailSender.Services;

public class EmailService(IMailClient mailTrapClient, IMapper mapper, IConfiguration configuration) : IEmailService
{
    public async Task<SendMailResponse> SendAsync(string token, MailSendRequest request)
    {
        if ((string.IsNullOrEmpty(request.Text) && string.IsNullOrEmpty(request.Html)) ||
            (!string.IsNullOrEmpty(request.Text) && !string.IsNullOrEmpty(request.Html)))
        {
            return new SendMailResponse
            {
                Message = ValidationMessages.TextOrHtmlRequired,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var mailTrapRequest = new SendRequest
        {
            MailParams = new MailParams
            {
                From = new Sender { Name = request.SenderName, Email = request.SenderEmail },
                To = [new Recipient { Name = request.RecipientName, Email = request.RecipientEmail }],
                Subject = request.Subject,
                Text = request.Text,
                Html = string.IsNullOrEmpty(request.Text) ? request.Html : null,
                Attachments = mapper.Map<Attachment[]>(request.Attachments)
            },
            Settings = new Settings
            {
                Token = token,
                Url = $"{configuration["MailTrap:SendBaseUrl"]}/send" 
            }
        };

        var mailTrapResponse = await mailTrapClient.SendAsync(mailTrapRequest);

        var response = mapper.Map<SendMailResponse>(mailTrapResponse);

        return response;
    }
}