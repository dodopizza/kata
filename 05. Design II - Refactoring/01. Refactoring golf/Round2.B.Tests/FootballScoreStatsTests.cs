using Xunit;

namespace Round2.B.Tests
{
    public class FootballScoreStatsTests
    {
        [Fact]
        public void TotalsFootballScoresForTeam()
        {
            var stats = new FootballScoreStats(new FootballData());
            Assert.Equal(6, stats.TeamTotal("Liverpool"));
        }
    }
}
