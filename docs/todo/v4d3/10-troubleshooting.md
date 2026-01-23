# Troubleshooting – vanliga fel & fix

## 1) 500 Internal Server Error direkt
- Orsak: saknad `AddDbContext` eller fel connection string
- Åtgärd: säkerställ `UseSqlite("Data Source=quizbattle.db")`

## 2) 400 Bad Request på POST /sessions
- Orsak: `questionCount` ≤ 0
- Åtgärd: validera input, returnera 400 med tydligt fel

## 3) 404 på POST /sessions/{id}/answers
- Orsak: sessionId fel/okänd
- Åtgärd: hämta session i repo, returnera 404 om null

## 4) 409 på answers
- Orsak: dubbelsvar på samma fråga
- Åtgärd: domänregel; returnera 409 Conflict med förklaring

## 5) “No parameterless constructor”
- Orsak: entiteter saknar param‑lös ctor
- Åtgärd: lägg till ctor, flytta validering från ctor till metod

## 6) Migrationer skapas inte
- Orsak: fel projekt för design‑time
- Åtgärd: använd `--project` och `--startup-project`

## Felmatris
```mermaid
graph TD
  A[Symptom] -->|EF fel| B[Paramlös ctor saknas]
  A -->|404/Null| C[Repo returnerar null]
  A -->|400| D[Ogiltig input]
  A -->|409| E[Domänkonflikt]
  B --> F[Lägg till ctor]
  C --> G[Returnera NotFound]
  D --> H[Validera & förklara]
  E --> I[Returnera Conflict]
````
