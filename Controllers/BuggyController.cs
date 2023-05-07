using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinniDatingApp.Data;
using VinniDatingApp.Entities;

namespace VinniDatingApp.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        private BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-errors")]
        public ActionResult<string> GetServerError()
        {

            var thing = _context.Users.Find(-1);
            var thingToReturn = _context.ToString();

            return thingToReturn;

        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad request!");
        }

       
    }
}
