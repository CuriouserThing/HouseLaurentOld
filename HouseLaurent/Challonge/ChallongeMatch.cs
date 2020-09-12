namespace HouseLaurent.Challonge
{
    internal class ChallongeMatch
    {
        public int TournamentId { get; }

        public int Id { get; }

        public int Round { get; }

        public int PlayerAId { get; }

        public int PlayerBId { get; }

        public int PlayerAWins { get; }

        public int PlayerBWins { get; }

        public ChallongeMatch(int tournamentId, int id, int round, int playerAId, int playerBId, int playerAWins, int playerBWins)
        {
            TournamentId = tournamentId;
            Id = id;
            Round = round;
            PlayerAId = playerAId;
            PlayerBId = playerBId;
            PlayerAWins = playerAWins;
            PlayerBWins = playerBWins;
        }
    }
}
