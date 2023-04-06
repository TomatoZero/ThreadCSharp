using System.Threading;

namespace Lab3{
    internal class Program{
        public static void Main(string[] args) {
            var storage = new Storage(3);
            const int consumerNum = 15;
            const int producerNum = 6;

            const int consumerProductNum = 2;
            const int producerProductNum = 5;

            var consumers = new Consumer[consumerNum];
            var producers = new Producer[producerNum];
            
            var consumersThread = new Thread[consumerNum];
            var producerThreads = new Thread[producerNum];
            
            for(int i = 0; i < consumers.Length; i++){
                consumers[i] = new Consumer(storage, consumerProductNum, i);
                consumersThread[i] = new Thread(consumers[i].Run);
                consumersThread[i].Start();
            }

            for(int i = 0; i < producerNum; i++){
                producers[i] = new Producer(storage, producerProductNum, i);
                producerThreads[i] = new Thread(producers[i].Run);
                producerThreads[i].Start();
            }
        }
    }
}