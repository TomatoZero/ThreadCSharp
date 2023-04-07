using System;
using System.Threading;

namespace Lab1
{
    public class Breaker
    {
        private readonly MyThread[] _myThreads;

        public Breaker(MyThread[] myThreads)
        {
            _myThreads = myThreads;
        }

        public void Stopper()
        {
            Array.Sort(_myThreads);

            var allTimeSleep = 0;

            var thisThreadSleep = _myThreads[0].SleepTime;

            StopAfterSleep(thisThreadSleep, 0);

            allTimeSleep += thisThreadSleep;

            for (var i = 1; i < _myThreads.Length; i++)
            {
                thisThreadSleep = _myThreads[i].SleepTime;
                var leftToSleep = thisThreadSleep - allTimeSleep;

                if (leftToSleep < 0)
                {
                    Console.WriteLine("leftToSleep < 0");
                    StopAfterSleep(0, i);
                }
                else StopAfterSleep(leftToSleep, i);
            }
        }

        private void StopAfterSleep(int thisThreadSleep, int i)
        {
            try
            {
                Thread.Sleep(thisThreadSleep);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _myThreads[i].StopThread();
            }
        }
    }
}