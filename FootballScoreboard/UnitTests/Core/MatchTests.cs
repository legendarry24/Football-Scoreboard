using FootballScoreboard.Core.Models;
using Xunit;

namespace FootballScoreboard.UnitTests.Core
{
	public class MatchTests
	{
		private const string teamA = "TeamA";
		private const string teamB = "TeamB";

		[Fact]
		public void Ctor_SetsTeamsInitialScoreAndStartTime()
		{
			var match = new Match(teamA, teamB);

			Assert.Equal(teamA, match.HomeTeam);
			Assert.Equal(teamB, match.AwayTeam);
			Assert.Equal(0, match.HomeTeamScore);
			Assert.Equal(0, match.AwayTeamScore);
			Assert.NotEqual(default, match.StartTime);
		}

		[Fact]
		public void UpdateScore_UpdatesMatchScores()
		{
			var match = new Match(teamA, teamB);

			match.UpdateScore(3, 1);

			Assert.Equal(3, match.HomeTeamScore);
			Assert.Equal(1, match.AwayTeamScore);
		}

		[Fact]
		public void UpdateScore_WhenPassedScoreLessThanZero_ThrowsArgumentException()
		{
			var match = new Match(teamA, teamB);

			Action act = () => match.UpdateScore(-2, 0);

			ArgumentException exception = Assert.Throws<ArgumentException>(act);
			Assert.Equal("team score cannot be less than zero", exception.Message);
		}

		[Fact]
		public void ToString_ReturnsMatchSummary()
		{
			const string expectedSummary = $"{teamA} 5 - {teamB} 0";

			var match = new Match(teamA, teamB);
			match.UpdateScore(5, 0);

			var result = match.ToString();

			Assert.Equal(expectedSummary, result);
		}
	}
}