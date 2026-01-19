using QuizBattle.Application.Interfaces;

namespace QuizBattle.Application.Features.AnswerQuestion
{
    public class AnswerQuestionHandler
    {
        private readonly ISessionRepository _sessions;
        private readonly IQuestionRepository _questions;

        public AnswerQuestionHandler(ISessionRepository sessions, IQuestionRepository questions)
        {
            // Standard null-checkar
            if (sessions == null) throw new ArgumentNullException(nameof(sessions));
            if (questions == null) throw new ArgumentNullException(nameof(questions));
            _sessions = sessions;
            _questions = questions;
        }

        public async Task<AnswerQuestionResult> Handle(AnswerQuestionCommand cmd)
        {
            // Kollar om ID är tomt innan vi kör
            if (cmd.SessionId == Guid.Empty)
            {
                return AnswerQuestionResult.Fail(cmd.SessionId, cmd.QuestionCode, "SessionId får inte vara tomt.");
            }

            try
            {
                var session = await _sessions.GetByIdAsync(cmd.SessionId, default);
                if (session == null)
                {
                    return AnswerQuestionResult.Fail(cmd.SessionId, cmd.QuestionCode, "Sessionen saknas.");
                }

                var question = await _questions.GetByCodeAsync(cmd.QuestionCode, default);

                // Kör på UtcNow direkt här för enkelhetens skull
                session.SubmitAnswer(question, cmd.SelectedChoiceCode, DateTime.UtcNow);

                // Sparar ner ändringarna till databasen
                await _sessions.UpdateAsync(session, default);

                return new AnswerQuestionResult(
                    true,
                    session.Id,
                    question.Code,
                    question.IsCorrect(cmd.SelectedChoiceCode)
                );
            }
            catch (Exception ex)
            {
                // Om något smäller returnerar vi bara meddelandet
                return AnswerQuestionResult.Fail(cmd.SessionId, cmd.QuestionCode, ex.Message);
            }
        }
    }
}
