using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private readonly List<Tile> tiles = new List<Tile>();
       
        public Board()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var coordinate = new Coordinate(i, j);
                    tiles.Add(new Tile(coordinate));
                }  
            }       
        }
        public Tile TileAt(int x, int y)
        {
            return tiles.Single(tile => tile.Coordinate.Equals(new Coordinate(x, y)));
        }

        public void AddTileAt(char symbol, int x, int y)
        {
            var tile = tiles.Single(_ => _.Coordinate.Equals(new Coordinate(x, y)));
            tile.Play(symbol);
        }
    }
}