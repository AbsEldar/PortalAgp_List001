using System;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
          private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
 
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Users.Find(Guid.Parse("f0653f91-b36a-4f5a-8ced-f75f1549136d"));
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
                // return NotFound();
            }
            return Ok();
        }
 
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Users.Find(Guid.Parse("f0653f91-b36a-4f5a-8ced-f75f1549136d"));
            var thingToReturn = thing.ToString();
 
            return Ok();
        }
 
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
            // return BadRequest();
        }
 
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}