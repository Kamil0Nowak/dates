using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _db;

        public UsersController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAll()
        {
            return Ok(await _db.Users.ToListAsync());
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetById(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
