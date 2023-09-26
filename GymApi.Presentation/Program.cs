using System.Text;
using GymApi.Data.Data;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.Mongo;
using GymApi.Data.Data.MySql;
using GymApi.Data.Data.PlanRepository;
using GymApi.Domain;
using GymApi.UseCases;
using GymApi.UseCases.AuthorizationPolicyUseCase;
using GymApi.UseCases.Services;
using GymApi.UseCases.UserUseCase;
using GymUserApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var connectioMySql = builder.Configuration.GetConnectionString("MysqlConn");
// Add services to the container.
builder.Services.AddDbContext<GymDbContext>(opts =>
{
    opts.UseMySql(connectioMySql, ServerVersion.AutoDetect(connectioMySql));
});

builder.Services.Configure<GymDatabaseSettings>(
    builder.Configuration.GetSection("GymDatabase"));

//config identity
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

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuth>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<GenerateTokenUseCase>();

builder.Services.AddScoped<ContractGymService>();
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<PersonalTrainerService>();

builder.Services.AddScoped<IPlanRepositorySql, PlanRepositorySql>();
builder.Services.AddScoped<IProductsRepositorySql, ProductsRepositorySql>();
builder.Services.AddScoped<IPersonalTrainerRepositorySql, PersonalTrainerRepositorySql>();
builder.Services.AddScoped<IContractRepositorySql, ContractRepositorySql>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
