using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ClasificadorComents.Services
{ 
public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "TU_API_KEY"; // Reemplázala

    public OpenAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<float>> ObtenerEmbeddingAsync(string texto)
    {
        var url = "https://api.openai.com/v1/embeddings";

        var requestBody = new
        {
            input = texto,
            model = "text-embedding-3-small"
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.PostAsync(url, content);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error: {response.StatusCode} - {responseContent}");

        using JsonDocument json = JsonDocument.Parse(responseContent);
        var embedding = json.RootElement
            .GetProperty("data")[0]
            .GetProperty("embedding")
            .EnumerateArray()
            .Select(x => x.GetSingle())
            .ToList();

        return embedding;
    }
}
}



