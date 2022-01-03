using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Job.Context;

namespace Job.DomainService
{
    public class PurchaseDomainService : IPurchaseDomainService
    {
        private readonly IPurchaseClient _purchaseClient;
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseDomainService> _logger;

        public PurchaseDomainService(IPurchaseClient purchaseClient, IMapper mapper, ILogger<PurchaseDomainService> logger)
        {
            _purchaseClient = purchaseClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task BuildSummaryAsync()
        {
            _logger.LogInformation(
                   $"PurchaseDomainService Processing Service is started - {nameof(BuildSummaryAsync)}.");

            await _purchaseClient.BuildSummaryAsync();
        }
    }
}