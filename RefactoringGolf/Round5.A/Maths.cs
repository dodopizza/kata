using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round5.A
{

    public class Maths
    {

        private const double ErrorTolerance = 1e-15;

        public static double Sqrroot(double number)
        {
            double guess = number;
            while (Math.Abs(guess - number / guess) > ErrorTolerance * guess)
            {
                guess = (number / guess + guess) / 2.0;
            }
            return guess;
        }

    }

}
