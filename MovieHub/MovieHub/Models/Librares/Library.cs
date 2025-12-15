using MovieHub.Models.Users;

namespace MovieHub.Models.Librares
{
    public class Library
    {
        public int Id { get; set; } 
        public string LibraryName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<LibraryItems> LibraryItems { get; set; } = new List<LibraryItems>();

    }
}
