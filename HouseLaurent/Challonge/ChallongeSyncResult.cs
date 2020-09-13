using System.Collections.Generic;

namespace HouseLaurent.Challonge
{
    /// <summary>
    /// The result of a single Challonge tournament's synchronization between HouseLaurent (local) and Challonge (remote). See <see cref="IChallongeContext.SyncTournament"/>.
    /// </summary>
    internal class ChallongeSyncResult
    {
        /// <summary>
        /// The old tournament as tracked by Challonge before a <see cref="IChallongeContext"/> pushed its modified version from HouseLaurent to Challonge. If null, there was no difference between HouseLaurent and Challonge.
        /// </summary>
        public ChallongeTournament? TournamentModified { get; }

        /// <summary>
        /// A list of old tournament participants that were tracked by both HouseLaurent and Challonge with differences. Each list item is as tracked by Challonge before a <see cref="IChallongeContext"/> pushed its modified version from HouseLaurent to Challonge.
        /// </summary>
        public IReadOnlyList<ChallongeParticipant> ParticipantsModified { get; }

        /// <summary>
        /// A list of tournament particpants that were tracked by HouseLaurent but untracked by Challonge. Each list item is a participant that a <see cref="IChallongeContext"/> added to Challonge.
        /// </summary>
        public IReadOnlyList<ChallongeParticipant> ParticipantsAdded { get; }

        /// <summary>
        /// A list of tournament particpants that were untracked by HouseLaurent but tracked by Challonge. Each list item is a participant that a <see cref="IChallongeContext"/> deleted from Challonge.
        /// </summary>
        public IReadOnlyList<ChallongeParticipant> ParticipantsDeleted { get; }

        /// <summary>
        /// A list of old tournament matches that were tracked by both HouseLaurent and Challonge with differences. Each list item is as tracked by Challonge before a <see cref="IChallongeContext"/> pushed its modified version from HouseLaurent to Challonge.
        /// </summary>
        public IReadOnlyList<ChallongeMatch> MatchesModified { get; }

        /// <summary>
        /// A list of tournament matches currently untracked by HouseLaurent but tracked by Challonge. HouseLaurent is advised to add these matches.
        /// </summary>
        public IReadOnlyList<ChallongeMatch> UntrackedLocalMatches { get; }

        /// <summary>
        /// A list of tournament matches currently tracked by HouseLaurent but untracked by Challonge. HouseLaurent is advised to delete these matches.
        /// </summary>
        public IReadOnlyList<ChallongeMatch> UntrackedRemoteMatches { get; }

        public ChallongeSyncResult(ChallongeTournament? tournamentModified, IReadOnlyList<ChallongeParticipant> participantsModified, IReadOnlyList<ChallongeParticipant> participantsAdded, IReadOnlyList<ChallongeParticipant> participantsDeleted, IReadOnlyList<ChallongeMatch> matchesModified, IReadOnlyList<ChallongeMatch> untrackedLocalMatches, IReadOnlyList<ChallongeMatch> untrackedRemoteMatches)
        {
            TournamentModified = tournamentModified;
            ParticipantsModified = participantsModified;
            ParticipantsAdded = participantsAdded;
            ParticipantsDeleted = participantsDeleted;
            MatchesModified = matchesModified;
            UntrackedLocalMatches = untrackedLocalMatches;
            UntrackedRemoteMatches = untrackedRemoteMatches;
        }
    }
}
