namespace Practice.Models.Test;

public class FriendModel
{
    public List<Friends> GetFriends()
    {
        return new List<Friends>()
        {
            new Friends()
            {
                Id = 1,
                Name = "Lợi"
            },
            new Friends()
            {
                Id = 2,
                Name = "Quân"
            },
            new Friends()
            {
                Id = 3,
                Name = "Kha"
            },
            new Friends()
            {
                Id = 4,
                Name = "Thái"
            },
            new Friends()
            {
                Id = 5,
                Name = "Tín"
            },
            new Friends()
            {
                Id = 6,
                Name = "Vinh"
            },
        };

    }
}
