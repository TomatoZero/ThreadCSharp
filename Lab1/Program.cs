using System;
using System.Threading;

namespace Lab1{
    internal class Program{
        public static void Main(string[] args) {
            Console.WriteLine("Number threads:");
            var n = Convert.ToInt32(Console.ReadLine());

            var myThreads = new MyThread[n];
            var threads = new Thread[n];

            int j = n + 1;
            
            for (var i = 0; i < n; i++) {
                myThreads[i] = new MyThread(i, i + 1, (j--) * 10000);
                threads[i] = new Thread(myThreads[i].Run);
                threads[i].Start();
            }

            var breaker = new Breaker(myThreads);
            var breakerThread = new Thread(breaker.Stopper);
            breakerThread.Start();
        }
    }
}