using System;

namespace rejestr_osob_zaginionych.Models
{
  public class UserModel
  {
    public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public bool IsDisabled { get; set; }
  }
}
