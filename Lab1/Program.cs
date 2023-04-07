using System;
using System.Threading;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int n = 20;

            var myThreads = new MyThread[n];
            var threads = new Thread[n];

            var rn = new Random();
            for (var i = 0; i < n; i++)
            {
                myThreads[i] = new MyThread(i, i + 1, (rn.Next(10, 100)) * 100);
                threads[i] = new Thread(myThreads[i].Run);
                threads[i].Start();
            }

            var breaker = new Breaker(myThreads);
            var breakerThread = new Thread(breaker.Stopper);
            breakerThread.Start();
        }
    }
}