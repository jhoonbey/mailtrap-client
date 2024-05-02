namespace MailTrapClient.DTOs.Requests;

public class MailParams
{
    public Recipient[] To { get; set; }
    public Recipient[] Cc { get; set; }
    public Recipient[] Bcc { get; set; }
    public Sender From { get; set; }
    public Attachment[] Attachments { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public string Html { get; set; }

    public string Category { get; set; }
}