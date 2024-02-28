using ApprovalProcess.Services;
using ApprovalProcess.Models;

namespace ApprovalProcess.Tests.ServiceTests
{
    public class ApprovalServiceTests
    {
        [Fact]
        public void Approve_ReturnsApproved_WhenCriteriaMet()
        {
            // Arrange
            var service = new ApprovalService();
            var request = new ApprovalRequest(); // Set properties as needed

            // Act
            var result = service.Approve(request);

            // Assert
            Assert.True(result.Approved);
        }
    }
}