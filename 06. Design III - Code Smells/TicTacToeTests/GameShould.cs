using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
	public class GameShould
	{
		private Game game;

		public GameShould()
		{
			game = new Game();
		}

		[Fact]
		public void NotAllowPlayerOToPlayFirst()
		{
			Action wrongPlay = () => game.Play('O', new Coordinate(0, 0));

			var exception = Assert.Throws<Exception>(wrongPlay);
			Assert.Equal("Invalid first player", exception.Message);
		}

		[Fact]
		public void NotAllowPlayerXToPlayTwiceInARow()
		{
			game.Play('X', new Coordinate(0, 0));

			Action wrongPlay = () => game.Play('X', new Coordinate(1, 0));

			var exception = Assert.Throws<Exception>(wrongPlay);
			Assert.Equal("Invalid next player", exception.Message);
		}

		[Fact]
		public void NotAllowPlayerToPlayInLastPlayedPosition()
		{
			game.Play('X', new Coordinate(0, 0));

			Action wrongPlay = () => game.Play('O', new Coordinate(0, 0));

			var exception = Assert.Throws<Exception>(wrongPlay);
			Assert.Equal("Invalid position", exception.Message);
		}

		[Fact]
		public void NotAllowPlayerToPlayInAnyPlayedPosition()
		{
			game.Play('X', new Coordinate(0, 0));
			game.Play('O', new Coordinate(1, 0));

			Action wrongPlay = () => game.Play('X', new Coordinate(0, 0));

			var exception = Assert.Throws<Exception>(wrongPlay);
			Assert.Equal("Invalid position", exception.Message);
		}

		[Fact]
		public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
		{
			game.Play('X', new Coordinate(0, 0));
			game.Play('O', new Coordinate(1, 0));
			game.Play('X', new Coordinate(0, 1));
			game.Play('O', new Coordinate(1, 1));
			game.Play('X', new Coordinate(0, 2));

			var winner = game.Winner();

			Assert.Equal('X', winner);
		}

		[Fact]
		public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
		{
			game.Play('X', new Coordinate(2, 2));
			game.Play('O', new Coordinate(0, 0));
			game.Play('X', new Coordinate(1, 0));
			game.Play('O', new Coordinate(0, 1));
			game.Play('X', new Coordinate(1, 1));
			game.Play('O', new Coordinate(0, 2));

			var winner = game.Winner();

			Assert.Equal('O', winner);
		}

		[Fact]
		public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
		{
			game.Play('X', new Coordinate(1, 0));
			game.Play('O', new Coordinate(0, 0));
			game.Play('X', new Coordinate(1, 1));
			game.Play('O', new Coordinate(0, 1));
			game.Play('X', new Coordinate(1, 2));

			var winner = game.Winner();

			Assert.Equal('X', winner);
		}

		[Fact]
		public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
		{
			game.Play('X', new Coordinate(0, 0));
			game.Play('O', new Coordinate(1, 0));
			game.Play('X', new Coordinate(2, 0));
			game.Play('O', new Coordinate(1, 1));
			game.Play('X', new Coordinate(2, 1));
			game.Play('O', new Coordinate(1, 2));

			var winner = game.Winner();

			Assert.Equal('O', winner);
		}

		[Fact]
		public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
		{
			game.Play('X', new Coordinate(2, 0));
			game.Play('O', new Coordinate(0, 0));
			game.Play('X', new Coordinate(2, 1));
			game.Play('O', new Coordinate(0, 1));
			game.Play('X', new Coordinate(2, 2));

			var winner = game.Winner();

			Assert.Equal('X', winner);
		}

		[Fact]
		public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
		{
			game.Play('X', new Coordinate(0, 0));
			game.Play('O', new Coordinate(2, 0));
			game.Play('X', new Coordinate(1, 0));
			game.Play('O', new Coordinate(2, 1));
			game.Play('X', new Coordinate(1, 1));
			game.Play('O', new Coordinate(2, 2));

			var winner = game.Winner();

			Assert.Equal('O', winner);
		}
	}
}