using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class FrontInsertQueueTests
    {
        [TestMethod]
        public void FrontInsertQueue_Enqueue_AddsToBack()
        {
            var queue = new FrontInsertQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        public void FrontInsertQueue_Pop_RemovesFromFront()
        {
            var queue = new FrontInsertQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int value = queue.Pop();

            Assert.AreEqual(1, value);
            Assert.AreEqual(2, queue.Count);
        }

        [TestMethod]
        public void FrontInsertQueue_AddChild_InsertsAtFront()
        {
            var queue = new FrontInsertQueue<int>();
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.AddChild(1);

            Assert.AreEqual(1, queue.Pop());
        }

        [TestMethod]
        public void FrontInsertQueue_AddMultipleChildren_MaintainsOrder()
        {
            var queue = new FrontInsertQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.AddChild(1);
            queue.AddChild(2);
            queue.AddChild(3);

            Assert.AreEqual(1, queue.Pop());
            Assert.AreEqual(2, queue.Pop());
            Assert.AreEqual(3, queue.Pop());
            Assert.AreEqual(10, queue.Pop());
            Assert.AreEqual(11, queue.Pop());
        }

        [TestMethod]
        public void FrontInsertQueue_Pop_EmptyQueue_ThrowsException()
        {
            var queue = new FrontInsertQueue<int>();

            Assert.ThrowsException<InvalidOperationException>(() => queue.Pop());
        }

        [TestMethod]
        public void FrontInsertQueue_MixedOperations()
        {
            var queue = new FrontInsertQueue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.AddChild("child1");
            queue.Enqueue("c");
            queue.AddChild("child2");

            Assert.AreEqual("child1", queue.Pop());
            Assert.AreEqual("child2", queue.Pop());
            Assert.AreEqual("a", queue.Pop());
            Assert.AreEqual("b", queue.Pop());
            Assert.AreEqual("c", queue.Pop());
        }
    }
}
