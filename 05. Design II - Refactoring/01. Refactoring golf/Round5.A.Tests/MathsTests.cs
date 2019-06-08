using Xunit;

namespace Round5.A.Tests
{
    public class MathsTests
    {

        [Fact]
        public void RootOfOneIsOne()
        {
            Assert.Equal(1, Maths.Sqrroot(1), (int)1e-15);
        }

        [Fact]
        public void RootOfFourIsTwo()
        {
            Assert.Equal(2, Maths.Sqrroot(4), (int)1e-15);
        }

        [Fact]
        public void RootOfNineIsThree()
        {
            Assert.Equal(3, Maths.Sqrroot(9), (int)1e-15);
        }

        [Fact]
        public void RootOfSixteenIsFour()
        {
            Assert.Equal(4, Maths.Sqrroot(16), (int)1e-15);
        }

        [Fact]
        public void RootOfTwoFiveIsPointFive()
        {
            Assert.Equal(0.5, Maths.Sqrroot(0.25), (int)1e-15);
        }

    }
}
