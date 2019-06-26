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
		public void WhenCopy_ShouldSetCharFromSourceToDestination()
		{
			var source = new FakeSource('a');
			var destination = new SpyDestination();
			var copier = new Copier(source, destination);

			copier.Copy();

			destination.CalledWithChar('a');
		}
	}
}