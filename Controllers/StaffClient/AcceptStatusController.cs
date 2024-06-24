using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.Models;

namespace SWPApp.Controllers.StaffClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptStatusController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public AcceptStatusController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }


        // Accept Request sau khi nhận kim cương thì staff chuyển status thành đã nhận và đang xử lí
        [HttpPut("Update status-when received diamond/{id}")]
        public async Task<IActionResult> Updatestatus(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Đã nhận kim cương và đang xử lí";

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return Ok(request);            
        }
        //Sau khi cus nhận kim cương thì staff update status="khách hàng đã nhận kim cương" (ở cuspage)="đã nhận hàng"
        [HttpPut("Update status-Done/{id}")]
        public async Task<IActionResult> Statusdone(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = "Khách hàng đã nhận kim cương";

            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }
    }
}
