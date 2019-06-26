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
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object);
            
            var currentTask = instrumentProsessor.GetCurrentTask();
            
            Assert.AreEqual("play", currentTask);
        }

        [Test]
        public void GetMuteTaskFromTaskDispatcher()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("mute");
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object);
            
            var currentTask = instrumentProsessor.GetCurrentTask();
            
            Assert.AreEqual("mute", currentTask);
        }
    }
}