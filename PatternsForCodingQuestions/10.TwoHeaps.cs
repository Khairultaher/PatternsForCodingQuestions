using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsForCodingQuestions
{
    public class TwoHeaps
    {
        public TwoHeaps() { }

        [Fact]
        public void FindMedianOfNumberStream()
        {
            MedianOfStream medianOfStream = new MedianOfStream();
            medianOfStream.InsertNum(3);
            medianOfStream.InsertNum(1);

            double median = medianOfStream.FindMedian();

            double expected = 2.0;
            Assert.Equal(median, expected);
        }
    }

    public class MedianOfStream
    {
        PriorityQueue<int, int> maxHeap;
        PriorityQueue<int, int> minHeap;
        public MedianOfStream() {
            maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a - b));
            minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a - b));
        }
        public void InsertNum(int num)
        {
            if (maxHeap.Count == 0 || maxHeap.Peek() >= num)
            {
                maxHeap.Enqueue(num, num);
            }
            else 
            {
                minHeap.Enqueue(num, num);
            }

            if (maxHeap.Count > minHeap.Count + 1)
            {
                var item = maxHeap.Dequeue();
                minHeap.Enqueue(item, item);
            }
            else if(maxHeap.Count < minHeap.Count)
            {
                var item = minHeap.Dequeue();
                maxHeap.Enqueue(item, item);
            }
        }

        public double FindMedian()
        {
            if (maxHeap.Count == minHeap.Count)
            {
                return minHeap.Peek() / 2.0 + maxHeap.Peek() / 2.0;
            }
            else
            {
                return maxHeap.Peek();
            }
        }
    }
}
