using System.Threading.Tasks;

namespace Job.DomainService
{
    public interface IPurchaseDomainService
    {
        Task GetHasNoSummaryAsync();
    }
}