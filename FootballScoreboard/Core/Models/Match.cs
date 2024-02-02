namespace FootballScoreboard.Core.Models
{
	public class Match
	{
		public Guid Id { get; }

		public string HomeTeam { get; }

		public string AwayTeam { get; }

		public int HomeTeamScore { get; private set; }

		public int AwayTeamScore { get; private set; }

		public DateTime StartTime { get; }

		public Match(string homeTeam, string awayTeam) {}

		public void UpdateScore(int homeTeamScore, int awayTeamScore)
		{
			throw new NotImplementedException();
		}
	}
}