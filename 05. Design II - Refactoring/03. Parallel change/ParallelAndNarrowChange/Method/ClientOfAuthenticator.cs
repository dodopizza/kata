using System;

namespace ParallelAndNarrowChange.Method
{
    public static class ClientOfAuthenticator
    {
        public static void Main()
        {
            var authenticationService = new AuthenticationService();
            var authenticated = authenticationService.IsAuthenticated(33);
            Console.WriteLine("33 is authenticated = " + authenticated);
        }
    }
}