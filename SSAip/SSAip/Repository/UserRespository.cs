using SSAip.DTO;
using SSAip.Interfaces;
using SSAip.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml.Linq;

namespace SSAip.Repository
{
    public class UserRespository : IUserRepository
    {
        private readonly SHOESTOREContext _context;
        public UserRespository(SHOESTOREContext context) { 
            _context = context;
        }
        public bool AddUser(UserDTO newUser)
        {
            var user = new User
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password,
                Address = newUser.Address,
                Phonenumber = newUser.Phonenumber,
                RoleId = newUser.RoleId
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(UserDTO newUser)
        {
            var olduser = _context.Users.FirstOrDefault(u=>u.UserId == newUser.UserId);
            if (olduser != null)
            {
                olduser.UserId = newUser.UserId;
                olduser.Name = newUser.Name;
                olduser.Email = newUser.Email;
                olduser.Password = newUser.Password;
                olduser.Address = newUser.Address;
                olduser.Phonenumber = newUser.Phonenumber;
                olduser.RoleId = newUser.RoleId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteUser(string id)
        { 
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<User> GetAll()
        {
            var list = _context.Users.ToList();
            return list;
        }

        public User GetById(string id)
        {
            var user = _context.Users.FirstOrDefault(u=>u.UserId == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public User CheckAccound(string email,string pass)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email==email && u.Password==pass);
            if (user != null)
            {
                return user;
            }
            return null;
        }


        public ICollection<User> GetUserByName(string username)
        {
            var list = _context.Users.Where(u => u.Name.Contains(username)).ToList();
            if (list != null)
            {
                return list;
            }
            return null;
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
