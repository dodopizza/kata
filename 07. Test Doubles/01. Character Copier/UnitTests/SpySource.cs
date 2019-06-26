using Domain;
using FluentAssertions;

namespace UnitTests
{
	internal class SpySource: ISource
	{
		private bool _wasCalled;

		public char GetChar()
		{
			_wasCalled = true;
			return default(char);
		}

		public void VerifyGetChar()
		{
			_wasCalled.Should().BeTrue();
		}
	}
}