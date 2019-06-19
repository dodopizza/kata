using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
	public class Coordinate
	{
		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }
	}

	public class Tile
	{
		public Tile(int x, int y, char symbol)
		{
			Coordinate = new Coordinate(x, y);
			Symbol = symbol;
		}

		public Coordinate Coordinate { get; set; }
		public int X => Coordinate.X;
		public int Y => Coordinate.Y;
		public char Symbol { get; set; }

		public bool IsSame(Coordinate coordinate)
		{
			return X == coordinate.X && Y == coordinate.Y;
		}


	}

	public class Board
	{
		private List<Tile> _plays = new List<Tile>();

		public Board()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_plays.Add(new Tile(i, j, ' '));
				}
			}
		}

		public Tile TileAt(Coordinate coordinate)
		{
			return _plays.Single(tile => tile.IsSame(coordinate));
		}

		public void AddTileAt(char symbol, int x, int y)
		{
			var newTile = new Tile(x, y, symbol);

			_plays.Single(tile => tile.IsSame(new Coordinate(x, y))).Symbol = symbol;
		}
	}

	public class Game
	{
		private char _lastSymbol = ' ';
		private Board _board = new Board();

		public void Play(char symbol, int x, int y)
		{
			if (IsFirstMove())
			{
				if (IsPlayerX(symbol))
				{
					throw new Exception("Invalid first player");
				}
			}
			else if (IsNotFirstMoveButPlayerRepeated(symbol))
			{
				throw new Exception("Invalid next player");
			}
			else if (IsNotFirstMoveButPlayerAlreadyPlayedTile(x, y))
			{
				throw new Exception("Invalid position");
			}

			UpdateGameState(symbol, x, y);
		}

		private void UpdateGameState(char symbol, int x, int y)
		{
			_lastSymbol = symbol;
			_board.AddTileAt(symbol, x, y);
		}

		private bool IsNotFirstMoveButPlayerAlreadyPlayedTile(int x, int y)
		{
			return _board.TileAt(new Coordinate(x, y)).Symbol != ' ';
		}

		private bool IsNotFirstMoveButPlayerRepeated(char symbol)
		{
			return symbol == _lastSymbol;
		}

		private static bool IsPlayerX(char symbol)
		{
			return symbol == 'O';
		}

		private bool IsFirstMove()
		{
			return _lastSymbol == ' ';
		}

		public char Winner()
		{
			if (IsFirstRowFilled())
			{
				if (IsFirstRowFullSameSymbol())
				{
					return _board.TileAt(new Coordinate(0, 0)).Symbol;
				}
			}

			if (IsSecondRowFilled())
			{
				if (IsMiddleRowFullSameSymbol())
				{
					return _board.TileAt(new Coordinate(1, 0)).Symbol;
				}
			}

			if (IsThirdRowFilled())
			{
				if (IsThirdRowSameSymbol())
				{
					return _board.TileAt(new Coordinate(2, 0)).Symbol;
				}
			}

			return ' ';
		}

		private bool IsFirstRowFilled()
		{
			return _board.TileAt(new Coordinate(0, 0)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(0, 1)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(0, 2)).Symbol != ' ';
		}

		private bool IsSecondRowFilled()
		{
			return _board.TileAt(new Coordinate(1, 0)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(1, 1)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(1, 2)).Symbol != ' ';
		}

		private bool IsThirdRowFilled()
		{
			return _board.TileAt(new Coordinate(2, 0)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(2, 1)).Symbol != ' ' &&
			       _board.TileAt(new Coordinate(2, 2)).Symbol != ' ';
		}

		private bool IsFirstRowFullSameSymbol()
		{
			return _board.TileAt(new Coordinate(0, 0)).Symbol ==
			       _board.TileAt(new Coordinate(0, 1)).Symbol &&
			       _board.TileAt(new Coordinate(0, 2)).Symbol ==
			       _board.TileAt(new Coordinate(0, 1)).Symbol;
		}

		private bool IsMiddleRowFullSameSymbol()
		{
			return _board.TileAt(new Coordinate(1, 0)).Symbol ==
			       _board.TileAt(new Coordinate(1, 1)).Symbol &&
			       _board.TileAt(new Coordinate(1, 2)).Symbol ==
			       _board.TileAt(new Coordinate(1, 1)).Symbol;
		}

		private bool IsThirdRowSameSymbol()
		{
			return _board.TileAt(new Coordinate(2, 0)).Symbol ==
			       _board.TileAt(new Coordinate(2, 1)).Symbol &&
			       _board.TileAt(new Coordinate(2, 2)).Symbol ==
			       _board.TileAt(new Coordinate(2, 1)).Symbol;
		}
	}
}