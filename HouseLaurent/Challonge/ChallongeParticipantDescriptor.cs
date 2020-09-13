namespace HouseLaurent.Challonge
{
    internal class ChallongeParticipantDescriptor
    {
        public string Name { get; }

        public string? ChallongeUsername { get; set; }

        public int Seed { get; }

        public ChallongeParticipantDescriptor(string name, string? challongeUsername, int seed)
        {
            Name = name;
            ChallongeUsername = challongeUsername;
            Seed = seed;
        }
    }
}
