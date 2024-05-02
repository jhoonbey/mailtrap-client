namespace MailTrapClient.DTOs.Requests;

public class SendRequest
{
    public MailParams MailParams { get; set; }
    public Settings Settings { get; set; }
}