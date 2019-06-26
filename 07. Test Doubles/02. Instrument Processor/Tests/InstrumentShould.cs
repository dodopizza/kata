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
}