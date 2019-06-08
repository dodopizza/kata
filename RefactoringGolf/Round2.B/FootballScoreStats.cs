using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round2.B
{
    public class FootballScoreStats
    {
        private readonly IGameData _data;

        public FootballScoreStats(IGameData data)
        {
            _data = data;
        }

        public int TeamTotal(String teamName)
        {
            Game[] played = _data.GetAllPlayed();
            return played.Sum(game => game.GetTeamScore(teamName));
	}
    }
}
