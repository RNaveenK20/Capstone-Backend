﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using server.Model;
using server.DBModel;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RecipeManagementDbContext _context;

        public RegisterController(RecipeManagementDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegister userRegister)
        {
            if (userRegister == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Hash the password using SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(userRegister.correctPasswordOfUser));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string hashedPassword = builder.ToString();

                // Create a new User object
                User user = new User
                {
                    Username = userRegister.nameOfUser,
                    Email = userRegister.emailOfUser,
                    PasswordHash = hashedPassword
                };

                // Add the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok("Registration of User completed Successfully.");
            }
        }
    }
}
