using System.Collections.Generic;
using System.Linq;

namespace Conways
{
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
			_fieldOfCells = new FieldOfCells(_fieldOfCells.Survivors()
				.Union(_fieldOfCells.Births())
				.OrderBy(c => c.Y)
				.ThenBy(c => c.X)
				.ToList());
			return _fieldOfCells;
		}



		

		

		

		
	}
}