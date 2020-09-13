using System;

namespace HouseLaurent.Challonge
{
    internal class ChallongeTournamentDescriptor
    {
        public string Name { get; }

        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Path as in challonge.com/{UrlPath}
        /// </summary>
        public string? UrlPath { get; private set; }

        public string? Description { get; private set; }

        public ChallongeTournamentKind TournamentKind { get; private set; }

        public bool? HoldSingleElimThirdPlaceMatch { get; private set; }

        /// <summary>
        /// <list type="bullet">
        /// <item>0 if there aren't grand finals between the W bracket winner and L bracket winner.</item>
        /// <item>1 if the L bracket winner only needs to beat the W bracket winner once.</item>
        /// <item>2 if the L bracket winner needs to beat the W bracket winner twice.</item>
        /// </list>
        /// </summary>
        public int? DoubleElimGrandFinalsCount { get; private set; }

        public int? SwissRoundCount { get; private set; }

        private ChallongeTournamentDescriptor(string name, DateTimeOffset startTime)
        {
            Name = name;
            StartTime = startTime;
        }

        public static ChallongeTournamentDescriptor CreateSingleElim(string name, DateTimeOffset startTime, string? urlPath, string? description, bool holdThirdPlaceMatch)
        {
            return new ChallongeTournamentDescriptor(name, startTime)
            {
                UrlPath = urlPath,
                Description = description,
                TournamentKind = ChallongeTournamentKind.SingleElimination,
                HoldSingleElimThirdPlaceMatch = holdThirdPlaceMatch,
            };
        }

        public static ChallongeTournamentDescriptor CreateDoubleElim(string name, DateTimeOffset startTime, string? urlPath, string? description, int grandFinalsCount)
        {
            return new ChallongeTournamentDescriptor(name, startTime)
            {
                UrlPath = urlPath,
                Description = description,
                TournamentKind = ChallongeTournamentKind.DoubleElimination,
                DoubleElimGrandFinalsCount = grandFinalsCount,
            };
        }

        public static ChallongeTournamentDescriptor CreateRoundRobin(string name, DateTimeOffset startTime, string? urlPath, string? description)
        {
            return new ChallongeTournamentDescriptor(name, startTime)
            {
                UrlPath = urlPath,
                Description = description,
                TournamentKind = ChallongeTournamentKind.RoundRobin,
            };
        }

        public static ChallongeTournamentDescriptor CreateSwiss(string name, DateTimeOffset startTime, string? urlPath, string? description, int roundCount)
        {
            return new ChallongeTournamentDescriptor(name, startTime)
            {
                UrlPath = urlPath,
                Description = description,
                TournamentKind = ChallongeTournamentKind.Swiss,
                SwissRoundCount = roundCount,
            };
        }
    }
}
