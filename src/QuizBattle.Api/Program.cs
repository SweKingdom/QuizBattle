using Microsoft.EntityFrameworkCore;
using QuizBattle.Domain;
using QuizBattle.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureRepositories();

var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    await app.Services.SeedDatabaseAsync();
});

app.MapGet("/", () => "Hello World!");

app.Run();
