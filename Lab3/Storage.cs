using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3{
    public class Storage{
        private Semaphore _empty;
        private Semaphore _access;
        private Semaphore _full;

        private List<string> _list;

        public Storage(int storageSize) {
            _empty = new Semaphore(0, storageSize);
            _access = new Semaphore(1, 1);
            _full = new Semaphore(storageSize, storageSize);

            _list = new List<string>();
        }

        public void PutItem(string item) {
            _list.Add(item);
        }

        public string TakeItem() {
            var item = _list[0]; 
            _list.RemoveAt(0);
            return item;
        }

        public void EmptyWaitOne() => _empty.WaitOne();
        public void EmptyRelease() => _empty.Release();
        public void AccessWaitOne() => _access.WaitOne();
        public void AccessRelease() => _access.Release();
        public void FullWaitOne() => _full.WaitOne();
        public void FullRelease() => _full.Release();

    }
}