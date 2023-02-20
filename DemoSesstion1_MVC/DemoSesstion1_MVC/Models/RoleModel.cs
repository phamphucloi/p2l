namespace DemoSesstion1_MVC.Models;

public class RoleModel
{
    public List<Role> findAll()
    {
        return new List<Role>()
        {
            new Role
            {
                Id = 1,
               Name = "SuperAdmin"
            },
            new Role
            {
                Id = 2,
               Name = "Admin"
            },
            new Role
            {
                Id = 3,
               Name = "Nhân viên"
            }
        };
    }
}
