using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using MailTrapClient.DTOs.Requests;
using MailTrapClient.DTOs.Responses;

namespace MailTrapClient.Services;

public class MailClient(HttpClient httpClient) : IMailClient
{
    public async Task<SendResponse> SendAsync(SendRequest request)
    {
        // set header
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + request.Settings.Token);

        // set content
        var jsonRequest = JsonSerializer.Serialize(request.MailParams);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        // send request
        var apiResponse = await httpClient.PostAsync(request.Settings.Url, content);
        var response = await apiResponse.Content.ReadFromJsonAsync<SendResponse>(CancellationToken.None);
        if (response == null)
        {
            throw new Exception("Internal error. Please, contact support");
        }

        response.StatusCode = apiResponse.StatusCode;

        return response;
    }
}