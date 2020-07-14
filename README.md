# House Laurent

A *Legends of Runeterra* tournament platform. This library is a backend comprising a data layer (currently EF Core) and a domain model designed for access from a Discord client, an ASP.NET web client, and more. Provides:

- Modeling of tournaments and multi-tournament series.
- Modeling of players on a per-tournament level (deck lineup, in-game name, etc.) and an overall level (tournament participation, handles on relevant platforms like Discord and Twitch, etc.)
- Deck & lineup validation from modular rules (e.g. the max number of decks in a lineup an LoR region can appear in).
- Flexible Swiss and single-elimination bracket-making that a client can adjust on a per-round level.

House Laurent is blind to the logistics of running a tourament, which a client should implement.

Depends on [Bjerg](https://github.com/TheMostCuriousThing/Bjerg) and [Unterwalden](https://github.com/TheMostCuriousThing/Unterwalden).
