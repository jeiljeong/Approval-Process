using ApprovalProcess.Models;

namespace ApprovalProcess.Services
{
    public class ApprovalService : IApprovalService // Ensure your class implements the interface
    {
        public ApprovalResponse Approve(ApprovalRequest request)
        {
            // Implement your approval logic here
            // For example, check if the request meets certain criteria
            bool isApproved = true; // Placeholder for actual logic
            string message = isApproved ? "Approved" : "Rejected";

            return new ApprovalResponse { Approved = isApproved, Message = message };
        }
    }
}
