using System;

namespace Lab3{
    public class Producer{
        private Storage _storage;
        private int _itemNum;

        public Producer(Storage storage, int itemNum) {
            _storage = storage;
            _itemNum = itemNum;
        }

        public void Run() {
            try {
                for (var i = 0; i < _itemNum; i++) {
                    Console.WriteLine($"FullAcquire Producer: {i}");
                    _storage.FullWaitOne();
                    Console.WriteLine($"AccessAcquire Producer: {i}");
                    _storage.AccessWaitOne();

                    _storage.PutItem("Item " + i);

                    Console.WriteLine($"AccessRelease Producer: {i}");
                    _storage.AccessRelease();
                    Console.WriteLine($"EmptyRelease Producer:  {i}");
                    _storage.EmptyRelease();
                }    
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }    
        }
    }
}