using FootballScoreboard.Core.Models;

namespace FootballScoreboard.Core.Interfaces
{
	public interface IScoreboard
	{
		Match StartNewMatch(string homeTeam, string awayTeam);

		void UpdateMatchScore(Guid matchId, int homeTeamScore, int awayTeamScore);

		void FinishMatch(Guid matchId);

		IEnumerable<string> GetSummary();
	}
}