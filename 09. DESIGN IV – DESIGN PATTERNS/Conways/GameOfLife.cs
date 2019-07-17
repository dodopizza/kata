using System.Collections.Generic;
using System.Linq;

namespace Conways
{
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
				.GroupBy(g => new {X = g.X, Y = g.Y})
				.Select(g => g.First())
				.ToList();
		}
	}
}