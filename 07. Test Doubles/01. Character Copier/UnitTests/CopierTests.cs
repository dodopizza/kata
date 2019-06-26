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
	}
}