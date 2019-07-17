using System.Collections.Generic;
using System.Linq;
using Conways;
using Xunit;

namespace Conways.Tests
{
	public class GameOfLifeTests
	{
		[Fact]
		public void It_generates_the_next_iteration_with_an_empty_seed()
		{
			var seed = new List<Cell>();
			var game = new GameOfLife(seed);
			var nextGeneration = game.Tick();
			Assert.Equal(new List<Cell>(), nextGeneration);
		}

		[Fact]
		public void It_ticks_with_a_death()
		{
			var seed = new List<Cell> {Cell.Of(1, 0)};
			var game = new GameOfLife(seed);
			game.Tick();
			Assert.Equal(new List<Cell>(), game.AliveCells);
		}

		[Fact]
		public void It_gets_the_neighbours_of_the_origin()
		{
			var seed = new List<Cell> {Cell.Of(0, 0)};
			var game = new GameOfLife(seed);
			var neighbours = game.Neighbours(Cell.Of(0, 0)).ToList();
			Assert.Equal(8, neighbours.Count);
			Assert.DoesNotContain(Cell.Of(0, 0), neighbours);
			Assert.Contains(Cell.Of(-1, -1), neighbours);
			Assert.Contains(Cell.Of(0, -1), neighbours);
			Assert.Contains(Cell.Of(1, -1), neighbours);
			Assert.Contains(Cell.Of(-1, 0), neighbours);
			Assert.Contains(Cell.Of(1, 0), neighbours);
			Assert.Contains(Cell.Of(-1, 1), neighbours);
			Assert.Contains(Cell.Of(0, 1), neighbours);
			Assert.Contains(Cell.Of(1, 1), neighbours);
		}

		[Fact]
		public void It_gets_the_neighbours_of_a_given_cell()
		{
			var seed = new List<Cell> {Cell.Of(1, 0)};
			var game = new GameOfLife(seed);
			var neighbours = game.Neighbours(Cell.Of(1, 0)).ToList();
			Assert.Equal(8, neighbours.Count);
			Assert.DoesNotContain(Cell.Of(1, 0), neighbours);
			Assert.Contains(Cell.Of(0, -1), neighbours);
			Assert.Contains(Cell.Of(1, -1), neighbours);
			Assert.Contains(Cell.Of(2, -1), neighbours);
			Assert.Contains(Cell.Of(0, 0), neighbours);
			Assert.Contains(Cell.Of(2, 0), neighbours);
			Assert.Contains(Cell.Of(0, 1), neighbours);
			Assert.Contains(Cell.Of(1, 1), neighbours);
			Assert.Contains(Cell.Of(2, 1), neighbours);
		}

		[Fact]
		public void It_gets_the_live_neighbours()
		{
			var seed = new List<Cell> {Cell.Of(1, 0), Cell.Of(2, 0)};
			var game = new GameOfLife(seed);
			var liveNeighbours = game.LiveNeighbours(Cell.Of(1, 0));
			Assert.Equal(new List<Cell> {Cell.Of(2, 0)}, liveNeighbours);
		}

		[Fact]
		public void It_ticks_with_a_survival()
		{
			var seed = new List<Cell> {Cell.Of(1, 0), Cell.Of(2, 0), Cell.Of(1, 1), Cell.Of(2, 1)};
			var game = new GameOfLife(seed);
			game.Tick();
			Assert.Equal(new List<Cell> {Cell.Of(1, 0), Cell.Of(2, 0), Cell.Of(1, 1), Cell.Of(2, 1)}, game.AliveCells);
		}

		[Fact]
		public void It_gets_birth_candidates()
		{
			var seed = new List<Cell> {Cell.Of(0, 0)};
			var game = new GameOfLife(seed);
			var candidates = game.BirthCandidates();
			Assert.Equal(game.Neighbours(Cell.Of(0, 0)), candidates);
		}

		[Fact]
		public void It_ticks_with_a_birth()
		{
			var seed = new List<Cell> {Cell.Of(2, 0), Cell.Of(1, 1), Cell.Of(2, 1)};
			var game = new GameOfLife(seed);
			var births = game.Births();
			Assert.Equal(new List<Cell> {Cell.Of(1, 0)}, births);
		}

		[Fact]
		public void It_generates_the_blinker_pattern()
		{
			var seed = new List<Cell> {Cell.Of(1, 0), Cell.Of(1, 1), Cell.Of(1, 2)};
			var game = new GameOfLife(seed);
			var secondGeneration = game.Tick();
			var thirdGeneration = game.Tick();
			Assert.Equal(new List<Cell> {Cell.Of(0, 1), Cell.Of(1, 1), Cell.Of(2, 1)}, secondGeneration);
			Assert.Equal(new List<Cell> {Cell.Of(1, 0), Cell.Of(1, 1), Cell.Of(1, 2)}, thirdGeneration);
		}
	}
}