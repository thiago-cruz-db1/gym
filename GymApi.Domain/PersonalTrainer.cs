using System.Reflection.Metadata.Ecma335;

namespace GymApi.Domain;

public class PersonalTrainer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<User> Users { get; set; }
}