using FootballScoreboard.Core.Interfaces;

namespace FootballScoreboard.Core.Models
{
	public class Scoreboard : IScoreboard
	{
		public Match StartNewMatch(string homeTeam, string awayTeam)
		{
			throw new NotImplementedException();
		}

		public void UpdateMatchScore(Guid matchId, int homeTeamScore, int awayTeamScore)
		{
			throw new NotImplementedException();
		}

		public void FinishMatch(Guid matchId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GetSummary()
		{
			throw new NotImplementedException();
		}
	}
}