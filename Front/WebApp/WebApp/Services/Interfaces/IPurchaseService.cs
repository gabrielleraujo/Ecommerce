using System.Threading.Tasks;
using FluentResults;

namespace WebApp.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<Result> AddAsync(int productId, double unitPrice);
    }
}