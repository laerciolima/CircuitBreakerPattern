
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace CircuitBreakerPattern
{
    public static class ConfigurationHttp
    {
        public static IServiceCollection AddHttpClientCircuitBreaker(this IServiceCollection services)
        {

            var circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(response => !response.IsSuccessStatusCode)
                .AdvancedCircuitBreakerAsync(
                    failureThreshold: 0.5, //irá abrir o circuito quando 50%
                    samplingDuration: TimeSpan.FromSeconds(10), //janela de analise de 10 segundos
                    minimumThroughput: 2, //deve haver pelo menos 2 requisições para analise
                    durationOfBreak: TimeSpan.FromSeconds(10), //janela de espera de 10 segundos
                    onBreak: (_,_) => Console.WriteLine("[CIRCUIT BREAKER IS OPEN]"),
                    onReset: () => Console.WriteLine("[CIRCUIT BREAKER IS CLOSED]"),
                    onHalfOpen: () => Console.WriteLine("[CIRCUIT BREAKER IS HALF-OPEN]")
                    );

            services
            .AddHttpContextAccessor()
            .AddHttpClient("CLIENT_WIREMOCK", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://localhost:8080");
            })
            .AddPolicyHandler(circuitBreakerPolicy);
            
            return services;
        }
    }
}
