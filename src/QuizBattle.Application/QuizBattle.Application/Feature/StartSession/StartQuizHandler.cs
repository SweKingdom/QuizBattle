using QuizBattle.Application.Interfaces;
using QuizBattle.Domain;

namespace QuizBattle.Application.Features.StartSession
{
    public class StartQuizHandler
    {
        private readonly IQuestionRepository _questions;
        private readonly ISessionRepository _sessions;

        public StartQuizHandler(IQuestionRepository questions, ISessionRepository sessions)
        {
            _questions = questions;
            _sessions = sessions;
        }

        public async Task<StartQuizResult> Handle(StartQuizCommand cmd)
        {
            try
            {
                // Hämtar alla frågor och slumpar dem med LINQ, smidigt sätt att få unika frågor
                var allQuestions = await _questions.GetAllAsync(default);

                var picked = allQuestions
                    .OrderBy(x => Guid.NewGuid())
                    .Take(cmd.QuestionCount)
                    .ToList();

                var session = QuizSession.Create(cmd.QuestionCount);

                // Använder Update för att spara den nya sessionen
                await _sessions.UpdateAsync(session, default);

                return new StartQuizResult(true, session.Id, picked);
            }
            catch (Exception ex)
            {
                return StartQuizResult.Fail(ex.Message);
            }
        }
    }
}
