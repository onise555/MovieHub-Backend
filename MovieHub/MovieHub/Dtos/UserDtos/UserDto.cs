namespace MovieHub.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;

    }
}
