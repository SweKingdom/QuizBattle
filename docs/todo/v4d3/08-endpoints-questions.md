# Endpoints – Questions

## Mål
Expose en endpoint för att hämta N slumpade frågor med ev. filter.

## GET /questions/random
- Query: `count=3&category=&difficulty=`
- Response: `200 OK` + `[ { code, text, choices: [ { code, text } ] } ]`
- Fel: `400` om count ≤ 0 eller > total

```mermaid
sequenceDiagram
  participant C as Klient
  participant API as /questions/random
  participant App as QuestionService.GetRandomQuestionsAsync
  C->>API: GET /questions/random?count=3
  API->>App: GetRandomQuestionsAsync(3, category, difficulty)
  App-->>API: questions[]
  API-->>C: 200 OK + JSON
````

## Checklista

*   [ ] Returnerar exakt `count` frågor
*   [ ] Tomma filter stöds
*   [ ] Korrekt 400‑policy vid ogiltig count
