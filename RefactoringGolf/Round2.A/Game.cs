using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round2.A
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

        public string HomeTeam
        {
            get { return _homeTeam; }
        }

        public int HomeTeamScore
        {
            get { return _homeTeamScore; }
        }

        public string AwayTeam
        {
            get { return _awayTeam; }
        }

        public int AwayTeamScore
        {
            get { return _awayTeamScore; }
        }
    }

}
