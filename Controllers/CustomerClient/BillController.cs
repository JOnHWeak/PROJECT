using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SWPApp.Controllers.CustomerClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public BillController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }

        // GET api/bills/{billNumber}
        [HttpGet("{billNumber}")]
        public async Task<ActionResult<Bill>> GetBill(int billNumber)
        {
            var bill = await _context.Bills
                .Include(b => b.Customer)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(b => b.BillNumber == billNumber);

            if (bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        // POST api/bills/create-by-customer/{customerName}
        [HttpPost("create-by-customer/{customerName}")]
        public async Task<ActionResult<Bill>> CreateBillByCustomerName(string customerName, [FromBody] Bill billDetails)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase));

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.ServiceId == billDetails.ServiceId);

            if (service == null)
            {
                return NotFound("Service not found.");
            }

            var newBill = new Bill
            {
                IssueDate = DateTime.Now,
                CustomerId = customer.CustomerId,
                Customer = customer,
                ServiceId = service.ServiceId,
                Service = service,
                PaymentStatus = true, // Set to "đã thanh toán"
                PaymentMethod = 1, // Set to "Chuyển khoản"
                PaymentMethodDescription = null // Set to null
            };

            _context.Bills.Add(newBill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBill), new { billNumber = newBill.BillNumber }, newBill);
        }
    }
}

