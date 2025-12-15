using MovieHub.Models.Users;

namespace MovieHub.Models.WishLists
{
    public class WishList
    {
        public int Id { get; set; } 
        public string WishListName { get; set; }
        public int UserId { get; set; }  
        public User User { get; set; }
        public List<WishListItems> WishListItems { get; set; } = new List<WishListItems>();



    }
}
