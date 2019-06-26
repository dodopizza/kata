using Domain;
using FluentAssertions;

namespace UnitTests
{
	internal class SpyDestination : IDestination
	{
		private char _character;

		public void SetChar(char character)
		{
			_character = character;
		}

		public void CalledWithChar(char expected)
		{
			expected.Should().Be(_character);
		}
	}
}