namespace QuizBattle.Domain
{
    public class Answer
    {
        public Answer(Question question, string selectedChoiceCode, DateTime answeredAtUtc)
        {
            Question = question;
            SelectedChoiceCode = selectedChoiceCode?.Trim()!;
            AnsweredAtUtc = answeredAtUtc;
            EnsureValid();
        }

        public Question Question { get; set; }
        public string SelectedChoiceCode { get; set; }
        public DateTime AnsweredAtUtc { get; set; }

        public bool IsCorrect => Question.IsCorrect(SelectedChoiceCode);

        private void EnsureValid()
        {
            if (Question is null)
                throw new DomainException("Question must not be null.");

            if (string.IsNullOrWhiteSpace(SelectedChoiceCode))
                throw new DomainException("SelectedChoiceCode must not be null or whitespace.");

            if (!Question.HasChoice(SelectedChoiceCode))
                throw new DomainException($"SelectedChoiceCode '{SelectedChoiceCode}' hör inte till frågan '{Question.Code}'.");

            if (AnsweredAtUtc == default)
                throw new DomainException("AnsweredAtUtc måste vara ett giltigt UTC‑datum.");
        }
    }
}
