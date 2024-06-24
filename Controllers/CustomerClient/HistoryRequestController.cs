using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SWPApp.Controllers.CustomerClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryRequestController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public HistoryRequestController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }

        [HttpGet("history/{customerId}")]
        public async Task<IActionResult> GetRequestHistory(int customerId)
        {
            // Check if the customer exists and is logged in
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId && c.Status == true && c.LoginToken != null);
            if (customer != null)
            {
                // Retrieve the request history for the customer
                var requestHistory = await _context.Requests
                    .Where(r => r.CustomerId == customerId)
                    .Include(r => r.Customer)
                    .Include(r => r.Employee)
                    .Include(r => r.Diamond)
                    .ToListAsync();

                if (requestHistory != null && requestHistory.Count > 0)
                {
                    return Ok(requestHistory);
                }
                else
                {
                    return NotFound("No request history found for this customer.");
                }
            }
            else
            {
                return Unauthorized("You must login to use this service.");
            }
        }
    }
}
