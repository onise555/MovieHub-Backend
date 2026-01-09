namespace MovieHub.Dtos.UserDtos
{
    public class UpdateUserDtos
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
