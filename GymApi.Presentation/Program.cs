using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Data.Data.MySql;
using GymApi.Data.Data.PlanRepository;
using GymApi.Data.Data.Repositories;
using GymApi.Data.Data.Validator.Interfaces;
using GymApi.Data.Data.Validator.Validators;
using GymApi.Domain;
using GymApi.UseCases.AuthorizationPolicyService;
using GymApi.UseCases.Interfaces;
using GymApi.UseCases.Jobs;
using GymApi.UseCases.Notification;
using GymApi.UseCases.Services;
using GymApi.UseCases.Services.LogEvent;
using GymApi.UseCases.Services.Plan;
using GymApi.UseCases.Services.PlanHandler;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var connectioMySql = builder.Configuration.GetConnectionString("MysqlConn");

builder.Services.AddDbContext<GymDbContext>(opts =>
{
    opts.UseMySql(connectioMySql, ServerVersion.AutoDetect(connectioMySql));
});

builder.Services.Configure<GymDatabaseSettings>(
    builder.Configuration.GetSection("GymDatabase"));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<GymDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("MinAge", policy =>
    {
        policy.AddRequirements(new MinAge(12));
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahldhakhskajgbskabksjbas5461674651")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = "localhost:6379";
	// Set the default TTL for cache entries (in seconds)
	options.InstanceName = "redis";
	options.ConfigurationOptions = new ConfigurationOptions
	{
		AbortOnConnectFail = false,
		ConnectRetry = 3,
		EndPoints = { "localhost:6379" },


	};
});

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuth>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LoginUserService>();
builder.Services.AddScoped<GenerateTokenService>();
builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<ContractGymService>();
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<PersonalTrainerService>();
builder.Services.AddScoped<TrainingService>();
builder.Services.AddScoped<TrainingByUserService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<ExerciseByTrainingService>();
builder.Services.AddScoped<TicketGateService>();
builder.Services.AddScoped<TicketGateUserService>();
builder.Services.AddScoped<PersonalByUserService>();
builder.Services.AddScoped<ExcelDataReaderService>();

builder.Services.AddScoped<GetAllPlanCommandHandler>();
builder.Services.AddScoped<GetByIdPlanCommandHandler>();

builder.Services.AddScoped<ITicketGate, TicketGateService>();
builder.Services.AddHostedService<BackgroundTicketGateService>();

builder.Services.AddScoped<IPlanRepositorySql, PlanRepositorySql>();
builder.Services.AddScoped<IPlanRepositoryCache, PlanRepositoryCache>();
builder.Services.AddScoped<IProductsRepositorySql, ProductsRepositorySql>();
builder.Services.AddScoped<IPersonalTrainerRepositorySql, PersonalTrainerRepositorySql>();
builder.Services.AddScoped<IContractRepositoryNoSql, ContractRepositoryNoNoSql>();
builder.Services.AddScoped<ITrainingRepositorySql, TrainingRepositorySql>();
builder.Services.AddScoped<ITrainingByUserRepositorySql, TrainingByUserRepositorySql>();
builder.Services.AddScoped<IExerciseRepositorySql, ExerciseRepositorySql>();
builder.Services.AddScoped<IExerciseByTrainingRepositorySql, ExerciseByTrainingRepositorySql>();
builder.Services.AddScoped<ICreateUserRepositorySql, CreateUserRepositorySql>();
builder.Services.AddScoped<ITicketGateUserRepositorySql, TicketGateUserRepositorySql>();
builder.Services.AddScoped<IPersonalByUserRepositorySql, PersonalByUserRepositorySql>();
builder.Services.AddScoped<IExcelReader, ExcelDataReaderService>();


builder.Services.AddScoped<IValidatorExercise, ExerciseValidator>();
builder.Services.AddScoped<IValidatorPersonalByUser, PersonalByUserValidator>();
builder.Services.AddScoped<IValidatorPlan, PlanValidator>();
builder.Services.AddScoped<IValidatorTicketGate, TicketGateValidator>();
builder.Services.AddScoped<IValidatorTraining, TrainingValidator>();
builder.Services.AddScoped<IValidatorTrainingByUser, TrainingByUserValidator>();

builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(AddPlanCommandHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(UpdatePlanCommandHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(DeletePlanCommandHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(LogEventHandler).GetTypeInfo().Assembly));
// builder.Services.AddMediatR(typeof(AddPlanCommandHandler));
// builder.Services.AddMediatR(typeof(UpdatePlanCommandHandler));
// builder.Services.AddMediatR(typeof(DeletePlanCommandHandler));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


