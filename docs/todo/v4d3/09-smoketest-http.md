# Smoketest – HTTP‑filer/Swagger

## Mål
Verifiera end‑to‑end på 5 minuter.

## 1) Starta session
```http
### Start session
POST http://localhost:5280/sessions
Content-Type: application/json

{ "questionCount": 3 }
````

Förvänta:

*   `201 Created`
*   `Location: /sessions/{id}`
*   body innehåller `sessionId` och `questions`

## 2) Svara på en fråga

```http
### Answer question
POST http://localhost:5280/sessions/{{sessionId}}/answers
Content-Type: application/json

{ "questionCode": "Q.CS.001", "selectedChoiceCode": "Q.CS.001.B" }
```

Förvänta:

*   `200 OK`
*   `{ "isCorrect": true|false }`

## 3) Avsluta

```http
### Finish
POST http://localhost:5280/sessions/{{sessionId}}/finish
```

Förvänta:

*   `200 OK`
*   `{ "score": 3, "answeredCount": 3, ... }`

## Flöde


## Checklista

*   [ ] Alla anrop svarar med rätt koder
*   [ ] JSON ser rimlig ut
*   [ ] SQLite visar data
