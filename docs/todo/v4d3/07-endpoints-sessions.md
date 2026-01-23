# Endpoints – Sessions (start, answer, finish)

## Mål
Implementera tre endpoints enligt kontraktet, kopplat till Application.

## 1) POST /sessions – Starta quiz
- Request: `{ "questionCount": int, "category": string?, "difficulty": int? }`
- Response: `201 Created` + body `{ sessionId, questions: [...] }`
- Fel: `400` (ogiltig count), `409` (konflikt om affärsregler säger så)

```mermaid
sequenceDiagram
  participant C as Klient
  participant API as /sessions
  participant App as SessionService.StartAsync
  C->>API: POST /sessions {count, ...}
  API->>App: StartAsync(count, category, difficulty)
  App-->>API: { sessionId, questions }
  API-->>C: 201 Created + Location + body
````

## 2) POST /sessions/{id}/answers – Registrera svar

*   Request: `{ "questionCode": "...", "selectedChoiceCode": "..." }`
*   Response: `200 OK` + `{ isCorrect: bool }`
*   Fel: `404` (session saknas), `400` (ogiltig input), `409` (dubbelsvar)

## 3) POST /sessions/{id}/finish – Avsluta

*   Response: `200 OK` + `{ score, answeredCount, startedAtUtc, finishedAtUtc }`
*   Idempotent: upprepade finish ger samma slutresultat

## Checklista

*   [ ] Tre endpoints returnerar korrekta koder
*   [ ] Application‑handlers anropas
*   [ ] Fel översätts till ProblemDetails eller `{ error, message }`
