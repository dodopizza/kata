using NSubstitute;
using NUnit.Framework;

namespace Domain.Tests
{
    public class CopierTests
    {
        [Test]
        public void WhenCopy_ThenCallGetCharOnes()
        {
            var source = Substitute.For<ISource>();
            var copier = new Copier(source, Substitute.For<IDestination>());
            
            copier.Copy();

            source.Received(1).GetChar();
        }
    }
}