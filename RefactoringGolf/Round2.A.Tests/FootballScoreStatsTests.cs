using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Round2.A.Tests
{
    public class FootballScoreStatsTests
    {
        [Fact]
        public void TotalsFootballScoresForTeam()
        {
            FootballScoreStats stats = new FootballScoreStats();
            Assert.Equal(6, stats.TeamTotal("Liverpool"));
        }
    }
}
