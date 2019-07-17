using System;
using System.Collections.Generic;
using System.Linq;

namespace Conways
{
	public class Cell : IEquatable<Cell>
	{
		public int X { get; set; }
		public int Y { get; set; }


		public bool SequenceEqual(Cell neighbour)
		{
			return X == neighbour.X && Y == neighbour.Y;
		}

		public static Cell Of(int x, int y)
		{
			return new Cell {X = x, Y = y};
		}

		public bool Equals(Cell other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Cell) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}
	}

	public class GameOfLife
	{
		private List<Cell> _aliveCells;

		public GameOfLife(List<Cell> seed)
		{
			_aliveCells = seed;
		}

		public IEnumerable<Cell> AliveCells => _aliveCells;

		public IEnumerable<Cell> Tick()
		{
			_aliveCells = Survivors()
				.Union(Births())
				.OrderBy(c => c.Y)
				.ThenBy(c => c.X)
				.ToList();
			return _aliveCells;
		}

		private List<Cell> Survivors()
		{
			var survivors = new List<Cell>();
			foreach (var cell in _aliveCells)
			{
				if (LiveNeighbours(cell).Count() == 2 || LiveNeighbours(cell).Count() == 3)
				{
					survivors.Add(cell);
				}
			}

			return survivors;
		}

		public IEnumerable<Cell> LiveNeighbours(Cell cell)
		{
			return Neighbours(cell)
				.Where(neighbour => _aliveCells.Any(c => c.SequenceEqual(neighbour)))
				.ToList();
		}

		public IEnumerable<Cell> DeadNeighbours(Cell cell)
		{
			return Neighbours(cell)
				.Where(neighbour => !_aliveCells.Any(c => c.SequenceEqual(neighbour)))
				.ToList();
		}

		public IEnumerable<Cell> Neighbours(Cell cell)
		{
			var deltas = new List<Cell>
			{
				Cell.Of(-1, -1),
				Cell.Of(0, -1),
				Cell.Of(1, -1),
				Cell.Of(-1, 0),
				Cell.Of(1, 0),
				Cell.Of(-1, 1),
				Cell.Of(0, 1),
				Cell.Of(1, 1),
			};

			var neighbours = new List<Cell>();
			foreach (var delta in deltas)
			{
				var x = cell.X + delta.X;
				var y = cell.Y + delta.Y;
				neighbours.Add(Cell.Of(x, y));
			}

			return neighbours;
		}

		public IEnumerable<Cell> Births()
		{
			return BirthCandidates()
				.Where(candidate => LiveNeighbours(candidate).Count() == 3)
				.ToList();
		}

		public IEnumerable<Cell> BirthCandidates()
		{
			var deadWithOneLiveNeighbour = new List<List<Cell>>();
			foreach (var cell in _aliveCells)
			{
				deadWithOneLiveNeighbour.Add(new List<Cell>(DeadNeighbours(cell)));
			}

			return deadWithOneLiveNeighbour.SelectMany(list => list)
				.GroupBy(g => new {X = g.X, Y = g.Y})
				.Select(g => g.First())
				.ToList();
		}
	}
}