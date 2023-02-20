namespace Practice.Models;

public class CertModel
{   
    public List<Cert> Certs { get; set;}

    public List<Cert> getAllCert() 
    {
        return new List<Cert>()
        {
            new Cert()
            {
                Id= 1,
                Name = "Kĩ sư phần mềm."
            },

            new Cert()
            {
                Id= 2,
                Name = "Project Manager"
            },

            new Cert()
            {
                Id= 3,
                Name = "Director"
            }
        };
    }
}
