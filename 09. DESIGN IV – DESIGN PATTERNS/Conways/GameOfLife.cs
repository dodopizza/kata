using System.Collections.Generic;
using System.Linq;

namespace Conways
{
	public class LiveCellsStrategy : INeighboursStrategy
	{
		public IEnumerable<Cell> Get(IEnumerable<Cell> neighbours, IEnumerable<Cell> aliveCells)
		{
			return neighbours
				.Where(neighbour => aliveCells.Any(c => c.SequenceEqual(neighbour)))
				.ToList();
		}
	}

	public class GameOfLife
	{
		private FieldOfCells _fieldOfCells;

		public GameOfLife(List<Cell> seed)
		{
			_fieldOfCells = new FieldOfCells(seed);
		}

		public IEnumerable<Cell> AliveCells => _fieldOfCells._aliveCells;

		public FieldOfCells Tick()
		{
			_fieldOfCells = new FieldOfCells(Survivors()
				.Union(_fieldOfCells.Births())
				.OrderBy(c => c.Y)
				.ThenBy(c => c.X)
				.ToList());
			return _fieldOfCells;
		}

		public List<Cell> Survivors()
		{
			var survivors = new List<Cell>();
			foreach (var cell in _fieldOfCells._aliveCells)
			{
				var countOfLifeNeighbours = _fieldOfCells.Neighbours(cell, new LiveCellsStrategy()).Count();
				if (countOfLifeNeighbours == 2 || countOfLifeNeighbours == 3)
				{
					survivors.Add(cell);
				}
			}

			return survivors;
		}
	}
}