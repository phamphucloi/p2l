namespace Practice.Models.Test;

public class GenderModel
{
    public List<Gender> GetGender()
    {
        return new List<Gender>()
        {
            new Gender()
            {
                Id = 1,
                Name ="Male"
            },
            new Gender()
            {
                Id = 2,
                Name ="Female"
            },
        };
    }
}
