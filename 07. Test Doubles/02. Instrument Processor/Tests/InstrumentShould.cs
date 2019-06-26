using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class InstrumentShould
    {
        [Test]
        public void ThrowNullArgumentExceptionForNullTask()
        {
            var errorWasRaised = false;
            IInstrument instrument = new Instrument();
            instrument.Error += (sender, args) => { errorWasRaised = true; };
            
            instrument.Execute(null);
            
            Assert.True(errorWasRaised);
        }
    }

    public class Instrument : IInstrument
    {
        public void Execute(string task)
        {
            Error.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Finished;
        public event EventHandler Error;
    }
}