using SSAip.DTO;
using SSAip.Models;
using System.Collections.ObjectModel;

namespace SSAip.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        ICollection<User> GetUserByName(string username);
        User GetById(string id);
        User CheckAccound(string email,string pass);
        User GetByEmail(string email);
        bool AddUser(UserDTO newUser);
        bool UpdateUser(UserDTO newUser);
        bool DeleteUser(string id);


    }
}
