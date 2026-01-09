using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Dtos.UserDtos;
using MovieHub.Services;
using MovieHub.SMTP;
using System.Security.Claims;

namespace MovieHub.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class UserController : ControllerBase
    {

        private readonly DataContext _data;
        private readonly JwtService _jwt;
        private readonly EmailSender _sender;

        public UserController(DataContext data, JwtService jwt, EmailSender sender)
        {
            _data = data;
            _jwt = jwt;
            _sender = sender;
        }



        [HttpGet("Get-User/{id}")]
        public ActionResult GetUser(int id)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (id != currentUserId)
                return Forbid("You can only access your own profile");
            
            var user =_data.users.FirstOrDefault(x=>x.Id ==id && x.Role ==UserRole.User);   

            if (user == null)
                return NotFound("User Not Founded");

            var userdt = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                IsActive = user.IsActive,
                IsVerified = user.IsVerified,

            };
            return Ok(userdt);
        }




    }
}
