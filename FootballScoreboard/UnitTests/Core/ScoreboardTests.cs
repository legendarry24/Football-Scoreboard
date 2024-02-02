using FootballScoreboard.Core.Models;
using Xunit;

namespace FootballScoreboard.UnitTests.Core
{
	public class ScoreboardTests
	{
		private const string teamA = "TeamA";
		private const string teamB = "TeamB";

		[Fact]
		public void StartNewMatch_WhenMatchStarted_AddsMatchToScoreboard()
		{
			var scoreboard = new Scoreboard();

			Match match = scoreboard.StartNewMatch(teamA, teamB);

			var summary = scoreboard.GetSummary().ToArray();
			Assert.Single(summary);
			Assert.Equal(match.ToString(), summary.Single());
		}

		[Fact]
		public void UpdateMatchScore_WhenScoreboardContainsMatch_UpdatesMatchScores()
		{
			var scoreboard = new Scoreboard();
			Match match = scoreboard.StartNewMatch(teamA, teamB);

			scoreboard.UpdateMatchScore(match.Id, 2, 1);

			Assert.Equal(2, match.HomeTeamScore);
			Assert.Equal(1, match.AwayTeamScore);
		}

		[Fact]
		public void UpdateMatchScore_WhenScoreboardNotContainsMatch_NotUpdatesMatchScores()
		{
			var scoreboard = new Scoreboard();
			var match = new Match(teamA, teamB);

			scoreboard.UpdateMatchScore(match.Id, 2, 1);

			Assert.NotEqual(2, match.HomeTeamScore);
			Assert.NotEqual(1, match.AwayTeamScore);
		}

		[Fact]
		public void FinishMatch_WhenScoreboardContainsMatch_RemovesMatchFromScoreboard()
		{
			var scoreboard = new Scoreboard();
			Match match1 = scoreboard.StartNewMatch("TeamA", "TeamB");
			Match match2 = scoreboard.StartNewMatch("TeamC", "TeamD");

			scoreboard.FinishMatch(match1.Id);

			var summary = scoreboard.GetSummary().ToArray();
			Assert.Single(summary);
			Assert.Equal(match2.ToString(), summary.Single());
		}

		[Fact]
		public void GetSummary_WhenNoMatchesInProgress_ReturnsEmptySummary()
		{
			var scoreboard = new Scoreboard();

			var summary = scoreboard.GetSummary();

			Assert.Empty(summary);
		}

		[Fact]
		public void GetSummary_WhenScoreboardContainsMatches_ReturnsOrderedSummary()
		{
			var scoreboard = new Scoreboard();
			Match match1 = scoreboard.StartNewMatch("TeamA", "TeamB");
			Match match2 = scoreboard.StartNewMatch("TeamC", "TeamD");
			Match match3 = scoreboard.StartNewMatch("TeamX", "TeamY");
			scoreboard.UpdateMatchScore(match1.Id, 1, 0);
			scoreboard.UpdateMatchScore(match2.Id, 3, 2);
			scoreboard.UpdateMatchScore(match3.Id, 5, 0);
			string[] expectedSummary = { match2.ToString(), match3.ToString(), match1.ToString() };

			var actualSummary = scoreboard.GetSummary().ToArray();

			Assert.Equal(expectedSummary, actualSummary);
		}
	}
}