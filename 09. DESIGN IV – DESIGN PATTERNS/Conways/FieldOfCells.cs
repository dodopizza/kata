using System;
using System.Collections.Generic;
using System.Linq;

namespace Conways
{
	public class FieldOfCells : IEquatable<FieldOfCells>
	{
		public List<Cell> _aliveCells { get; set; }

		public FieldOfCells(List<Cell> cells)
		{
			_aliveCells = cells;
		}

		public bool Equals(FieldOfCells other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return _aliveCells.SequenceEqual(other._aliveCells);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((FieldOfCells) obj);
		}

		public override int GetHashCode()
		{
			return (_aliveCells != null ? _aliveCells.GetHashCode() : 0);
		}

		public IEnumerable<Cell> Neighbours(Cell cell, INeighboursStrategy strategy)
		{
			return strategy.Get(cell.Neighbours(), _aliveCells);
		}

		
		public IEnumerable<Cell> LiveNeighbours(Cell cell)
		{
			return cell.Neighbours()
				.Where(neighbour => _aliveCells.Any(c => c.SequenceEqual(neighbour)))
				.ToList();
		}
		
		public IEnumerable<Cell> DeadNeighbours(Cell cell)
		{
			return cell.Neighbours()
				.Where(neighbour => !_aliveCells.Any(c => c.SequenceEqual(neighbour)))
				.ToList();
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
				.GroupBy(g => new {g.X, g.Y})
				.Select(g => g.First())
				.ToList();
		}



	}
}