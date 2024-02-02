namespace FootballScoreboard.Core.Models
{
	public class Match
	{
		public Match(string homeTeam, string awayTeam)
		{
			Id = Guid.NewGuid();

			HomeTeam = homeTeam;
			AwayTeam = awayTeam;

			// assuming initial score 0 – 0
			HomeTeamScore = 0;
			AwayTeamScore = 0;

			// Assuming a match starts at the current time
			StartTime = DateTime.Now;
		}

		public Guid Id { get; }

		public string HomeTeam { get; }

		public string AwayTeam { get; }

		public int HomeTeamScore { get; private set; }

		public int AwayTeamScore { get; private set; }

		public DateTime StartTime { get; }

		public void UpdateScore(int homeTeamScore, int awayTeamScore)
		{
			if (homeTeamScore < 0 || awayTeamScore < 0)
			{
				throw new ArgumentException("team score cannot be less than zero");
			}

			HomeTeamScore = homeTeamScore;
			AwayTeamScore = awayTeamScore;
		}

		public override string ToString()
		{
			return $"{HomeTeam} {HomeTeamScore} - {AwayTeam} {AwayTeamScore}";
		}
	}
}