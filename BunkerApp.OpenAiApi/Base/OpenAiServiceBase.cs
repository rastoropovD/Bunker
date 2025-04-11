using System.Text;
using System.Text.Json;

namespace BunkerApp.OpenAiApi.Base;

public abstract class OpenAiServiceBase<TResult> : IOpenAiService<TResult>
{
    protected abstract string RequestPrompt { get; }

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    
    protected OpenAiServiceBase(HttpClient httpClient, string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = httpClient;
    }
    
    protected abstract TResult Map(string? rawData);
    
    public async Task<TResult> Generate()
    {
        string? rawData = await SendRequest();
        
        return Map(rawData);
    }

    private async Task<string?> SendRequest()
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = RequestPrompt }
            },
            temperature = 0.8
        };
        
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        request.Headers.Add("Authorization", $"Bearer {_apiKey}");
        request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        string responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(responseBody);
        string? result = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return result;
    }

   
}