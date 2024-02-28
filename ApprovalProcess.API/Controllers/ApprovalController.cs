using Microsoft.AspNetCore.Mvc;
using ApprovalProcess.Models;
using ApprovalProcess.Services;

namespace ApprovalProcess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _approvalService;

        public ApprovalController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        [HttpPost]
        public ActionResult<ApprovalResponse> Approve(ApprovalRequest request)
        {
            var response = _approvalService.Approve(request);
            return Ok(response);
        }
    }
}
