using System.Collections.Generic;

namespace Conways
{
	public interface INeighboursStrategy
	{
		IEnumerable<Cell> Get(IEnumerable<Cell> neighbours, IEnumerable<Cell> aliveCells);
	}
}