namespace DemoSesstion1_MVC.Models.Infomation;

public class CountryModel
{
    public List<Country> GetAll()
    {
        return new List<Country>
        {
            new Country()
            {
                Id = 1,
                Name = "VietNam"
            },
            new Country()
            {
                Id = 2,
                Name = "United State Armerica"
            },
            new Country()
            {
                Id = 3,
                Name = "Japan"
            },
            new Country()
            {
                Id = 4,
                Name = "Korean"
            },
            new Country()
            {
                Id = 5,
                Name = "British"
            }
        };
    }
}
