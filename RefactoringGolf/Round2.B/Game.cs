using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round2.B
{
    public class Game
    {

        private readonly String _homeTeam;
        private readonly int _homeTeamScore;
        private readonly String _awayTeam;
        private readonly int _awayTeamScore;

        public Game(String homeTeam, int homeTeamScore, String awayTeam, int awayTeamScore)
        {
            this._homeTeam = homeTeam;
            this._homeTeamScore = homeTeamScore;
            this._awayTeam = awayTeam;
            this._awayTeamScore = awayTeamScore;
        }

        public int GetTeamScore(string teamName)
        {
            int teamScore = 0;
            if (_homeTeam.Equals(teamName))
            {
                teamScore = _homeTeamScore;
            }
            if (_awayTeam.Equals(teamName))
            {
                teamScore = _awayTeamScore;
            }
            return teamScore;
        }
    }

}
