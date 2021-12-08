using System.Threading;
using System.Threading.Tasks;

namespace Job.Service.Processes
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}