using System.Collections.Generic;

namespace HouseLaurent.Challonge
{
    /// <summary>
    /// A context representing a single Challonge account with the tools to create and run tournaments using that account. Some methods are 1:1 bindings to Challonge APIs, while others are abstract connections to Challonge. Either way, each method returns a <see cref="ChallongeResponse"/>.
    /// </summary>
    internal interface IChallongeContext
    {
        #region Account APIs

        ChallongeResponse<ChallongeTournament> CreateTournament(ChallongeTournamentDescriptor tournamentDesc);

        /// <summary>
        /// A tool for syncing the state of a single Challonge tournament (as well as the states of all its associated participants and matches) between HouseLaurent (local) and Challonge (remote).
        /// </summary>
        /// <param name="tournament">The local tournament state.</param>
        /// <param name="participants">A list of all local participant states associated with the tournament.</param>
        /// <param name="matches">A list of all local match states associated with the tournament.</param>
        /// <remarks>
        /// This method is responsible for pushing the following state changes from local to remote:
        /// <list type="bullet">
        /// <item>If the local and remote tournaments have differences, this method MUST update the tournament on remote.</item>
        /// <item>If a participant is tracked by both local and remote with differences, this method MUST update the participant on remote.</item>
        /// <item>If a participant is tracked by local but untracked by remote, this method MUST add the participant to remote.</item>
        /// <item>If a participant is untracked by local but tracked by remote, this method MUST remove the participant from remote.</item>
        /// <item>If a match is tracked by both local and remote with differences, this method MUST update the match on remote.</item>
        /// </list>
        /// The context MUST return an error response if it can't successfully push one or more state changes. Local and remote should only be out-of-sync if something went wrong: a 5xx error, a human manually updating the tournament on challonge.com, a HouseLaurent bug, etc.
        /// </remarks>
        ChallongeResponse<ChallongeSyncResult> SyncTournament(ChallongeTournament tournament, IReadOnlyList<ChallongeParticipant> participants, IReadOnlyList<ChallongeMatch> matches);

        #endregion

        #region Tournament APIs

        ChallongeResponse<ChallongeTournament> GetTournament(int tournamentId);

        ChallongeResponse UpdateTournament(int tournamentId, ChallongeTournamentDescriptor tournamentDesc);

        ChallongeResponse<IReadOnlyList<ChallongeParticipant>> GetParticipants(int tournamentId);

        ChallongeResponse<IReadOnlyList<ChallongeMatch>> GetMatches(int tournamentId);

        ChallongeResponse StartTournament(int tournamentId);

        ChallongeResponse<ChallongeParticipant> RegisterPlayer(int tournamentId, ChallongeParticipantDescriptor participantDesc);

        ChallongeResponse<IReadOnlyList<ChallongeParticipant>> RegisterPlayers(int tournamentId, IReadOnlyList<ChallongeParticipantDescriptor> participantDescs);

        ChallongeResponse ResetTournament(int tournamentId);

        /// <summary>
        /// Finalize all match scores from the ongoing round, thereby prompting Challonge to generate the next round's matches.
        /// </summary>
        /// <param name="tournamentId">The tournament.</param>
        /// <param name="roundMatches">A list of all matches from the ongoing round, each with its final score. If <see cref="ChallongeMatch.Round"/> doesn't match the ongoing round, the match is invalid and this method should return in error.</param>
        /// <param name="preRoundDrops">A list of participant IDs of players that dropped before their match started.</param>
        /// <param name="postRoundDrops">A list of participant IDs of players that dropped after their match ended.</param>
        /// <remarks>
        /// A pre-round drop signifies that the players played zero games in their match, because one player or both players dropped/no-showed after Challonge generated the round.<br/>
        /// A post-round drop signifies that the players played at least one game in the match, before one player or both players dropped. It may instead signify that a player with a bye dropped at any time during the round.<br/>
        /// Use <see cref="UpdateMatch"/> instead to live-update game scores.
        /// </remarks>
        ChallongeResponse FinalizeRound(int tournamentId, IReadOnlyList<ChallongeMatch> roundMatches, IReadOnlyList<int> preRoundDrops, IReadOnlyList<int> postRoundDrops);

        ChallongeResponse FinalizeTournament(int tournamentId);

        #endregion

        #region Participant APIs

        ChallongeResponse<ChallongeParticipant> GetParticipant(int tournamentId, int participantId);

        ChallongeResponse UpdateParticipant(int tournamentId, int participantId, ChallongeParticipantDescriptor participantDesc);

        ChallongeResponse UnregisterParticipant(int tournamentId, int participantId);

        ChallongeResponse CheckInParticipant(int tournamentId, int participantId);

        ChallongeResponse UnCheckInParticipant(int tournamentId, int participantId);

        #endregion

        #region Match APIs

        ChallongeResponse<ChallongeMatch> GetMatch(int tournamentId, int matchId);

        ChallongeResponse MarkMatchUnderway(int tournamentId, int matchId);

        ChallongeResponse UnmarkMatchUnderway(int tournamentId, int matchId);

        /// <summary>
        /// Update a match's score without setting the winner, which is instead the responsibility of <see cref="FinalizeRound"/>.
        /// </summary>
        ChallongeResponse UpdateMatch(int tournamentId, int matchId, int playerAWins, int playerBWins);

        #endregion
    }
}
