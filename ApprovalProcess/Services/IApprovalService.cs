using ApprovalProcess.Models;

namespace ApprovalProcess.Services;

public interface IApprovalService
{
    ApprovalResponse Approve(ApprovalRequest request); 
}
