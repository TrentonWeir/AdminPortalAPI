using AdminPortal.Data;
using AdminPortal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserContext _context;
        public AdminController(UserContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminDTO>>> GetAdmins() {
            return Ok(await _context.Admins.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDTO>> GetAdmin(int id){
            return await _context.Admins.FindAsync(id);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<AdminDTO>> AddAdmin(int id)
        {
            if (await _context.Users.AnyAsync(x => x.Id == id))
            {
                AdminDTO admin = new() { UserId = id };
                var existingAdmin = await _context.Admins.FindAsync(admin.UserId);
                if (existingAdmin == null)
                {
                    await _context.Admins.AddAsync(admin);
                    await _context.SaveChangesAsync();
                    return admin;
                }
                return existingAdmin;
            }
            return NotFound($"ID:{id} was not found in USERS");

        }
    }
}