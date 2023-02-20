namespace DemoSesstion1_MVC.Models;

public class LanguageModel
{
    public List<Language> findAll()
    {
        return new List<Language>()
        {
            new Language
            {
                Id = 1,
               Name = "anh"
            },

            new Language
            {
                Id = 2,
               Name = "bol"
            },

            new Language
            {
                Id = 3,
               Name = "china"
            },

            new Language
            {
                Id = 4,
               Name = "del"
            }
        };
    }
}
