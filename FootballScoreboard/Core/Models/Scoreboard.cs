using System.Text.RegularExpressions;
using FootballScoreboard.Core.Interfaces;

namespace FootballScoreboard.Core.Models
{
	public class Scoreboard : IScoreboard
	{
		private readonly List<Match> _matches = new List<Match>();

		public Match StartNewMatch(string homeTeam, string awayTeam)
		{
			var match = new Match(homeTeam, awayTeam);

			_matches.Add(match);

			return match;
		}

		public void UpdateMatchScore(Guid matchId, int homeTeamScore, int awayTeamScore)
		{
			var match = _matches.Find(match => match.Id == matchId);

			match?.UpdateScore(homeTeamScore, awayTeamScore);
		}

		public int GetTeamScore(string teamName)
		{
			var match = _matches.Find(m => m.HomeTeam == teamName);
			if (match is not null)
			{
				return match.HomeTeamScore;
			}

			match = _matches.Find(m => m.AwayTeam == teamName);
			if (match is not null)
			{
				return match.AwayTeamScore;
			}

			throw new Exception("the team wasn't found");
		}

		public void FinishMatch(Guid matchId)
		{
			var match = _matches.Find(match => match.Id == matchId);

			if (match != null)
			{
				_matches.Remove(match);
			}
		}

		public IEnumerable<string> GetSummary()
		{
			return _matches
				.OrderByDescending(match => match.HomeTeamScore + match.AwayTeamScore)
				.ThenBy(match => match.StartTime)
				.Select(match => match.ToString());
		}
	}
}