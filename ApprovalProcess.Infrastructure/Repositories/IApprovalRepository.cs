using ApprovalProcess.Models;
using System.Threading.Tasks;

namespace ApprovalProcess.Infrastructure.Repositories
{
    public interface IApprovalRepository
    {
        Task<ApprovalRequest> GetRequestAsync(int id);
        Task SaveRequestAsync(ApprovalRequest request);
    }
}
