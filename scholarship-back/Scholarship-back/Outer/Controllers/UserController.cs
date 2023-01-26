using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;
using Scholarship_back.Outer.Services;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Scholarship_back.Outer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService = new UserService();
        private TokenService _token;
        private readonly DataContext _context;
        public UserController(DataContext context, IConfiguration config)
        {
            _context = context;
            _token =  new TokenService(config);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(_context.Users.ToList());
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<User>>> Get(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return Ok("User already exists.");
            }

            CreatePasswordHash(request.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Bday = request.Bday,
                Role = request.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User successfully created!");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin request)
        {
            var user = _context.Users.Where(x => x.Email.Equals(request.Email)).FirstOrDefault();
            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return NotFound("Password is incorrect.");
            }
            string token = _token.CreateToken(user);
            string IdS = _userService.Encrypt(user.Id + "");
            var userR = new UserReturn
            {
                Id = IdS,
                Token = token,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role
            };
            return Ok(userR);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("promote/{id}")]
        public async Task<ActionResult> Promote(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("Not Found.");
            }
            user.Role = "Admin";
            await _context.SaveChangesAsync();
            return Ok("User promoted successfully");
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut]
        public async Task<ActionResult<List<User>>> Put(UserDto updatedUser, int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Bday = updatedUser.Bday;
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            //user.password= encrypData(updatedUser.password);

            await _context.SaveChangesAsync();

            return await Get(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var useri = await _context.Users.FindAsync(Id);
            if (useri == null)
            {
                return NotFound();
            }
            _context.Users.Remove(useri);
            await _context.SaveChangesAsync();
            return await Get();
        }


        /**/
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
