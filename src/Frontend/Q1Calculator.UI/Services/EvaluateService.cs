namespace Q1Calculator.UI.HostBuilder;

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class EvaluateService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<EvaluateService> _logger;

    public EvaluateService(IHttpClientFactory httpClientFactory, ILogger<EvaluateService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("EvaluateClient");
        _logger = logger;
    }

    public async Task<string> EvaluateAsync(string query)
    {
        try
        {
            query = query.Replace(" ", "");
            var response = await _httpClient.GetAsync($"evaluate?calculation={query}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "An error occurred while evaluating the expression.");
            return "Error";
        }
    }
}
