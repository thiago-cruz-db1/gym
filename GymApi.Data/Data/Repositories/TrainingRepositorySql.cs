using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data.Data.Repositories;

public class TrainingRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Training>, ITrainingRepositorySql
{
    public TrainingRepositorySql(GymDbContext context) : base(context)
    {
    }
}