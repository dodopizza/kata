using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InstrumentProcessorShould
    {
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
            instrument
                .Setup(_ => _.Execute("play"))
                .Raises(_ => _.Finished += null, instrument.Object, new TaskFinishedEventHandlerArgs {Task = "play"});
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            instrumentProcessor.Process();
            
            taskDispatcher.Verify(_ => _.FinishedTask("play"), Times.Once);            
        }

        [Test]
        public void LogTaskExecutionErrorToConsole()
        {
            var taskDispatcher = CreateTaskDispatcher("error");
            var instrument = new Mock<IInstrument>();
            instrument
                .Setup(_ => _.Execute("error"))
                .Raises(_ => _.Error += null, EventArgs.Empty);
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher, instrument.Object);
            var console = new ConsoleSpy();
            instrumentProcessor.ReplaceConsole(console);
            
            instrumentProcessor.Process();
            
            Assert.AreEqual("Error occured", console.LastMessage);
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