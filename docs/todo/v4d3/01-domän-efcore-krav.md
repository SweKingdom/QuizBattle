# Domän → EF Core‑krav (QuizBattle)

## Mål
Gör `Question`, `Choice`, `Answer` EF‑kompatibla utan att förlora domänregler.

## Regler som måste uppfyllas
- Parameterlös konstruktor (public/protected)
- Public get/set på persistenta properties
- Primärnyckel (Guid Id) för `Question` och `Answer` (rekommenderat)
- Foreign keys och navigationer:
  - `Choice.QuestionId`, `Choice.Question`
  - `Answer.QuestionId`, `Answer.Question`
- Samlingsnavigationer initieras: `Question.Choices = new();`, `Question.Answers = new();`
- Domänregler i metoder/fabriker (inte i ctor som EF hoppar över vid hydrering)

## Klassiskt EF‑klassdiagram
```mermaid
classDiagram
  class Question {
    +Guid Id
    +string Code
    +string Text
    +string? Category
    +int? Difficulty
    +List~Choice~ Choices
    +List~Answer~ Answers
    +Question()  // paramlös för EF
  }
  class Choice {
    +Guid Id
    +string Text
    +Guid QuestionId
    +Question Question
    +Choice()   // paramlös för EF
  }
  class Answer {
    +Guid Id
    +string SelectedChoiceCode
    +DateTime AnsweredAtUtc
    +Guid QuestionId
    +Question Question
    +Answer()  // paramlös för EF
  }

  Question "1" --> "many" Choice
  Question "1" --> "many" Answer
````

## Checklista

*   [ ] Lagt till `Id` på `Question` och `Answer`
*   [ ] Lagt till `QuestionId` + `Question` på `Choice` och `Answer`
*   [ ] Parameterlös ctor på alla
*   [ ] Samlingsnavigationer initierade
*   [ ] Validering flyttad från ctor till metod/fabrik
