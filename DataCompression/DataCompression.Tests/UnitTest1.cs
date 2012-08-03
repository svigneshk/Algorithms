using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCompression.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MaxPriorityQueue_Add_AddSingleItemToEmptyHeap()
        {
            MaxPriorityQueue maxPriorityQueue = new MaxPriorityQueue();

            Node node2add = new Node { c = 'a', frequency = 100 };
            maxPriorityQueue.Add(node2add);

            Node returnNode = maxPriorityQueue.Extract();
            Assert.AreEqual(node2add, returnNode);
        }

        [TestMethod]
        public void MaxPriorityQueue_Add_AddTwoItemsToEmptyHeap()
        {
            MaxPriorityQueue maxPriorityQueue = new MaxPriorityQueue();

            Node node1 = new Node { c = 'a', frequency = 100 };
            Node node2 = new Node { c = 'f', frequency = 1000 };
            maxPriorityQueue.Add(node1);
            maxPriorityQueue.Add(node2);

            Node returnNode = maxPriorityQueue.Extract();
            Assert.AreEqual(node2, returnNode);

            returnNode = maxPriorityQueue.Extract();
            Assert.AreEqual(node1, returnNode);
        }
    }
}
