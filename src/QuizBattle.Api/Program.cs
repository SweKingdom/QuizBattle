using Microsoft.EntityFrameworkCore;
using QuizBattle.Domain;
using QuizBattle.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureRepositories();

var app = builder.Build();
app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<QuizBattleDbContext>();
    await ctx.Database.EnsureCreatedAsync();

    if (!await ctx.Questions.AnyAsync())
    {
        var choices = new[]
        {
            new Choice("A", "Skapar en tråd"),
            new Choice("B", "Säkerställer Dispose"),
            new Choice("C", "Importerar NuGet")
        };

        var q = new Question("Q.CS.001", "Vad gör 'using'?", choices, "B");
        
        // EF Core spårar automatiskt Question och alla relaterade Choices
        ctx.Questions.Add(q);
        await ctx.SaveChangesAsync();
    }
});

app.MapGet("/", () => "Hello World!");

app.Run();
