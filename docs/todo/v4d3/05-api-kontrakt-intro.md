# API‑kontrakt – kort återaktivering

## Begreppskarta
```mermaid
mindmap
  root((API-kontrakt))
    Resurs
      sessions
      questions
      answers
    Representation
      JSON
    Statuskoder
      200 OK
      201 Created
      400 Bad Request
      404 Not Found
      409 Conflict
    Felobjekt
      { error, message/details }
````

## Kontraktets delar

*   Metod + URL
*   Request‑schema
*   Response‑schema
*   Statuskodpolicy
*   Felobjektformat

## QuizBattle – resurser

*   `POST /sessions` – starta
*   `POST /sessions/{id}/answers` – svara
*   `POST /sessions/{id}/finish` – avsluta
*   `GET /questions/random?count=3&category=&difficulty=`
