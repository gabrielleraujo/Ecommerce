using System.Threading.Tasks;
using FluentResults;
using WebApp.Clients.Interfaces;
using WebApp.Services.Interfaces;
using WebApp.Services.Mappings;

namespace WebApp.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseApiClient _purchaseApiClient;

        public PurchaseService(IPurchaseApiClient purchaseApiClient)
        {
            _purchaseApiClient = purchaseApiClient;
        }

        public async Task<Result> AddAsync(int productId, double unitPrice)
        {
            var purchaseDto = PurchaseServiceMapping.CreateDataTestToPurchase(productId, unitPrice);

            var result = await _purchaseApiClient.PostPurchaseAsync(purchaseDto);
            return result;
        }
    }
}