using System;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Domain.Tests
{
    public class ProcessorTests
    {
        [Test]
        public void WhenProcess_ThenCallGetTaskOnes()
        {
            var taskDispatcher = Substitute.For<ITaskDispatcher>();
            var instrumentProcessor = new InstrumentProcessor(Substitute.For<IInstrument>(), taskDispatcher);

            instrumentProcessor.Process();

            taskDispatcher.Received(1).GetTask();
        }

        [Test]
        public void WhenProcess_ThenTaskPassedToInstrument()
        {
            var task = "task1";
            var taskDispatcher = Substitute.For<ITaskDispatcher>();
            taskDispatcher.GetTask().Returns(task);
            var instrument = Substitute.For<IInstrument>();
            var instrumentProcessor = new InstrumentProcessor(instrument, taskDispatcher);

            instrumentProcessor.Process();
            
            instrument.Received(1).Execute(task);
        }
        
        [Test]
        public void WhenProcessWithNullTask_ThenThrowArgumentNullException()
        {
            var taskDispatcher = Substitute.For<ITaskDispatcher>();
            taskDispatcher.GetTask().Returns((string) null);
            var instrument = new Instrument();
            var instrumentProcessor = new InstrumentProcessor(instrument, taskDispatcher);

            Assert.Throws<ArgumentNullException>(() => instrumentProcessor.Process());
        }
    }
}