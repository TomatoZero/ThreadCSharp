using System;
using System.Threading;

namespace Lab1
{
    public class MyThread : IComparable
    {
        private readonly int _id;
        private readonly int _steep;
        private bool _isStop = false;
        public int SleepTime { get; }

        public MyThread(int id, int steep, int sleepTime)
        {
            _id = id;
            _steep = steep;
            SleepTime = sleepTime;
        }

        public void Run()
        {
            Calculator();
        }

        public int CompareTo(object obj)
        {
            return this.SleepTime.CompareTo(((MyThread)obj).SleepTime);
        }

        public void StopThread()
        {
            _isStop = true;
        }

        private void Calculator()
        {
            var sum = 0.0;
            var i = 1L;

            while (!_isStop)
            {
                sum += i;
                i += _steep;
            }

            Console.WriteLine($"ID: {_id} Sum: {sum} Steep: {i / _steep}");
        }
    }
}