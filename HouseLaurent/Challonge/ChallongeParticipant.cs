namespace HouseLaurent.Challonge
{
    internal class ChallongeParticipant
    {
        public int TournamentId { get; }

        public int Id { get; }

        public ChallongeParticipantDescriptor Desc { get; }

        public ChallongeParticipant(int tournamentId, int id, ChallongeParticipantDescriptor desc)
        {
            TournamentId = tournamentId;
            Id = id;
            Desc = desc;
        }
    }
}
