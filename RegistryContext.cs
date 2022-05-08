using rejestr_osob_zaginionych.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rejestr_osob_zaginionych
{
  public class RegistryContext : DbContext
  {
    public DbSet<PersonModel> MissingPeople { get; set; }
    public DbSet<UserModel> Users { get; set; }

    public RegistryContext(DbContextOptions<RegistryContext> options) : base(options)
    {
    }
  }
}