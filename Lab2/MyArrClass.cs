using System;
using System.Threading;

namespace Lab2{
    public class MyArrClass{
        private readonly int[] _arr;
        private int _minValue = Int32.MaxValue;
        private int _minValueIndex = 0;
        private int _theadCount = 0;
        
        private Object _monitorLock = new Object();
        
        public MyArrClass(int dimension) {
            _arr = new int[dimension];
            
            for(int i = 0; i < dimension; i++){
                _arr[i] = i;
            }

            _arr[4000000 - 1] = -13;
        }

        public (int, int) PartMin(int startIndex, int endIndex) {
            int min = Int32.MaxValue;
            int index = 0;

            for (var i = startIndex; i <= endIndex; i++) 
                if (min > _arr[i]) {
                    min = _arr[i];
                    index = i;
                }
            
            return (min, index);
        }
        
        public void SetMinValue(int value, int index) {
            lock (_monitorLock) {
                if (_minValue > value) {
                    _minValue = value;
                    _minValueIndex = index;
                }
                _theadCount++;
                Monitor.Pulse(_monitorLock);
            }
        }

        public (int, int) ParallelMin(int threadNum) {
            int minDimension = _arr.Length / threadNum;
            Thread[] thread = new Thread[threadNum];
            
            int i = 0, j = 0;
            ThreadMin minThread;
            for(; j < threadNum; i+= minDimension, j++) {
                if (_arr.Length % threadNum != 0 && j == threadNum - 1) 
                    minThread = new ThreadMin(i, _arr.Length - 1, this);
                else 
                    minThread = new ThreadMin(i, i + minDimension, this);
                
                thread[j] = new Thread(minThread.Run);
            }

            foreach (var t in thread) {
                t.Start();
            }

            lock (_monitorLock) {
                while (_theadCount < threadNum) {
                    Monitor.Wait(_monitorLock);
                }
            }
            
            return (_minValue, _minValueIndex);
        }
    }
}