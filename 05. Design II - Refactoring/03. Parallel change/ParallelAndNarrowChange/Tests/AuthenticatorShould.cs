using FluentAssertions;
using NUnit.Framework;
using ParallelAndNarrowChange.Method;

namespace ParallelAndNarrowChange.Tests{
    [TestFixture]
    public class AuthenticationServiceTest{
        [Test]
        public void administrator_is_always_authenticated(){
            var service = new AuthenticationService();
            var adminId = 12345;
            service.IsAuthenticated(adminId).Should().BeTrue();
        }

        [Test]
        public void normalUser_is_not_authenticated_initially(){
            AuthenticationService service = new AuthenticationService();
            int normalUserId = 11111;
            service.IsAuthenticated(normalUserId).Should().BeFalse();
        }
    }
}
