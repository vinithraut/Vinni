using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinniDatingApp.Data;
using VinniDatingApp.Entities;
using VinniDatingApp.Interfaces;

namespace VinniDatingApp.Controllers
{

    //[Route("[controller]")]
    //[ApiController]
    [Authorize]
    public class UsersController:BaseApiController
    {
        private readonly DataContext _context;
        //private readonly IUserRepository _userRepository;
       
        public UsersController(DataContext context)
        {
            this._context = context;
            
        }

        //[AllowAnonymous]
        [HttpGet("GetUsers")]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [Authorize]
        [HttpGet("GetUser/{Id}")]
        public async Task< ActionResult<AppUser>> GetUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            return user;
        }
    }
}
