using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelAndNarrowChange.Method {
    public class AuthenticationService{
        public bool IsAuthenticated(int id){
            return id == 12345;
        }
    }
}
