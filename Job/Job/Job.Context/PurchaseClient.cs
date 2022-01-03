using Microsoft.Extensions.Logging;
using RestSharp;
using System.Threading.Tasks;

namespace Job.Context
{
    public class PurchaseClient : IPurchaseClient
    {
        private readonly IRestClient _client;
        private readonly ILogger<PurchaseClient> _logger;

        public PurchaseClient(IRestClient client, ILogger<PurchaseClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task BuildSummaryAsync()
        {
            _logger.LogInformation($"{nameof(BuildSummaryAsync)} is working.\n");

            var request = new RestRequest($"purchase-summary/build");

            var response = await _client.ExecuteGetAsync(request);

            _logger.LogInformation($"StatusCode: {response.StatusCode}\n");
        }
    }
}