﻿using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class PersonalTrainerRepository : BaseRepositoryAbstract<Guid, PersonalTrainer>, IPersonalTrainerRepository
{
    public PersonalTrainerRepository(GymDbContext context) : base(context)
    {
    }
}