using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(ContextDatabase context) : Controller
    {
        private readonly ContextDatabase _context = context;
        [HttpGet]
        [Route("api/users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await _context.Users.Include(u => u.ListAddresses).ToListAsync();
           // IEnumerable<Post> posts = await _context.Posts.Include(p => p.User).ToListAsync();
            return Ok(users);
        }
    }
    
}
