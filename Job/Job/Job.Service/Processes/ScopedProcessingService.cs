using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Job.DomainService;

namespace Job.Service.Processes
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly IPurchaseDomainService _purchaseDomainService;

        public ScopedProcessingService(
            ILogger<ScopedProcessingService> logger,
            IPurchaseDomainService purchaseDomainService)
        {
            _logger = logger;
            _purchaseDomainService = purchaseDomainService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await StartAsync();

                _logger.LogInformation($"Concluded - in {nameof(DoWork)}.");

                await Task.Delay(300000, stoppingToken); // 5 min
            }
        }

        public async Task StartAsync()
        {
            await _purchaseDomainService.GetHasNoSummaryAsync();
        }
    }
}