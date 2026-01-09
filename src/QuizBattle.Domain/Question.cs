
namespace QuizBattle.Domain;

public  class Question
{
    public Question(string text, Choice[] choices, string correctAnswerCode)
    {
        Text = text?.Trim()!;
        Choices = choices?.ToList()!;
        CorrectAnswerCode = correctAnswerCode;
        EnsureValid();
    }

    public string Text { get; }
    public List<Choice> Choices { get; }
    public string CorrectAnswerCode { get; }

    private void EnsureValid()
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            throw new DomainException("Text must not be null or whitespace");
        }

        if (Choices is null)
        {
            throw new DomainException("Choices must not be null");
        }

        if (!Choices.Any())
        {
            throw new DomainException("Choices must not be empty.");
        }

        if (string.IsNullOrWhiteSpace(CorrectAnswerCode))
        {
            throw new DomainException("CorrectAnswerCode must not be null or whitespace.");
        }
    }
}
