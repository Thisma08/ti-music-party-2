using Application;
using Application.UseCases.Music;
using Application.UseCases.User;
using Application.UseCases.Vote;
using Infrastructure;
using Infrastructure.Repositories;
/*using Infrastructure.Models;
using Infrastructure.Repositories;*/
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var corsPolicyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProfileMapper));

builder.Services.AddDbContext<AppDbContext>(cfg => 
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")
    ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

builder.Services.AddScoped<UseCaseFetchAllUsers>();

builder.Services.AddScoped<UseCaseFetchAllMusics>();
builder.Services.AddScoped<UseCaseCreateMusic>();
builder.Services.AddScoped<UseCaseDeleteMusic>();
builder.Services.AddScoped<UseCaseFetchTop10Musics>();

builder.Services.AddScoped<UseCaseCreateVote>();
builder.Services.AddScoped<UseCaseCountVotes>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(corsPolicyName);

app.UseResponseCaching();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();