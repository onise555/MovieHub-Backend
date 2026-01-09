namespace MovieHub.Requests.UserRequests
{
    public class UpdateUserRequest
    {

        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }= DateTime.Now;
    }
}
