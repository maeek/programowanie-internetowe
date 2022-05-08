using rejestr_osob_zaginionych.Models;
using System.Collections.Generic;

namespace rejestr_osob_zaginionych
{
  public interface IAuthService
  {
    List<UserModel> GetAllUsers();
    UserModel GetUser(int id);
    UserModel Login(string username, string password);
    UserModel Register(string username, string password, int role);
    UserModel UpdateUser(UserModel userModel);
    UserModel DeleteUser(int id);
    List<UserModel> GetUsers();
  }
}