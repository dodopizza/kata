using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round2.A
{
    public class FootballScoreStats
    {

        public int TeamTotal(String teamName)
        {
            int total = 0;
            Game[] played = FootballData.GetAllPlayed();
            foreach (Game game in played)
            {
                if (game.HomeTeam.Equals(teamName))
                {
                    total += game.HomeTeamScore;
                }
                if (game.AwayTeam.Equals(teamName))
                {
                    total += game.AwayTeamScore;
                }
            }
            return total;
	}

    }
}
