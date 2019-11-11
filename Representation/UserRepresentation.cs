using Shop.Models;

namespace Shop.Representation
{
    public class UserRepresentation
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public static UserRepresentation CreateRepresentation(User user)
        {
            return user == null
            ? null
            : new UserRepresentation
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}