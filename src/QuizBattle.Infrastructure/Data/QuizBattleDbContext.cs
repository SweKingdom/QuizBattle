using Microsoft.EntityFrameworkCore;
using QuizBattle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBattle.Infrastructure.Data
{
    public class QuizBattleDbContext : DbContext
    {
        public DbSet<Answer> Answers => Set<Answer>();

        // 
        public DbSet<Choice> Choices => Set<Choice>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<QuizSession> Sessions => Set<QuizSession>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=quizbattle.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                        .HasOne(answer => answer.Question)
                        .WithMany(question => question.Answers);

            modelBuilder.Entity<Choice>()
                        .HasKey(choice => choice.Id);

            modelBuilder.Entity<Question>()
                        .HasMany(Question => Question.Choices);
        }
    }
}
