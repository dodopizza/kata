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
		public Tile(Coordinate coordinate, char symbol)
		{
			Coordinate = coordinate;
			Symbol = symbol;
		}

		public Coordinate Coordinate { get; }
		public char Symbol { get; set; }

		public bool IsSame(Coordinate coordinate)
		{
			return Coordinate.X == coordinate.X && Coordinate.Y == coordinate.Y;
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
					_plays.Add(new Tile(new Coordinate(i, j), ' '));
				}
			}
		}

		public Tile TileAt(Coordinate coordinate)
		{
			return _plays.Single(tile => tile.IsSame(coordinate));
		}

		public void AddTileAt(char symbol, Coordinate coordinate)
		{
			_plays.Single(tile => tile.IsSame(coordinate)).Symbol = symbol;
		}
	}

	public class Game
	{
		private char _lastSymbol = ' ';
		private Board _board = new Board();

		public void Play(char symbol, Coordinate coordinate)
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
			else if (IsNotFirstMoveButPlayerAlreadyPlayedTile(coordinate))
			{
				throw new Exception("Invalid position");
			}

			UpdateGameState(symbol, coordinate);
		}

		private void UpdateGameState(char symbol, Coordinate coordinate)
		{
			_lastSymbol = symbol;
			_board.AddTileAt(symbol, coordinate);
		}

		private bool IsNotFirstMoveButPlayerAlreadyPlayedTile(Coordinate coordinate)
		{
			return _board.TileAt(coordinate).Symbol != ' ';
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