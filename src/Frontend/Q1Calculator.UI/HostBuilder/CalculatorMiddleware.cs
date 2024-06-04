namespace Q1Calculator.UI.HostBuilder;

public class CalculatorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;

    public CalculatorMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory)
    {
        _next = next;
        _httpClientFactory = httpClientFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var httpClient = _httpClientFactory.CreateClient("HttpCalculatorClient");
        var httpsClient = _httpClientFactory.CreateClient("HttpsCalculatorClient");

        var addResponseHttp = await httpClient.GetAsync("add?number1=5&number2=3");
        var addContentHttp = await addResponseHttp.Content.ReadAsStringAsync();
        Console.WriteLine($"HTTP Add Result: {addContentHttp}");

        var addResponseHttps = await httpsClient.GetAsync("add?number1=5&number2=3");
        var addContentHttps = await addResponseHttps.Content.ReadAsStringAsync();
        Console.WriteLine($"HTTPS Add Result: {addContentHttps}");

        await _next(context);
    }
}
