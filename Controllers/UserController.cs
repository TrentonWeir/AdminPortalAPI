
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
            users.ForEach(u => u.Password = string.Empty);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null) return NotFound("USER NOT FOUND");
            user.Password = "";
            return user;
        }
        [HttpPost("user")]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO user)
        {
            
            var existingUser = await _context.Users.FindAsync(user.Id);
            if(existingUser == null){
                await _context.Users.AddAsync(user);
                user.Password = string.Empty;
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            else{
                existingUser.FName = user.FName;
                existingUser.LName = user.LName;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                await _context.SaveChangesAsync();
            }
            existingUser.Password = string.Empty;
            return Ok(existingUser);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id){
            
            if(_context.Admins.Any(x => x.UserId == id)) return BadRequest($"USER IS ADMIN: REMOVE FROM ADMIN BEFORE CONTINUING");
            var user = await _context.Users.FindAsync(id);

            if(user == null) return NotFound($"USER: {id} NOT FOUND");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok($"USER: {id} HAS BEEN SUCCESSFULLY REMOVED");
        }
        
    }
}