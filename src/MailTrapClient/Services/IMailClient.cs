using MailTrapClient.DTOs.Requests;
using MailTrapClient.DTOs.Responses;

namespace MailTrapClient.Services;

public interface IMailClient
{
    Task<SendResponse> SendAsync(SendRequest request);
}