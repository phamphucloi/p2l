namespace Practice.Models;

public class RoleModel
{
    public List<Role> getAllRoles() 
    {
        return new List<Role>()
        {
            new Role() 
            { 
                Id = 1,
                Name = "Super_Admin"
            },
           new Role()
            {
                Id = 2,
                Name = "Admin"
            },
            new Role()
            {
                Id =3,
                Name = "Thường"
            },
        };
    }
}
