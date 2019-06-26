using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InstrumentProcessorCan
    {
        [Test]
        public void GetPlayTaskFromTaskDispatcher()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("play");
            var instrument = new Mock<IInstrument>();
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            instrumentProsessor.Process();

            Assert.AreEqual("play", instrumentProsessor.GetCurrentTask());
        }

        [Test]
        public void GetMuteTaskFromTaskDispatcher()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("mute");
            var instrument = new Mock<IInstrument>();
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            instrumentProsessor.Process();

            Assert.AreEqual("mute", instrumentProsessor.GetCurrentTask());
        }

        [Test]
        public void CanExecuteTaskOnInstrument()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("mute");
            var instrument = new Mock<IInstrument>();
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            instrumentProsessor.Process();

            instrument.Verify(_ => _.Execute("mute"), Times.Once);
        }
    }
}