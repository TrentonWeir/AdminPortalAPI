
using AdminPortal.Data;
using AdminPortal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers(){
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id){
            return await _context.Users.FindAsync(id);
        }
        [HttpPost("user")]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO user)
        {
            
            var existingUser = await _context.Users.FindAsync(user.Id);
            if(existingUser == null){
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            else{
                existingUser.FName = user.FName;
                existingUser.LName = user.LName;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
                await _context.SaveChangesAsync();
            }
            return Ok(existingUser);
        }
    }
}