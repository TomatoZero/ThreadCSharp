using System.Threading;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var storage = new Storage(12);
            const int consumerNum = 6;
            const int producerNum = 4;

            const int consumerProductNum = 2;
            const int producerProductNum = 3;

            var consumers = new Consumer[consumerNum];
            var producers = new Producer[producerNum];

            var consumersThread = new Thread[consumerNum];
            var producerThreads = new Thread[producerNum];

            for (var i = 0; i < consumers.Length; i++)
            {
                consumers[i] = new Consumer(storage, consumerProductNum, i);
                consumersThread[i] = new Thread(consumers[i].Run);
                consumersThread[i].Start();
            }

            for (var i = 0; i < producerNum; i++)
            {
                producers[i] = new Producer(storage, producerProductNum, i);
                producerThreads[i] = new Thread(producers[i].Run);
                producerThreads[i].Start();
            }
        }
    }
}