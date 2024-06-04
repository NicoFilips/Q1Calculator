using System.Net.Http.Headers;
using System.Security.Authentication;

namespace Q1Calculator.UI.HostBuilder;

public static class HttpClientExtensions
{
    public static IServiceCollection AddCalculatorHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient("HttpCalculatorClient", client =>
        {
            client.BaseAddress = new Uri("http://localhost:34036/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddHttpClient("HttpsCalculatorClient", client =>
        {
            client.BaseAddress = new Uri("https://localhost:44374/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        return services;
    }
        public static IServiceCollection AddEvaluateHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("EvaluateClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7260/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddScoped<EvaluateService>();

            return services;
        }
}
