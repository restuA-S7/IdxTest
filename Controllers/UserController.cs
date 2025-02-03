using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myappAPI.Models;
using myappAPI.DAL;

namespace myappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConttoler : ControllerBase
    {
        //inject
        private readonly IUser _user;
        public UserConttoler(IUser user) 
        {
            _user = user;
        }

        [HttpGet] //metodnya ini ditulis
        public IEnumerable<User> Get()
        {
            var users = _user.GetAll();
            return users;
        }
    }
}

// [Route("api/[controller]")]
// [ApiController]
// public class UserConttoler : ControllerBase
// {
//     private readonly ApplicationDbContext _context;

//     public UserConttoler(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<User>>> Get()
//     {
//         var users = await _context.Users.ToListAsync();
//         if (users == null)
//         {
//             return NotFound();
//         }

//         return Ok(users);
//         //return await _context.Users.ToListAsync();
//     }
// }
