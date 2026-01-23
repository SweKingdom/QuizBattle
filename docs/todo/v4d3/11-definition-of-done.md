# Definition of Done – V4D3 API‑kontrakt

Klar när allt nedan uppfylls:

- [ ] Domän EF‑kompatibel (param‑lös ctor, public set, PK/FK, navigationer, listor init)
- [ ] DbContext registrerad och första migration körd (SQLite‑fil finns)
- [ ] Minimal API exponerar:
  - [ ] POST /sessions → 201 + Location
  - [ ] POST /sessions/{id}/answers → 200 + { isCorrect }
  - [ ] POST /sessions/{id}/finish → 200 + summering
  - [ ] GET /questions/random → 200 + exakt count
- [ ] Felpolicy konsekvent (400/404/409; felobjekt beskriver orsak)
- [ ] Smoketest (HTTP/Swagger) passerar utan manuella ingrepp
