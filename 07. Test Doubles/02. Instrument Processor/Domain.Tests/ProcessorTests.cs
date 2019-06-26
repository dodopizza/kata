using NSubstitute;
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
    }
}