using System.Reflection.Metadata.Ecma335;

namespace GymApi.Domain;

public class PersonalTrainer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double MaxMinutesPerDay { get; set; } = 8 * 60;
    public ICollection<PersonalByUser> PersonalByUsers { get; set; }
}