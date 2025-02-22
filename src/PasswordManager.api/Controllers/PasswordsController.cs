using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordManager.api.Data;
using PasswordManager.api.Models;
using BCrypt.Net;

namespace PasswordManager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly PasswordManagerContext _context;

        public PasswordsController(PasswordManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Password>>> GetPasswords()
        {
            return await _context.Passwords.ToListAsync();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Password>>> GetPasswordsByUserId(int userId)
        {
            var user = await _context.Users.Include(u => u.Passwords).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user.Passwords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Password>> GetPasswordById(int id)
        {
            var password = await _context.Passwords.FindAsync(id);

            if (password == null)
            {
                return NotFound();
            }

            return password;
        }

        [HttpPost]
        public async Task<ActionResult<Password>> PostPassword([FromBody] Password password)
        {
            var user = await _context.Users.Include(u => u.Passwords).FirstOrDefaultAsync(u => u.Id == password.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            password.PasswordValue = password.PasswordValue;

            user.Passwords ??= new List<Password>();
            user.Passwords.Add(password);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPasswordById), new { id = password.Id }, password);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassword(int id, [FromBody] Password password)
        {
            if (id != password.Id)
            {
                return BadRequest();
            }

            password.PasswordValue = password.PasswordValue;

            _context.Entry(password).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasswordExists(int id)
        {
            return _context.Passwords.Any(e => e.Id == id);
        }
    }
}