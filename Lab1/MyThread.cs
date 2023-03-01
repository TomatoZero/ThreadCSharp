using System;
using System.Threading;

namespace Lab1{
    public class MyThread: IComparable{
        private int _id;
        private int _steep;
        private bool _isStop = false;
        private int _sleepTime;

        public int SleepTime { get => _sleepTime; }
        
        public MyThread(int id, int steep, int sleepTime) {
            _id = id;
            _steep = steep;
            _sleepTime = sleepTime;
        }

        public void Run() {
            Calculator();
        }

        public int CompareTo(object obj) {
            return this.SleepTime.CompareTo(((MyThread)obj).SleepTime);
        }

        public void StopThread() {
            _isStop = true;
        }
        
        private void Calculator(){
            double sum = 0.0;
            long i = 1;

            while(!_isStop){
                sum += i;
                i += _steep;
            }

            Console.WriteLine($"ID: {_id} Sum: {sum} Steep: {i / _steep}");
        }
    }
}