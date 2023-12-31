﻿using System.Collections;
using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface ITrainingRepositorySql : IBaseRepositorySql<Guid, Training>
{

}