using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.DTO;
using SWPApp.Models;
using System.Threading.Tasks;

namespace SWPApp.Controllers.StaffClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateRequestController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public CreateRequestController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(requestDto.CustomerId);
            if (customer == null)
            {
                return NotFound($"Customer with ID {requestDto.CustomerId} not found.");
            }

            var request = new Request
            {
                CustomerId = requestDto.CustomerId,
                RequestDate = requestDto.RequestDate,
                ServiceType = requestDto.ServiceType,
                EmployeeId = requestDto.EmployeeId,
                DiamondId = requestDto.DiamondId,
                ServiceId = requestDto.ServiceId,
                Status = requestDto.Status,
                Customer = customer
            };

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Request created successfully", requestId = request.RequestId });
        }

        // Existing endpoint for getting request by ID with related entities
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var request = await _context.Requests
                .Include(r => r.Customer)
                .Include(r => r.Employee)
                .Include(r => r.Diamond)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            var requestDto = new CreateRequestDto
            {
                CustomerId = request.CustomerId,
                RequestDate = request.RequestDate,
                ServiceType = request.ServiceType,
                EmployeeId = request.EmployeeId,
                DiamondId = request.DiamondId,
                ServiceId = request.ServiceId,
                Status = request.Status
            };

            return Ok(requestDto);
        }
    }
}
