using Domain;

namespace UnitTests
{
	internal class FakeSource : ISource
	{
		private readonly char _charForGetChar;

		public FakeSource(char charForGetChar)
		{
			_charForGetChar = charForGetChar;
		}
		public char GetChar()
		{
			return _charForGetChar;
		}
	}
}