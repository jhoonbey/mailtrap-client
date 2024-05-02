using MailSender.DTOs.Requests;
using MailSender.DTOs.Responses;

namespace MailSender.Services;

public interface IEmailService
{
    Task<SendMailResponse> SendAsync(string token, MailSendRequest request);
}