using System.Collections.Generic;
using Xunit;

namespace Conways.Tests
{
	public class FieldOfCellsTests
	{
		[Fact]
		public void It_gets_the_live_neighbours()
		{
			var seed = new List<Cell> {Cell.Of(1, 0), Cell.Of(2, 0)};
			var fieldOfCells = new FieldOfCells(seed);
			var liveNeighbours = fieldOfCells.LiveNeighbours(Cell.Of(1, 0));
			Assert.Equal(new List<Cell> {Cell.Of(2, 0)}, liveNeighbours);
		}
		
		[Fact]
		public void It_gets_birth_candidates()
		{
			var seed = new List<Cell> {Cell.Of(0, 0)};
			var game = new FieldOfCells(seed);
			var candidates = game.BirthCandidates();
			Assert.Equal(Cell.Of(0, 0).Neighbours(), candidates);
		}

		[Fact]
		public void It_ticks_with_a_birth()
		{
			var seed = new List<Cell> {Cell.Of(2, 0), Cell.Of(1, 1), Cell.Of(2, 1)};
			var game = new FieldOfCells(seed);
			var births = game.Births();
			Assert.Equal(new List<Cell> {Cell.Of(1, 0)}, births);
		}
	}
}