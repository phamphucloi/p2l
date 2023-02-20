namespace DemoSesstion1_MVC.Models;

public class CertModel
{
    public List<Cert> findAll()
    {
        return new List<Cert>()
        {
            new Cert
            {
                Id = 1,
               Name = "a"
            },

            new Cert
            {
                Id = 2,
               Name = "b"
            },

            new Cert
            {
                Id = 3,
               Name = "c"
            },

            new Cert
            {
                Id = 4,
               Name = "d"
            }
        };
    }

}
