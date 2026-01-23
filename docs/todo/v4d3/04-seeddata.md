# Seeddata – enkel start

## Mål
Ha minst 3 frågor med vardera 3 val, så API:t kan testas direkt.

## Alternativ A – Seed via OnModelCreating (HasData)
Lämpligt för demo, men kräver statiska Id:n.

## Alternativ B – Init‑kommando vid uppstart
Skapa en enkel init‑metod i API‑projektet som:
- kontrollerar om `Questions` är tom,
- om tom, lägger till 3–5 frågor + val.

```csharp
app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<QuizBattleDbContext>();
    await ctx.Database.EnsureCreatedAsync();

    if (!await ctx.Questions.AnyAsync())
    {
        var q = new Question { Id = Guid.NewGuid(), Code="Q.CS.001", Text="Vad gör 'using'?" };
        q.Choices.Add(new Choice{ Id=Guid.NewGuid(), Text="Skapar en tråd", QuestionId=q.Id });
        q.Choices.Add(new Choice{ Id=Guid.NewGuid(), Text="Säkerställer Dispose", QuestionId=q.Id });
        q.Choices.Add(new Choice{ Id=Guid.NewGuid(), Text="Importerar NuGet", QuestionId=q.Id });
        ctx.Questions.Add(q);
        await ctx.SaveChangesAsync();
    }
});
````

## Checklista

*   [ ] Automatiskt seedat om DB saknade data
*   [ ] Frågor synliga via kommande endpoints

