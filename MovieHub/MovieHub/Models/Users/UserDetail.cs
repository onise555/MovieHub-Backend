namespace MovieHub.Models.Users
{
    public class UserDetail
    {
        public int Id { get; set; } 
        public string ProfileImg {  get; set; } 
        public string Bio {  get; set; }
        public int UserId {  get; set; }
        public User user { get; set; }  
    }
}
