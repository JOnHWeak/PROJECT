using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPApp.Models;
using System;

namespace SWPApp.Controllers.StaffClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public PaymentController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }

        [HttpPut("payment-status&requeststatus/{requestId}")]
        public IActionResult UpdatePaymentStatusAndRequestStatus(int requestId)
        {
            var requestDetail = _context.RequestDetails.FirstOrDefault(rd => rd.RequestId == requestId);
            if (requestDetail == null)
            {
                return NotFound("RequestDetail not found.");
            }

            var request = _context.Requests.FirstOrDefault(r => r.RequestId == requestId);
            if (request == null)
            {
                return NotFound("Request not found.");
            }

            // Update payment status to true
            requestDetail.PaymentStatus = true;

            // Update request status message
            request.Status = "Đã thanh toán"; // Assuming true indicates "Nhân viên đang đến nhận kim cương!"

            // Save changes to the database
            _context.SaveChanges();

            // Return updated CustomerId along with a success message
            return Ok(new { Message = "Đã thanh toán, Nhân viên đang đến nhận kim cương!", request.CustomerId });
        }
    }
}
