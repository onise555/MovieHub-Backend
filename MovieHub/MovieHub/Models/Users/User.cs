namespace MovieHub.Models.Users
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName {  get; set; }
        public UserRole Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? VerifyCodeExpiresAt { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool isActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public UserDetail Detail { get; set; }  




    }
}
