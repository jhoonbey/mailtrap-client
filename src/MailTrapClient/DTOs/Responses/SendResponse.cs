using System.Net;
using System.Text.Json.Serialization;

namespace MailTrapClient.DTOs.Responses;

public class SendResponse
{
    [JsonPropertyName("success")] public bool Success { get; set; }

    [JsonPropertyName("errors")] public string[] Errors { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}