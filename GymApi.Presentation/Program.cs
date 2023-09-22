using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.UseCases;
using GymApi.UseCases.AuthorizationPolicyUseCase;
using GymApi.UseCases.UserUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CreateUserUseCase = GymApi.UseCases.CreateUserUseCase;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("MysqlConn");
// Add services to the container.
builder.Services.AddDbContext<GymDbContext>(opts =>
{
    opts.UseMySql(conn, ServerVersion.AutoDetect(conn));
});

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

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuth>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<GenerateTokenUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
