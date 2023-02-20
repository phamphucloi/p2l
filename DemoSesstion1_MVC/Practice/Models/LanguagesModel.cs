namespace Practice.Models;

public class LanguagesModel
{
    public List<Languages> getAllLanguages()
    {
        return new List<Languages>()
        {
            new Languages()
            {
                Id = 1,
                Name = "English"
            },
            new Languages()
            {
                Id = 2,
                Name = "Japan"
            },
            new Languages()
            {
                Id = 3,
                Name = "Korean"
            },
        };
    }
}
