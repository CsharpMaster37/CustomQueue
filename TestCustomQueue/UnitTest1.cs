using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CustomQueue;

namespace TestCustomQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChangeCount()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                customQueue.Enqueue(i);
                Assert.AreEqual(i+1, customQueue.Count);
            }
        }

        [TestMethod]
        public void TestEnqueueAndDequeue()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                customQueue.Enqueue(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, customQueue.Dequeue());
            }
        }
        [TestMethod]
        public void TestPeek()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            for (int i = 0; i < 3; i++)
            {
                customQueue.Enqueue(i);
                Assert.AreEqual(0, customQueue.Peek());
            }
        }
        [TestMethod]
        public void TestContainsTrue()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                customQueue.Enqueue(i);
            }
            Assert.AreEqual(true, customQueue.Contains(0));
            Assert.AreEqual(true, customQueue.Contains(8));
            Assert.AreEqual(true, customQueue.Contains(19));
        }
        [TestMethod]
        public void TestContainsFalse()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                customQueue.Enqueue(i);
            }
            Assert.AreEqual(false, customQueue.Contains(22));
            Assert.AreEqual(false, customQueue.Contains(26));
            Assert.AreEqual(false, customQueue.Contains(100));
        }
        [TestMethod]
        public void TestContainsNull()
        {
            CustomQueue<int?> customQueue = new CustomQueue<int?>();
            customQueue.Enqueue(0);
            customQueue.Enqueue(null);
            customQueue.Enqueue(3);
            Assert.AreEqual(true, customQueue.Contains(null));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestZeroCountDequeue()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            customQueue.Dequeue();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestZeroCountPeek()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            customQueue.Peek();
        }
    }
}
