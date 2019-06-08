using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelAndNarrowChange.Method {
public class AnotherClientOfAuthenticator {
    public void UnusedClientCode() {
        try {
            new AuthenticationService().IsAuthenticated(3545);
        } catch (Exception e) {
            // ignored
        }
    }
}
}
