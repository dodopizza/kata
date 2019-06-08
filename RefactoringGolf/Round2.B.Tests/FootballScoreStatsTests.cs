using Xunit;

namespace Round2.B.Tests
{
    public class FootballScoreStatsTests
    {
        [Fact]
        public void TotalsFootballScoresForTeam()
        {
            FootballScoreStats stats = new FootballScoreStats(new FootballData());
            Assert.Equal(6, stats.TeamTotal("Liverpool"));
        }
    }
}
