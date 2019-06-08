using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Round5.A;
using Xunit;

namespace Round5.B.Tests
{
    public class MathsTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(16)]
        [InlineData(0.25)]
        public void RootSquaredIsOriginalNumber(double number)
        {
            Assert.Equal(Maths.Sqrroot(number) * Maths.Sqrroot(number), number, (int)1e-15);
        }
    }
}
