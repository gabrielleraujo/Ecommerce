using System.Threading.Tasks;
using FluentResults;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace WebApp.Clients.Interfaces
{
    public interface IPurchaseApiClient
    {
        Task<Result> PostPurchaseAsync(CreatePurchaseDTO purchaseDto);
    }
}