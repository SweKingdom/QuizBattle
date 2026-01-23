## `00-index.md`

````markdown
# V4D3 – API‑kontrakt med Minimal API (översikt)

## Syfte
Efter passet ska du kunna:
- förklara vad ett **API‑kontrakt** är (resurser, representation, statuskoder, felobjekt),
- beskriva kontrakt **utan att läsa implementation**,
- implementera ett tunt **Minimal API** som exponerar QuizBattle‑use cases,
- koppla Minimal API → Application → EF/SQLite och köra ett **smoketest** end‑to‑end.

## Förkunskaper
- Grundläggande OOP i C#
- Kännedom om QuizBattle‑domänen (Question, Choice, Answer, QuizSession)
- Repetition av EF Core‑krav på entiteter (param‑lös ctor, public set, PK/FK, navigationer)

## Vad vi bygger idag (lager för lager)
```mermaid
flowchart LR
  Client[Klient/HTTP] --> API[Minimal API]
  API --> App[Application (Use Cases)]
  App --> Dom[Domain]
  App --> Repo[Repos]
  Repo --> DB[(SQLite)]
````

## Filkarta (läs i ordning)

1.  `01-domän-efcore-krav.md` – säkra domänen för EF Core
2.  `02-infrastruktur-dbcontext-sqlite.md` – DbContext + DI‑registrering
3.  `03-migrationer.md` – skapa/kör migrationer
4.  `04-seeddata.md` – enkel seed för frågor/svarsalternativ
5.  `05-api-kontrakt-intro.md` – kort återaktivering av kontrakts‑teorin
6.  `06-minimal-api-skelett.md` – skapa Program.cs + tunn struktur
7.  `07-endpoints-sessions.md` – Start/Answer/Finish
8.  `08-endpoints-questions.md` – Hämta slumpade frågor
9.  `09-smoketest-http.md` – HTTP‑filer/Swagger‑flöde
10. `10-troubleshooting.md` – vanliga fel & fix
11. `11-definition-of-done.md` – när är vi klara?
12. `12-crud-quickref.md` – statuskoder & CRUD kortfattat

## Checkpoints

*   [ ] Domän EF‑kompatibel (PK/FK/nav/ctor/set)
*   [ ] SQLite‑db skapad via migration
*   [ ] Minimal API svarar enligt kontrakt (statuskoder/felobjekt)
*   [ ] Smoketest passerar
