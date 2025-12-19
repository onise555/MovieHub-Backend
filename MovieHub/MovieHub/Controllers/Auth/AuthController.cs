using BCrypt;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Models.Users;
using MovieHub.Requests;
using MovieHub.Services;
using MovieHub.SMTP;

namespace MovieHub.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _data;
        private readonly JwtService _Jwt;
        private readonly EmailSender _emailSender;
        public AuthController(DataContext data , JwtService jwt, EmailSender emailSender )
        {
            _data = data;
            _Jwt = jwt;
            _emailSender = emailSender;

        }

        #region

        [HttpPost("Registration")]
        public ActionResult Registration([FromBody] UserRequest req)
        {

         var existemail =req.Email;

            if (_data.users.Any(x => x.Email == existemail))
                return BadRequest("email is exist");

            var code = new Random().Next(1000,100000).ToString();

            User user = new User
            {
                UserName = req.FirstName,
                Role =UserRole.User,
                Email = existemail,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                DateOfBirth =req.DateOfBirth,
                CreatedAt= DateTime.Now,
                UpdatedAt= DateTime.Now,    
                VerifyCode = code,
                VerifyCodeExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsVerified =false,
                IsActive =true
                
               
            };

            _data.users.Add(user);
            _data.SaveChanges();


            // Send verification email
            _emailSender.SendMail(existemail, "Verification Code", $"Your code is: <b>{code}</b>");

            return Ok("Registration successful. Check your email for verification code.");

        }

        [HttpPost("Verification")]
        public ActionResult Verification(Verify req)
        {

            var user = _data.users.FirstOrDefault(x => x.Email == req.Email);


            if (user == null) 
                return BadRequest();
            if (DateTime.UtcNow > user.VerifyCodeExpiresAt)
                return BadRequest("time is end try agine");

            if (user.VerifyCode == req.Code)
            {
                user.IsVerified = true;
                user.VerifyCode = null;
                _data.SaveChanges();
                return Ok("Email verified successfully!");
            }

            return BadRequest("This Email Not Founded");
        }
        #endregion
    }
}
