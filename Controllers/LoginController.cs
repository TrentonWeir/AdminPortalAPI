using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPortal.Data;
using AdminPortal.Entities;
using AdminPortal.Entities.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserContext _context;
        public LoginController(UserContext context){
            _context = context;
        }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Login(LoginRec user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);

        if (existingUser == null)
        {
            return NotFound("USER NOT FOUND");
        }

        if (existingUser.Password != user.Password)
        {
            return ValidationProblem("Username or Password Incorrect");
        }

        existingUser.Password = string.Empty;
        // Optionally, you can map the User entity to a UserDTO here before returning
        // var userDTO = MapToUserDTO(existingUser);

        return Ok(existingUser); // Or return userDTO if you have mapped the User entity to UserDTO
    }
    }
}