using Microsoft.EntityFrameworkCore;
using QuizBattle.Domain;

namespace QuizBattle.Infrastructure.Data;

public static class QuizBattleDbSeeder
{
    public static async Task SeedAsync(QuizBattleDbContext context, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(context);

        await context.Database.EnsureCreatedAsync(ct);

        if (await context.Questions.AnyAsync(ct))
            return;

        var questions = new[]
        {
            new Question(
                "Q.CS.001",
                "Vad gör 'using'?",
                new[]
                {
                    new Choice("A", "Skapar en tråd"),
                    new Choice("B", "Säkerställer Dispose"),
                    new Choice("C", "Importerar NuGet")
                },
                "B",
                category: "C#",
                difficulty: 1
            ),
            new Question(
                "Q.CS.002",
                "Vad är en interface?",
                new[]
                {
                    new Choice("A", "En klass"),
                    new Choice("B", "Ett kontrakt"),
                    new Choice("C", "En metod")
                },
                "B",
                category: "C#",
                difficulty: 1
            ),
            new Question(
                "Q.CS.003",
                "Vad är LINQ?",
                new[]
                {
                    new Choice("A", "Language Integrated Query"),
                    new Choice("B", "Linear Query"),
                    new Choice("C", "List Query")
                },
                "A",
                category: "C#",
                difficulty: 2
            )
        };

        context.Questions.AddRange(questions);
        await context.SaveChangesAsync(ct);
    }
}
