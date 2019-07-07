using System;
using System.Threading.Tasks;
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
        
        // instrument test
        [Test]
        public void WhenProcessWithNullTask_ThenThrowArgumentNullException()
        {
            var taskDispatcher = Substitute.For<ITaskDispatcher>();
            taskDispatcher.GetTask().Returns((string) null);
            var instrument = new Instrument();
            var instrumentProcessor = new InstrumentProcessor(instrument, taskDispatcher);

            Assert.Throws<ArgumentNullException>(() => instrumentProcessor.Process());
        }

        [Test]
        public void WhenInstrumentThrowException_ThenProcessThrowThisException()
        {
            var exMessage = "oops!";
            var instrument = Substitute.For<IInstrument>();
            instrument
                .When(x => x.Execute(Arg.Any<string>()))
                .Do(x => throw new InvalidOperationException(exMessage));
            var instrumentProcessor = new InstrumentProcessor(instrument, Substitute.For<ITaskDispatcher>());

            Assert.Throws<InvalidOperationException>(() => instrumentProcessor.Process(), exMessage);
        }

        [Test]
        public void WhenInstrumentFinishTask_ThenFinishedEventFired()
        {
            var receivedEventsCount = 0;
            var instrument = new Instrument();
            instrument.Finished += (s, e) =>
            {
                receivedEventsCount++;
            };
            
            instrument.Execute("task1");
            
            var expectedReceivedEventsCount = 1;
            SpinWait(() => receivedEventsCount, expectedReceivedEventsCount);
            
            Assert.AreEqual(expectedReceivedEventsCount, receivedEventsCount);
        }

        [Test]
        public void WhenInstrumentDetectError_ThenErrorEventFired()
        {
            var receivedEventsCount = 0;
            var instrument = new Instrument();
            instrument.Error += (s, e) =>
            {
                receivedEventsCount++;
            };
            
            instrument.Execute("error");
            var expectedReceivedEventsCount = 1;
            SpinWait(() => receivedEventsCount, expectedReceivedEventsCount);
            
            Assert.AreEqual(expectedReceivedEventsCount, receivedEventsCount);
        }

        private void SpinWait(Func<int> getReceivedEventsCount, int expectedReceivedEventsCount)
        {
            var attemptsLimit = 3;
            var attempt = 0;

            while (getReceivedEventsCount() != expectedReceivedEventsCount &&
                   attempt <= attemptsLimit)
            {
                Task.Delay(1000).Wait();
                attempt++;
            }
        }
    }
}