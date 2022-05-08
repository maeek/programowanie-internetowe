using rejestr_osob_zaginionych.Models;
using System.Collections.Generic;

namespace rejestr_osob_zaginionych
{
  public interface IPersonManager
  {
    PersonModel AddPerson(PersonModel personModel);
    PersonModel RemovePerson(int id);
    PersonModel UpdatePerson(PersonModel personModel);
    List<PersonModel> GetAllPersons();
    List<PersonModel> GetAllMales();
    List<PersonModel> GetAllFemales();
    PersonModel GetPerson(int id);
  }
}