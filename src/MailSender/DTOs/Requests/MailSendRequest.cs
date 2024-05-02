using System.ComponentModel.DataAnnotations;
using MailSender.Constants;

namespace MailSender.DTOs.Requests;

public class MailSendRequest
{
    [Required(ErrorMessage = ValidationMessages.SenderEmailRequired)]
    [EmailAddress]
    public string SenderEmail { get; set; }


    [Required(ErrorMessage = ValidationMessages.SenderNameRequired)]
    public string SenderName { get; set; }


    [Required(ErrorMessage = ValidationMessages.RecipientEmailRequired)]
    public string RecipientEmail { get; set; }


    [Required(ErrorMessage = ValidationMessages.RecipientNameRequired)]
    public string RecipientName { get; set; }


    [Required(ErrorMessage = ValidationMessages.SubjectRequired)]
    public string Subject { get; set; }

    public string? Text { get; set; }
    public string? Html { get; set; }
    public List<IFormFile>? Attachments { get; set; }
}