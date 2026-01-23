# CRUD – snabbreferens för statuskoder

## Regler
- GET/id → 200 eller 404
- POST → 201 + Location
- PUT → 200 eller 204
- DELETE → 204
- Valideringsfel → 400
- Konflikter → 409

## Visualisering
```mermaid
flowchart TB
  subgraph Läs
    A[GET /resurs] --> OK200[200 OK]
    B[GET /resurs/{id}] -->|finns| OK200b[200 OK]
    B -->|saknas| NF404[404 Not Found]
  end
  subgraph Skriv
    C[POST /resurs] --> CR201[201 Created]
    D[PUT /resurs/{id}] --> OK200c[200 OK]
    E[DELETE /resurs/{id}] --> No204[204 No Content]
  end
  subgraph Fel
    V[Valideringsfel] --> BR400[400 Bad Request]
    K[Konflikt] --> CF409[409 Conflict]
  end
````
