using Domain;
using FluentAssertions;

namespace UnitTests
{
	internal class FixedStringSpySource: ISource
	{
		private readonly string _returningString;
		private int _counter;

		public FixedStringSpySource(string returningString)
		{
			_returningString = returningString;
		}

		public char GetChar()
		{
			return _returningString[_counter++];
		}


		public void ShouldBeCalledTimes(int i)
		{
			i.Should().Be(_counter);
		}
	}
}