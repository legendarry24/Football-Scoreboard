using FootballScoreboard.Core.Interfaces;

namespace FootballScoreboard.Core.Models
{
	public class Scoreboard : IScoreboard
	{
		public Match StartNewMatch(string homeTeam, string awayTeam)
		{
			throw new NotImplementedException();
		}

		public void UpdateMatchScore(IMatch match, int homeTeamScore, int awayTeamScore)
		{
			throw new NotImplementedException();
		}

		public void FinishMatch(IMatch match)
		{
			throw new NotImplementedException();
		}

		public string GetSummary()
		{
			throw new NotImplementedException();
		}
	}
}