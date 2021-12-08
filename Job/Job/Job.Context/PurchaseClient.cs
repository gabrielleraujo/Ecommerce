using Microsoft.Extensions.Logging;
using RestSharp;
using System.Threading.Tasks;
using Job.CrossCutting.DTO.Purchase;
using System.Collections.Generic;

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

        public async Task GetHasNoSummaryAsync()
        {
            _logger.LogInformation("Searching purchase by ID is working.\n");

            var request = new RestRequest($"purchase/make-summary");

            var response = await _client.ExecuteGetAsync<IList<ReadPurchaseDTO>>(request);

            _logger.LogInformation($"StatusCode: {response.StatusCode} - in {nameof(GetHasNoSummaryAsync)}\n");
        }
    }
}