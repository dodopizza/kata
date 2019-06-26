using Domain;
using FluentAssertions;

namespace UnitTests
{
	internal class SpySource: ISource
	{
		private readonly string _returningString;
		private bool _wasCalled;
		private int _counter;

		public SpySource(string returningString)
		{
			_returningString = returningString;
		}

		public SpySource()
		{
			_returningString = "saa";
		}

		public char GetChar()
		{
			_wasCalled = true;
			return _returningString[_counter++];
		}

		public void VerifyGetChar()
		{
			_wasCalled.Should().BeTrue();
		}

		public void ShouldBeCalledTimes(int i)
		{
			i.Should().Be(_counter);
		}
	}
}