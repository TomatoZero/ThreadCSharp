using System;

namespace Lab3{
    public class Consumer{
        private Storage _storage;
        private int _itemNum;

        public Consumer(Storage storage, int itemNum) {
            _storage = storage;
            _itemNum = itemNum;
        }
        
        public void Run() {
            try {
                string item;
                for (var i = 0; i < _itemNum; i++) {
                    Console.WriteLine($"EmptyAcquire Consumer: {i}");
                    _storage.EmptyWaitOne();
                    Console.WriteLine($"AccessAcquire Consumer: {i}");
                    _storage.AccessWaitOne();

                    item = _storage.TakeItem();

                    Console.WriteLine($"AccessRelease Consumer: {i}");
                    _storage.AccessRelease();
                    Console.WriteLine($"FullRelease Consumer: {i}");
                    _storage.FullRelease();
                }    
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}