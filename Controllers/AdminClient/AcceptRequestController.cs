using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.Models;

namespace SWPApp.Controllers.AdminClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptRequestController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public AcceptRequestController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }
        

        // Accept Request
        [HttpPost("accept-request/{id}")]
        public async Task<IActionResult> AcceptRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Đã kiểm định"; 

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }
    }
}
