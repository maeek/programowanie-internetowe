using rejestr_osob_zaginionych.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rejestr_osob_zaginionych
{
  public class AuthService : IAuthService
  {
    private readonly RegistryContext _context;

    public AuthService(RegistryContext context)
    {
      _context = context;
      _context.Database.EnsureCreated();
    }

    public List<UserModel> GetUsers()
    {
      return _context.Users.ToList();
    }

    public UserModel Login(string username, string password)
    {
      var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

      return user;
    }

    public UserModel Register(string username, string password, int role)
    {
      var user = _context.Users.FirstOrDefault(u => u.Username == username);
      if (user == null)
      {
        var newUser = new UserModel { Username = username, Password = password, Role = role };
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
      }
      return null;
    }

    public UserModel GetUser(int id)
    {
      var user = _context.Users.FirstOrDefault(u => u.ID == id);
      return user;
    }

    public List<UserModel> GetAllUsers()
    {
      var users = _context.Users.ToList();
      return users;
    }

    public UserModel UpdateUser(UserModel userModel)
    {
      var user = _context.Users.Find(userModel.ID);
      if (user != null)
      {
        user.Password = userModel.Password;
        user.Role = userModel.Role;
        _context.SaveChanges();

        return user;
      }
      return null;
    }

    public UserModel DeleteUser(int id)
    {
      var user = _context.Users.Find(id);
      if (user != null)
      {
        _context.Users.Remove(user);
        _context.SaveChanges();
        return user;
      }
      return null;
    }
  }
}
