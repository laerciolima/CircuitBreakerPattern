using Microsoft.AspNetCore.Mvc;

namespace CircuitBreakerPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CircuitBreakerController : ControllerBase
    {
        

        private readonly ILogger<CircuitBreakerController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public CircuitBreakerController(ILogger<CircuitBreakerController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = _httpClientFactory.CreateClient("CLIENT_WIREMOCK");
            try
            {
                var response = await httpClient.GetAsync("/test");

                if (response.IsSuccessStatusCode)
                {
                    return StatusCode(200, "Success");
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}