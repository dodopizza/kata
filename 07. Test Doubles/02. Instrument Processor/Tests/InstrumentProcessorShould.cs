using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InstrumentProcessorShould
    {
        [Test]
        public void GetPlayTaskFromTaskDispatcher()
        {
            var taskDispatcher = CreateTaskDispatcher("play");
            var instrument = Mock.Of<IInstrument>();
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument);

            instrumentProcessor.Process();

            Assert.AreEqual("play", instrumentProcessor.GetCurrentTask());
        }

        [Test]
        public void GetMuteTaskFromTaskDispatcher()
        {
            var taskDispatcher = CreateTaskDispatcher("mute");
            var instrument = Mock.Of<IInstrument>();
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument);

            instrumentProcessor.Process();

            Assert.AreEqual("mute", instrumentProcessor.GetCurrentTask());
        }

        [Test]
        public void ExecuteTaskOnInstrument()
        {
            var taskDispatcher = CreateTaskDispatcher("mute");
            var instrumentMock = new Mock<IInstrument>();
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrumentMock.Object);

            instrumentProcessor.Process();

            instrumentMock.Verify(_ => _.Execute("mute"), Times.Once);
        }

        [Test]
        public void FailWhenInstrumentThrowsNullReferenceException()
        {
            var taskDispatcher = Mock.Of<ITaskDispatcher>();
            var instrument = new Mock<IInstrument>();
            instrument.Setup(_ => _.Execute(It.IsAny<string>())).Throws<NullReferenceException>();
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument.Object);

            Assert.Throws<NullReferenceException>(() => instrumentProcessor.Process());
        }

        [Test]
        public void FailWhenTaskDispatcherProvidesNullTask()
        {
            var taskDispatcher = CreateTaskDispatcher(null);
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, new Instrument());

            Assert.Throws<NullReferenceException>(() => instrumentProcessor.Process());
        }

        [Test]
        public void CallDispatchersFinishedTaskWhenInstrumentFinishedTheTask()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("play");
            var instrument = new Mock<IInstrument>();
            instrument.Setup(_ => _.Execute("play")).Raises(_ => _.Finished += null, EventArgs.Empty);
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            instrumentProcessor.Process();
            
            taskDispatcher.Verify(_ => _.FinishedTask("play"), Times.Once);            
        }

        private static ITaskDispatcher CreateTaskDispatcher(string task)
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns(task);
            return taskDispatcher.Object;
        }
    }
}