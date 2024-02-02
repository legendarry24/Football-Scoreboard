using FootballScoreboard.Core.Models;

namespace FootballScoreboard.Core.Interfaces
{
	public interface IScoreboard
	{
		Match StartNewMatch(string homeTeam, string awayTeam);

		void UpdateMatchScore(IMatch match, int homeTeamScore, int awayTeamScore);

		void FinishMatch(IMatch match);

		string GetSummary();
	}
}