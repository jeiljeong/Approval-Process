using ApprovalProcess.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ApprovalProcess.Infrastructure.Repositories
{
    public class MongoApprovalRepository : IApprovalRepository
    {
        private readonly IMongoCollection<ApprovalRequest> _approvalRequests;

        public MongoApprovalRepository(IMongoDatabase database)
        {
            _approvalRequests = database.GetCollection<ApprovalRequest>("ApprovalRequests");
        }

        public async Task<ApprovalRequest> GetRequestAsync(int id)
        {
            return await _approvalRequests.Find(request => request.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveRequestAsync(ApprovalRequest request)
        {
            var existingRequest = await GetRequestAsync(request.Id);
            if (existingRequest == null)
            {
                await _approvalRequests.InsertOneAsync(request);
            }
            else
            {
                await _approvalRequests.ReplaceOneAsync(r => r.Id == request.Id, request);
            }
        }
    }
}
