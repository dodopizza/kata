using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InstrumentProcessorCan
    {

        [Test]
        public void GetTaskFromTaskDispatcher()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            taskDispatcher
                .Setup(_ => _.GetTask())
                .Returns("play");
            var instrumentProsessor = new InstrumentProcessor(taskDispatcher.Object);
            
            var currentTask = instrumentProsessor.GetCurrentTask();
            
            Assert.AreEqual("play", currentTask);
        }
    }

    public class InstrumentProcessor
    {
        public InstrumentProcessor(ITaskDispatcher taskDispatcher)
        {
            
        }

        public string GetCurrentTask()
        {
            return "play";
        }
    }
}