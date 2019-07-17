using System;
using System.Collections.Generic;

namespace Conways
{
	public class Cell : IEquatable<Cell>
	{
		public int X { get; }
		public int Y { get; }

		public Cell(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool SequenceEqual(Cell neighbour)
		{
			return X == neighbour.X && Y == neighbour.Y;
		}

		public static Cell Of(int x, int y)
		{
			return new Cell (x, y);
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
			if (obj.GetType() != GetType()) return false;
			return Equals((Cell) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}
		
		public IEnumerable<Cell> Neighbours()
		{
			var deltas = new List<Cell>
			{
				Of(-1, -1),
				Of(0, -1),
				Of(1, -1),
				Of(-1, 0),
				Of(1, 0),
				Of(-1, 1),
				Of(0, 1),
				Of(1, 1),
			};

			var neighbours = new List<Cell>();
			foreach (var delta in deltas)
			{
				var x = X + delta.X;
				var y = Y + delta.Y;
				neighbours.Add(Of(x, y));
			}

			return neighbours;
		}
	}
}