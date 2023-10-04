using System.Reflection.Metadata.Ecma335;
using GymApi.Domain.Enum;

namespace GymApi.Domain;

public class PersonalTrainer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public HoursDayPersonal MaxMinutesPerDay { get; set; } = HoursDayPersonal.EightHours;
    public ICollection<PersonalByUser> PersonalByUsers { get; set; }
}