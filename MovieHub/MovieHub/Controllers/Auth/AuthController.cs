using BCrypt;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Models.Users;
using MovieHub.Requests.AuthRequests;
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


        [HttpPost("ResendCode")]
        public ActionResult ResendCode(ResendCodeRequest req)
        {
            var user = _data.users.FirstOrDefault(x=>x.Email == req.Email); 

            if(user == null)
                return BadRequest("User Not Founded");

            if (user.IsVerified==true)
                return BadRequest("User Alredy Valid");

            Random random = new Random();
            var code = random.Next(1000, 100000).ToString();

            var NewCode = user.VerifyCode = code;
            user.VerifyCodeExpiresAt = DateTime.UtcNow.AddMinutes(1);
           

           _data.SaveChanges();
   

            if(user.VerifyCode == NewCode)
            {
                user.IsVerified=true;
                user.VerifyCode = null;
            }
        

            _emailSender.SendMail(user.Email,"Resnd",$"{NewCode}");

            return Ok("New verification code sent successfully ");

        }


        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginRequest req)
        {
            var user = _data.users.FirstOrDefault(x => x.Email == req.Email);

            if (user == null)
                return BadRequest("User not found");

            if (!user.IsVerified)
                return BadRequest("Please verify your email before logging in.");

            if (!user.IsActive)
                return BadRequest("User is deactivated");

            var isValid = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            if (!isValid)
                return BadRequest("Invalid password");

            var token = _Jwt.GenerateToken(user.Id, user.UserName, new List<UserRole> { user.Role });

            return Ok(new
            {
                Message = "Login successful",
                Token = token,
                User = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    Role = user.Role.ToString()
                }
            });
        }

        [HttpPost("Forgot-Password")]
        public ActionResult ForgotPassword([FromBody] ForgotPasswordRequest req)
        {
            var user =_data.users.FirstOrDefault(x=>x.Email==req.Email);

            if (user == null)
                return BadRequest("User Not Founded");

            if (!user.IsVerified)
                return BadRequest("User email is not verified");
            var code =new Random().Next(100000, 1000000).ToString();
            user.VerifyCode = code; 
            user.VerifyCodeExpiresAt= DateTime.UtcNow.AddMinutes(5);

            _data.SaveChanges();


            _emailSender.SendMail(user.Email, "Password Reset Code", $"Your reset code is: <b>{code}</b>");

            return Ok(new { message = "Password reset code sent to your email." });

        }
        #endregion
    }
}
