using System;

namespace rejestr_osob_zaginionych.Models
{
  public class PersonModel
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public int? Age { get; set; }
    public string? Appereance { get; set; }
    public string? Place { get; set; }
    public DateTime DateMissing { get; set; }
    public DateTime? DateFound { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
  }
}
