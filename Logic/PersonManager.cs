using rejestr_osob_zaginionych.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rejestr_osob_zaginionych
{
  public class PersonManager : IPersonManager
  {
    private readonly RegistryContext _context;

    public PersonManager(RegistryContext context)
    {
      _context = context;
    }

    public PersonModel AddPerson(PersonModel personModel)
    {
      _context.MissingPeople.Add(personModel);
      _context.SaveChanges();
      return personModel;
    }

    public PersonModel RemovePerson(int id)
    {
      var person = _context.MissingPeople.Find(id);
      if (person != null)
      {
        _context.MissingPeople.Remove(person);
        _context.SaveChanges();
      }
      return person;
    }

    public PersonModel UpdatePerson(PersonModel personModel)
    {
      var person = _context.MissingPeople.Find(personModel.ID);
      if (person != null)
      {
        person.Age = personModel.Age;
        person.Appereance = personModel.Appereance;
        person.Place = personModel.Place;
        person.DateMissing = personModel.DateMissing;
        person.DateFound = personModel.DateFound;
        person.Description = personModel.Description;
        person.Photo = personModel.Photo;
        _context.SaveChanges();
      }

      return person;
    }

    public List<PersonModel> GetAllPersons()
    {
      return _context.MissingPeople.ToList();
    }

    public PersonModel GetPerson(int id)
    {
      return _context.MissingPeople.Find(id);
    }

    PersonModel IPersonManager.AddPerson(PersonModel personModel)
    {
      _context.MissingPeople.Add(personModel);
      _context.SaveChanges();
      return personModel;
    }

    PersonModel IPersonManager.RemovePerson(int id)
    {
      var person = _context.MissingPeople.Find(id);
      if (person != null)
      {
        _context.MissingPeople.Remove(person);
        _context.SaveChanges();
      }
      return person;
    }

    PersonModel IPersonManager.UpdatePerson(PersonModel personModel)
    {
      var person = _context.MissingPeople.Find(personModel.ID);
      if (person != null)
      {
        person.Age = personModel.Age;
        person.Appereance = personModel.Appereance;
        person.Place = personModel.Place;
        person.DateMissing = personModel.DateMissing;
        person.DateFound = personModel.DateFound;
        person.Description = personModel.Description;
        person.Photo = personModel.Photo;
        _context.SaveChanges();
      }

      return person;
    }

    public List<PersonModel> GetAllMales()
    {
      return _context.MissingPeople.Where(x => x.Gender == "m").ToList();
    }

    public List<PersonModel> GetAllFemales()
    {
      return _context.MissingPeople.Where(x => x.Gender == "k").ToList();
    }
  }
}
