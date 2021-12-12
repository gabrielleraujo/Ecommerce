using System.Threading.Tasks;

namespace Job.Context
{
    public interface IPurchaseClient
    {
        Task BuildSummaryAsync();
    }
}