using MovieHub.Models.Librares;
using MovieHub.Models.Reviews;
using MovieHub.Models.WatchHistores;
using MovieHub.Models.WishLists;

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
        public string? VerifyCode { get; set; }

        public DateTime? VerifyCodeExpiresAt { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool isActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public UserDetail Detail { get; set; }  

        public List<WishList> WishList { get; set; } = new List<WishList>();    

        public List<Library> libraries {  get; set; }= new List<Library>();

        public List<Review> reviews { get; set; }= new List<Review>();

        public List<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();


    }
}
    