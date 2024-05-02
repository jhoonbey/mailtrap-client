using System.Net;
using AutoMapper;
using MailSender.DTOs.Requests;
using MailSender.DTOs.Responses;
using MailSender.Services;
using MailTrapClient.DTOs.Requests;
using MailTrapClient.DTOs.Responses;
using MailTrapClient.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace MailSender.Tests;

public class EmailServiceTests
{
    private EmailService _emailService;
    private Mock<IMailClient> _mockMailClient;
    private Mock<IMapper> _mockMapper;
    private Mock<IConfiguration> _mockConfiguration;


    [SetUp]
    public void Setup()
    {
        _mockMailClient = new Mock<IMailClient>();
        _mockMapper = new Mock<IMapper>();
        _mockConfiguration = new Mock<IConfiguration>();
        _emailService = new EmailService(_mockMailClient.Object, _mockMapper.Object, _mockConfiguration.Object);
    }

    [Test]
    public async Task SendAsync_WithValidRequest_ShouldReturnSuccessResponse()
    {
        // Arrange
        var token = "validToken";
        var request = new MailSendRequest
        {
            SenderName = "MailTrap test",
            SenderEmail = "MailTrap@demo.com",
            RecipientName = "jeyhun",
            RecipientEmail = "jeyhun@demo.com",
            Subject = "My Test Subject",
            Text = "My Test Text"
        };

        var sendMailResponse = new SendMailResponse
        {
            StatusCode = HttpStatusCode.OK,
            Success = true,
            Message = "OK"
        };

        _mockMailClient.Setup(x => x.SendAsync(It.IsAny<SendRequest>()))
            .ReturnsAsync(new SendResponse { StatusCode = HttpStatusCode.OK, Success = true });

        _mockMapper.Setup(m => m.Map<SendMailResponse>(It.IsAny<SendResponse>())).Returns(sendMailResponse);

        // Act
        var response = await _emailService.SendAsync(token, request);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Success, Is.True);
        });
    }

    [Test]
    public async Task SendAsync_WhenMailClientReturnsNonSuccessStatusCode_ShouldReturnErrorResponse()
    {
        // Arrange
        var token = "validToken";
        var request = new MailSendRequest
        {
            SenderName = "MailTrap test",
            SenderEmail = "MailTrap@demo.com",
            RecipientName = "jeyhun",
            RecipientEmail = "jeyhun@demo.com",
            Subject = "My Test Subject",
            Text = "My Test Text"
        };

        var errorResponse = new SendResponse
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Success = false,
            Errors = ["Mail server error"]
        };

        var sendMailResponse = new SendMailResponse
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Success = false,
            Message = "Mail server error"
        };

        _mockMailClient.Setup(x => x.SendAsync(It.IsAny<SendRequest>()))
            .ReturnsAsync(errorResponse);

        _mockMapper.Setup(m => m.Map<SendMailResponse>(It.IsAny<SendResponse>())).Returns(sendMailResponse);

        // Act
        var response = await _emailService.SendAsync(token, request);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.Success, Is.False);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        });
        Assert.That(response.Message, Is.Not.Null);
        Assert.That(response.Message, Is.EqualTo("Mail server error"));
    }
}