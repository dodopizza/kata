using System;
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

        [Test]
        public void WhenCopy_ThenCallSetCharOnes()
        {
            var destination = Substitute.For<IDestination>();
            var copier = new Copier(Substitute.For<ISource>(), destination);

            copier.Copy();

            destination.Received(1).SetChar(Arg.Any<char>());
        }

        [Test]
        public void WhenCopy_ThenDestinationGetCharFromSource()
        {
            var aChar = 'A';
            var source = Substitute.For<ISource>();
            source.GetChar().Returns(aChar);
            var destination = Substitute.For<IDestination>();
            var copier = new Copier(source, destination);

            copier.Copy();

            destination.Received(1).SetChar(aChar);
        }

        [Test]
        public void WhenSourceNull_ThenThrowArgNullException()
        {
            ISource source = null;

            Assert.Throws<ArgumentNullException>(() => new Copier(source, Substitute.For<IDestination>()));
        }

        [Test]
        public void WhenDestinationNull_ThenThrowArgNullException()
        {
            IDestination destination = null;

            Assert.Throws<ArgumentNullException>(() => new Copier(Substitute.For<ISource>(), destination));
        }
    }
}