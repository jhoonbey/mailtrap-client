namespace MailSender.Constants;

public class ValidationMessages
{
    public const string ErrorOccurred = "Unexpected error occurred. Retry later or contact support";
    public const string SenderEmailRequired = "Sender email required";
    public const string SenderNameRequired = "Sender name required";
    public const string RecipientEmailRequired = "Recipient email required";
    public const string RecipientNameRequired = "Recipient name required";
    public const string SubjectRequired = "Subject required";
    public const string TextOrHtmlRequired = "Only one of Text and Html is required";
}