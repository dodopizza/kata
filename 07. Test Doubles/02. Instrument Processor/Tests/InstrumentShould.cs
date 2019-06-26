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

            Assert.Throws<NullReferenceException>(() => instrument.Execute(null));
        }
    }
}