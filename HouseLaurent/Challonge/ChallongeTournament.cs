namespace HouseLaurent.Challonge
{
    internal class ChallongeTournament
    {
        public int Id { get; }

        public ChallongeTournamentDescriptor Desc { get; }

        public ChallongeTournament(int id, ChallongeTournamentDescriptor desc)
        {
            Id = id;
            Desc = desc;
        }

    }
}
