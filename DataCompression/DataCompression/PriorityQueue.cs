using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataCompression
{
    public class Node
    {
        public char c;
        public long frequency;

        public static Node GetDefaultNode()
        {
            return new Node { c = ' ', frequency = 0};
        }
    }

    public enum QueueType
    {
        Min,
        Max
    };

    /// <summary>
    /// Heap data structure; depending on constructor passed in type (Min/Max) 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IPriorityQueue<T>
    {
        protected List<Node> heapArray;
        public abstract void Add(T item);
        public abstract T Extract();
    }

    public class MaxPriorityQueue : IPriorityQueue<Node>
    {
        private int LastIndex
        {
            get
            {
                return this.heapArray.Count - 1;
            }
        }

        public MaxPriorityQueue()
        {
            this.heapArray = new List<Node>();
            this.heapArray.Add(Node.GetDefaultNode());  //sacrifice the 0th index node with a dummy node
        }

        public override void Add(Node item)
        {
            this.heapArray.Add(Node.GetDefaultNode());
            int i = LastIndex;
            int parenti = GetParent(i);
            while (i > 1 && this.heapArray[parenti].frequency < item.frequency)
            {
                this.heapArray[i] = this.heapArray[parenti];
                i = parenti;
                parenti = GetParent(i);
            }

            this.heapArray[i] = item;
        }

        private int GetParent(int i)
        {
            if(i%2 == 0)
                return i/2;

            return (i-1)/2;
        }

        public override Node Extract()
        {
            Node returnNode = this.heapArray[1];
            this.heapArray[1] = this.heapArray[LastIndex];
            this.heapArray[LastIndex] = null;

            Heapify(1);
            return returnNode;
        }

        private void Heapify(int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largestIndex = index;
            if (left < LastIndex && this.heapArray[left].frequency > this.heapArray[index].frequency)
            {
                largestIndex = left;   
            }

            if (right < LastIndex && this.heapArray[right].frequency > this.heapArray[largestIndex].frequency)
            {
                largestIndex = right;
            }

            if (largestIndex != index)
            {
                Node tmp = this.heapArray[index];
                this.heapArray[index] = this.heapArray[largestIndex];
                this.heapArray[largestIndex] = tmp;

                Heapify(largestIndex);
            }
        }
    }
}
