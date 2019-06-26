using Domain;
using Xunit;

namespace UnitTests
{
	public class CopierTests
	{
		[Fact]
		public void WhenCopy_ShouldGetCharFromSource()
		{
			var source = new SpySource();
			var destination = new DummyDestination();
			var copier = new Copier(source, destination);

			copier.Copy();

			source.VerifyGetChar();
		}

		[Fact]
		public void WhenCopy_ShouldGetCharFromSourceUntilNewLine()
		{
			var source = new SpySource("a\n");
			var destination = new DummyDestination();
			var copier = new Copier(source, destination);

			copier.Copy();

			source.ShouldBeCalledTimes(2);
		}

		[Theory]
		[InlineData('a')]
		[InlineData('b')]
		public void WhenCopy_ShouldSetCharFromSourceToDestination(char letter)
		{
			var source = new FakeSource(letter);
			var destination = new SpyDestination();
			var copier = new Copier(source, destination);

			copier.Copy();

			destination.CalledWithChar(letter);
		}
	}
}