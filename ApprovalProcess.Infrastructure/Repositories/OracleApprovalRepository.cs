using ApprovalProcess.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApprovalProcess.Infrastructure.Repositories
{
    public class OracleApprovalRepository : IApprovalRepository
    {
        private readonly OracleDbContext _context;

        public OracleApprovalRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<ApprovalRequest> GetRequestAsync(int id)
        {
            // Assuming 'id' is mapped appropriately for OracleDB
            return await _context.ApprovalRequests.FindAsync(id);
        }

        public async Task SaveRequestAsync(ApprovalRequest request)
        {
            var existingRequest = await GetRequestAsync(request.Id);
            if (existingRequest == null)
            {
                _context.ApprovalRequests.Add(request);
            }
            else
            {
                _context.Entry(existingRequest).CurrentValues.SetValues(request);
            }
            await _context.SaveChangesAsync();
        }
    }
}
