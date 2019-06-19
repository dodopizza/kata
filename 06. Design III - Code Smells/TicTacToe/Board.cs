using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile{ X = i, Y = j, Symbol = ' '});
                }  
            }       
        }
        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.X == x && tile.Y == y);
        }

        public void AddTileAt(char symbol, int x, int y)
        {
            var newTile = new Tile
            {
                X = x,
                Y = y,
                Symbol = symbol
            };

            _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
        }
    }
}