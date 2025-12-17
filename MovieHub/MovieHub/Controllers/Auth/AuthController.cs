using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Models.Users;
using MovieHub.Requests;
using MovieHub.Services;

namespace MovieHub.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _data;
        private readonly JwtService _Jwt;
        public AuthController(DataContext data , JwtService jwt )
        {
            _data = data;
            _Jwt = jwt;

        }

        #region

        [HttpPost("Registration")]
        public ActionResult Registration([FromBody] UserRequest req)
        {
            User user = new User()
            {
                UserName = req.FirstName,
                Email = req.Email,
                Role = UserRole.User,
                Password = req.Password,
                DateOfBirth = req.DateOfBirth,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                VerifyCodeExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsVerified = true,
                isActive = true,
                VerifyCode = "2211",
                



            };

            _data.users.Add(user);
            _data.SaveChanges();

            return Ok(user);
        }
        #endregion
    }
}
