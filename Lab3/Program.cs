using System.Threading;

namespace Lab3{
    internal class Program{
        public static void Main(string[] args) {
            var storage = new Storage(3);

            var consumer = new Consumer(storage, 10);
            var producer = new Producer(storage, 10);
            
            var consumerThread = new Thread(consumer.Run);
            var producerThread = new Thread(producer.Run);
            
            consumerThread.Start();
            producerThread.Start();

        }
    }
}