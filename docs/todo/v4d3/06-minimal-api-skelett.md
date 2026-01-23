# Minimal API – skelett

## Mål
Skapa en **tunn** Program.cs som:
- exponerar endpoints enligt kontraktet,
- översätter DTO ⇄ Application,
- returnerar korrekta statuskoder/felobjekt.

## Flöde
```mermaid
sequenceDiagram
  participant C as Klient
  participant API as Minimal API
  participant App as Application Services
  participant Repo as EF Repos
  participant DB as SQLite
  C->>API: HTTP request (JSON)
  API->>App: DTO → Command
  App->>Repo: Use case
  Repo->>DB: SQL
  DB-->>Repo: rows
  Repo-->>App: model
  App-->>API: result
  API-->>C: status + body
````

## Startpunkt

*   Lägg `AddEndpointsApiExplorer`, `AddSwaggerGen`
*   Registrera Application‑tjänster och EF‑repo
*   Mappa 4 endpoints tomt (utan logik än), enbart:
    *   route
    *   DTO
    *   retur av “NotImplemented” (tillfälligt)

## Checklista

*   [ ] API startar
*   [ ] Swagger visar 4 endpoints

