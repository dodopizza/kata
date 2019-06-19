using System;

namespace TicTacToe
{
    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();

        public void Play(char symbol, int x, int y)
        {
            if (isFirstMove())
            {
                if (playerIsO(symbol))
                {
                    throw new Exception("Invalid first player");
                }
            }
            else if (isPlayerRepeated(symbol))
            {
                throw new Exception("Invalid next player");
            }
            else if (playOnAlreadyPlayedTile(x, y))
            {
                throw new Exception("Invalid position");
            }

            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private bool playOnAlreadyPlayedTile(int x, int y)
        {
            return _board.TileAt(x, y).Symbol != ' ';
        }

        private bool isPlayerRepeated(char symbol)
        {
            return symbol == _lastSymbol;
        }

        private static bool playerIsO(char symbol)
        {
            return symbol == 'O';
        }

        private bool isFirstMove()
        {
            return _lastSymbol == ' ';
        }

        public char Winner()
        {
            for (var row = 0; row <= 2; row++)
            {
                if (isRowFullWithSameSymbol(row))
                {
                    return _board.TileAt(row, 0).Symbol;
                }
            }

            return ' ';
        }

        private bool isRowFullWithSameSymbol(int row)
        {
            return _board.TileAt(row, 0).Symbol == _board.TileAt(row, 1).Symbol &&
                   _board.TileAt(row, 2).Symbol == _board.TileAt(row, 1).Symbol &&
                   _board.TileAt(row, 0).Symbol != ' ';
        }
    }
}