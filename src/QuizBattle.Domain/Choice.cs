
using System;

namespace QuizBattle.Domain
{
    public class Choice
    {
        public Choice(string code, string option)
        {
            Id = Guid.NewGuid();
            Code = code;
            Text = option;
            EnsureValid();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }

        private void EnsureValid()
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                throw new DomainException("Code must not be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Text))
            {
                throw new DomainException("Text must not be null or empty.");
            }
        }
    }
}
